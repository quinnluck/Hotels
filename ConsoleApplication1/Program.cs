using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = makeArray(20); 
            int hotelsRet = MinPenalty(arr);
            //int hotelsRet = DynamicMinPenalty(arr);

            Console.WriteLine("return for Hotels: " + hotelsRet);

        }

        public static int DynamicMinPenalty(int [] hotels)
        {
            return DynamicMinimumPenalty(hotels, 0, new Dictionary<int, int>());
        }

        public static int DynamicMinimumPenalty(int[] hotels, int i, Dictionary<int, int> cache)
        {
            if (i == hotels.Length - 1)
            {
                return 0;
            }

            int result = 0;
            if(cache.TryGetValue(i, out result)){
                return result;
            }

            int minPen = int.MaxValue;
            int currentPen = 0;

            Stopwatch watch = Stopwatch.StartNew();

            for (int j = hotels.Length - 1; j > i; j--)
            {
                currentPen = Math.Abs((400 - (hotels[j] - hotels[i])) * (400 - (hotels[j] - hotels[i])));
                int nextPen = DynamicMinimumPenalty(hotels, j, cache);
                currentPen += nextPen;
                if(currentPen < minPen)
                {
                    minPen = currentPen;
                }
            }
            watch.Stop();

            long firstTime = watch.ElapsedMilliseconds;

            Stopwatch stopwatch = Stopwatch.StartNew();
            for(int j = hotels.Length - 1; j > i; j--)
            { }
            stopwatch.Stop();

            long overhead = stopwatch.ElapsedMilliseconds;

            long time = (firstTime - overhead);
            Console.WriteLine("firstTime in ms: " + firstTime);
            Console.WriteLine("overhead in ms: " + overhead);
            Console.WriteLine("time in ms: " + time);

            cache[i] = minPen;
            return minPen;
        }

        public static int MinPenalty(int[] hotels)
        {
            return MinimumPenalty(hotels, 0);
        }

        // woot woot question 1
        public static int MinimumPenalty(int[] hotels, int i)
        {
            if (i == hotels.Length - 1)
            {
                return 0;
            }

            int minPen = int.MaxValue;
            int currentPen = 0;

            Stopwatch watch = Stopwatch.StartNew();

            for (int j = hotels.Length - 1; j > i; j--)
            {
                currentPen = Math.Abs((400 - (hotels[j] - hotels[i])) * (400 - (hotels[j] - hotels[i])));
                int nextPen = MinimumPenalty(hotels, j);
                currentPen += nextPen;
                if (currentPen < minPen)
                {
                    minPen = currentPen;
                }
            }
            watch.Stop();

            long firstTime = watch.ElapsedMilliseconds;

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int j = hotels.Length - 1; j > i; j--)
            { }
            stopwatch.Stop();

            long overhead = stopwatch.ElapsedMilliseconds;


            long time = firstTime - overhead;
            Console.WriteLine("firstTime in ms: " + firstTime);
            Console.WriteLine("overhead in ms: " + overhead);
            Console.WriteLine("time in ms: " + time);

            return minPen;
        }


        // makes an array for me to use.
        public static int[] makeArray(int x)
        {
            int[] ret = new int[x];
            for(int i = 0; i < x; i++)
            {
                ret[i] = (i * 100);
            }
            return ret;
        }
    }
}
