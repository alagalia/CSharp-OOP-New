using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Prime_Checker
{
    class Prime_Checker
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Number number  = new Number(n, true);
            Number next = number.NextPrime(n);

            Console.WriteLine(next);
        }
    }
    public class Number
    {
        public int num;

        public bool isPrime;

        public Number(int n, bool isPrime)
        {
            this.num = n;
            this.isPrime = isPrime;
        }

        public Number NextPrime(int n)
        {
            int nextPrime = n+1;
            while (true)
            {
                if(this.IsPrime(nextPrime))
                {
                    this.isPrime = this.IsPrime(this.num);
                    return new Number(nextPrime, this.isPrime);
                }
                nextPrime++;
            }
        }

        private bool IsPrime(int number)
        {

            if (number == 0) return true;
            if (number == 1) return true;
            if (number == 2) return true;

            if (number % 2 == 0) return false; //Even number     

            for (int i = 3; i < number; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;

        }

        public override string ToString()
        {
            return $"{this.num}, {this.isPrime.ToString().ToLower()}";
        }
}}
