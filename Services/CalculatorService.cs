using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfiniteLambdaTest.Services
{
    public class CalculatorService : ICalculatorService
    {
        public bool IsPrime(int n)
        {
            return RabinMillerIsPrime(n, 10);
        }
   
        public int FindNextPrime(int from)
        {            
            while(!RabinMillerIsPrime(from, 10))
            {
                from++;
            }
            return from;
        }

        /// <summary>
        /// Calculates weather n is a prime using the Miller Rabin algorithm
        /// It's probabilistic algorithm, so might give false positives. 
        /// With k (num of rounds) higher then 10, its extremely unlikely - less then one in a million tries       
        /// Source: https://rosettacode.org/
        /// </summary>
        /// <param name="n">number to test</param>
        /// <param name="k">number of rounds</param>
        /// <returns>if in is prime</returns>
        private bool RabinMillerIsPrime(int n, int k)
        {
            if ((n < 2) || (n % 2 == 0)) return (n == 2);

            int s = n - 1;
            while (s % 2 == 0) s >>= 1;

            Random r = new Random();
            for (int i = 0; i < k; i++)
            {
                int a = r.Next(n - 1) + 1;
                int temp = s;
                long mod = 1;
                for (int j = 0; j < temp; ++j) mod = (mod * a) % n;
                while (temp != n - 1 && mod != 1 && mod != n - 1)
                {
                    mod = (mod * mod) % n;
                    temp *= 2;
                }

                if (mod != n - 1 && temp % 2 == 0) return false;
            }
            return true;
        }
    }
}
