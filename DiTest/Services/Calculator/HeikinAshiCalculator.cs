using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiTest.Interfaces;

namespace DiTest.Services.Calculator
{
    public class HeikinAshiCalculator : ICandleCalculator
    {
        private List<Candle> _candlesStandard;
        public List<Candle> CandlesStandard
        {
            get { return _candlesStandard; }
            set { _candlesStandard = value; }
        }

        private List<HeikinAshiCandle> _candlesHeikiAshi;
        public List<HeikinAshiCandle> CandlesHeikiAshi
        {
            get { return _candlesHeikiAshi; }
            set { _candlesHeikiAshi = value; }
        }


        public HeikinAshiCalculator()
        {
            _candlesStandard = new List<Candle>();
            _candlesHeikiAshi = new List<HeikinAshiCandle>();
        }


        public void PrimerCandle(Candle candle)
        {
            _candlesStandard.Add(candle);

            _candlesHeikiAshi.Add(new HeikinAshiCandle()
            {
                Close = ((candle.OpenMid + candle.HighMid + candle.LowMid + candle.CloseMid) / 4),
                Open = ((candle.OpenMid + candle.CloseMid) / 2),
                High = candle.HighMid,
                Low = candle.LowMid
            });
        }


        public void FurtherCandles(List<Candle> candles)
        {
            foreach (Candle candle in candles)
            {
                _candlesStandard.Add(candle);
                _candlesHeikiAshi.Add(CalculateCandleHeikinAshi(candle));
            }
        }


        private HeikinAshiCandle CalculateCandleHeikinAshi(Candle standardCandle)
        {
            return new HeikinAshiCandle
            {
                Close = (standardCandle.OpenMid + standardCandle.HighMid + standardCandle.LowMid + standardCandle.CloseMid) / 4,
                Open = (GetLastCandleHeikinAshi().Open + GetLastCandleHeikinAshi().Close) / 2,
                High = Math.Max(standardCandle.HighMid, Math.Max(standardCandle.OpenMid, standardCandle.CloseMid)),
                Low = Math.Min(standardCandle.LowMid, Math.Min(standardCandle.OpenMid, standardCandle.CloseMid))
            };
        }


        private HeikinAshiCandle GetLastCandleHeikinAshi()
        {
            return _candlesHeikiAshi.Last();
        }
    }
}
