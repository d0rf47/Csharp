using System;

namespace MaxToys
{
    class MaxToys
    {
        /// <summary>
        /// hackerrank problem find the maximum number of toys
        /// a person can buy with k$ given a list<int> of toy prices
        /// 
        /// Sort the list and track the running sum & number of toys
        /// keep iterating until the maximum number is reached without exceeding
        /// the total spendable amount.
        /// </summary>
        /// <param name="prices">List of Toy Prices</param>
        /// <param name="k">total amount of spending $</param>
        /// <returns></returns>
        public static int maximumToys(List<int> prices, int k)
        {
            int toyCnt = 0;
            int runningSum = 0;
            int len = prices.Count;
            prices.Sort();
            foreach(var p in prices)        
            {
                if(p + runningSum <= k)
                {
                    runningSum += p;
                    toyCnt++;
                }
                //early exit to prevent over iteration
                if(p + runningSum > k)
                    return toyCnt;
            }            
            return toyCnt;
        }
        
        public static void Main(string[] args)
        {
            List<int> arr = [1, 12, 5, 111, 200, 1000, 10];
            int maxSpend = 50;
            int NumberOfToys = maximumToys(arr, maxSpend);
            Console.WriteLine(NumberOfToys);
        }
    }
}