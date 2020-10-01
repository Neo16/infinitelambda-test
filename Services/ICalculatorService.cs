using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfiniteLambdaTest.Services
{
    public interface ICalculatorService
    {
        bool IsPrime(int number);
        int FindNextPrime(int number);   
    }
}
