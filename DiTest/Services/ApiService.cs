using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DiTest.Interfaces;

namespace DiTest.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;

        private readonly ICandleCalculator _calculator;


        public ApiService(ICandleCalculator calculator)
        {
            _http = new HttpClient { BaseAddress = new Uri(https://www.google.com/) };
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LiveAccessToken);
            _http.DefaultRequestHeaders.Add("X-Accept-Datetime-Format", "UNIX");

            _calculator = calculator;
        }


        public async void PrimerCandle(long startTimeUnix)
        {
            string getJson = await _http.GetStringAsync("forexcandles");

            GetCandleHistory data = JsonConvert.DeserializeObject<GetCandleHistory>(getJson);

            _calculator.PrimerCandle(data.Candles.First());
        }


        public async void FurtherCandles(long startTimeUnix)
        {
            string getJson = await _http.GetStringAsync("forexcandles");

            GetCandleHistory data = JsonConvert.DeserializeObject<GetCandleHistory>(getJson);

            _calculator.FurtherCandles(data.Candles);
        }
    }
}
