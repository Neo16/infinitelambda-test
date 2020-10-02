using InfiniteLambdaTest.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace InfiniteLambdaTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrimesController : ControllerBase
    {        
        private readonly ILogger<PrimesController> _logger;
        private readonly ICalculatorService _calculator;

        public PrimesController(
            ILogger<PrimesController> logger,
            ICalculatorService calculatorService)
        {
            _logger = logger;
            _calculator = calculatorService;
        }

        
        [SwaggerOperation(
            "Calculates weather a number is a prime.",
            "It's using the using the Miller Rabin algorithm. It might give false positives, but its extremely unlikely."          
        )]
        [ProducesResponseType(typeof(bool), 200)]
        [HttpGet("is-prime/{number}")]
        public bool IsPrime([Range(0, int.MaxValue)] int number)
        {
            return _calculator.IsPrime(number);
        }

        [SwaggerOperation(
          "Returns the next prime after a given number. (In integer range)",
          "i.e. Input: from, output: P where P >=from and P is prime. Relies on Miller Rabin algorithm." +
          "Returns no content, if no prime number found before reaching the integer max value. "
        )]
        [ProducesResponseType(typeof(int?), 200)]
        [ProducesResponseType(204)]
        [HttpGet("next-prime")]
        public int? GetNextPrime([Range(0, int.MaxValue)] int from)
        {
            return _calculator.FindNextPrime(from);
        }
    }
}
