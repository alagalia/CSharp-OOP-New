using System;
using System.Collections.Generic;

namespace _05.Fibonacci_Numbers
{
    class Program
    {
        static void Main()
        {
            int startPosition = int.Parse(Console.ReadLine());
            int endPosition = int.Parse(Console.ReadLine());

            Fibonacci fb = new Fibonacci();
            Console.WriteLine(string.Join(", ", fb.GetNumbersInRange(startPosition, endPosition)));
        }
    }

    class Fibonacci
    {
        private static Dictionary<int, long> fib = new Dictionary<int, long>();

        public List<long> GetNumbersInRange(int startPosition, int endPosition)
        {
            List<long> nums = new List<long>();
            for (int i = startPosition; i < endPosition; i++)
            {
                long fibNum = fib.ContainsKey(i) ? fib[i] : this.fibonacci(i);
                nums.Add(fibNum);
            }

            return nums;
        }

        private long fibonacci(int n)
        {
            if (fib.ContainsKey(n))
            {
                return fib[n];
            }
            if (n < 0)
            {
                return -1;
            }

            if (n == 0)
            {
                fib.Add(n, 0);
                return 0;
            }

            if (n == 1)
            {
                fib.Add(n, 1);
                return 1;
            }

            long fibNum = this.fibonacci(n - 1) + this.fibonacci(n - 2);
            fib.Add(n, fibNum);
            return fibNum;
        }
    }
}
