using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiTest.Interfaces;

namespace DiTest.Services.Calculator
{
    public class OHLCCalculator : ICandleCalculator
    {
        public List<Candle> CandlesStandard { get; set; }
        public void PrimerCandle(Candle candle)
        {
            throw new NotImplementedException();
        }

        public void FurtherCandles(List<Candle> candles)
        {
            throw new NotImplementedException();
        }
    }
}
