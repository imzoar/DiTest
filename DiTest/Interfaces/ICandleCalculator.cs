using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiTest.Interfaces
{
    public interface ICandleCalculator
    {
        List<Candle> CandlesStandard { get; set; }
        void PrimerCandle(Candle candle);
        void FurtherCandles(List<Candle> candles);
    }
}
