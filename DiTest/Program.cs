using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiTest.Interfaces;
using DiTest.Services.Calculator;

namespace DiTest
{
    class Program
    {
        private ICandleCalculator _calculator;
        private LegacyApiService _legacyApi;

        static void Main(string[] args)
        {
            _calculator = new HeikinAshiCalculator();

            _legacyApi = new LegacyApiService(_calculator);

            _legacyApi.PrimerCandle(unixTimePlaceholder);
            _legacyApi.FurtherCandles(unixTimePlaceholder);
        }
    }
}
