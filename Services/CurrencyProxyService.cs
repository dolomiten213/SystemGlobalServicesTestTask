using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SystemGlobalServicesTestTask.Entities.Output;
using SystemGlobalServicesTestTask.Input.Entities;

namespace SystemGlobalServicesTestTask.Services
{
    public class CurrencyProxyService
    {
        private DateTime _lastUpdate;
        private ILogger _logger;
        private const string URI = "https://www.cbr-xml-daily.ru/daily_json.js";

        
        private SortedDictionary<string, double> CharCodeCurrency { get; set; } = new SortedDictionary<string, double>();
        
        
        public CurrencyProxyService(ILogger<CurrencyProxyService> logger)
        {
            _logger = logger;
            var t = UpdateData();
            Task.Run(async () =>
            {
                while (true)
                {
                    // Delay between two cbr requests in milliseconds
                    await Task.Delay(1000 * 60 * 60);
                    await UpdateData();                  
                }
            });
            t.Wait();
        }
        

        /// <summary>
        /// Async operation requesting currencies from cbr
        /// </summary>
        private async Task UpdateData()
        {
            using HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(URI);

            _logger.LogInformation("Requesting new data from cbr servers...");

            if (response.IsSuccessStatusCode)
            {
                string myJsonResponse = await response.Content.ReadAsStringAsync();
                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

                _lastUpdate = myDeserializedClass.Date;
                var properties = myDeserializedClass.Valute.GetType().GetProperties();

                lock (CharCodeCurrency)
                {
                    CharCodeCurrency.Clear();
                    foreach (var prop in properties)
                    {
                        var valute = (ValuteBase)prop.GetValue(myDeserializedClass.Valute);
                        CharCodeCurrency.Add(valute.CharCode, valute.Value);
                    }
                }
                _logger.LogInformation("Currencies succesfully updated.");
            }
            else
            {
                _logger.LogError($"Server error : {(int)response.StatusCode} {response.ReasonPhrase}\n" +
                    $"      Impossible to update currency rates");
            }
        }
        

        /// <summary>
        /// Extracts currency with id character code
        /// </summary>
        /// <param name="id">Currency сharacter code</param>
        /// <returns>OutputCurrnecy</returns>
        public OutputCurrency GetCurrency(string id)
        {
            double value;

            if (CharCodeCurrency.TryGetValue(id.ToUpper(), out value))
            {
                _logger.LogInformation($"Success currency extraction: {id} {value}");
                return new OutputCurrency
                {
                    LastUpdate = _lastUpdate,
                    Name = id,
                    Rate = value                
                };
            }

            _logger.LogError($"Unsuccess currency extraction: {id}");
            return null;
        }
        

        /// <summary>
        /// Returns count of currencies after prevValute
        /// </summary>
        /// <param name="prevValute">Сharacter code of the previous currency</param>
        /// <param name="count">Count of returned currency</param>
        /// <returns>OutputCurrencies</returns>
        public OutputCurrencies GetNextCurrencies(string prevValute, int count)
        {
            var keys = CharCodeCurrency.Keys.ToList();
            var intStartIndex = keys.IndexOf(prevValute.ToUpper());
            
            if (intStartIndex == -1)
            {
                _logger.LogError($"Unsuccess currency extraction: {prevValute}");
                return null;
            }

            intStartIndex++;
            var res = new Dictionary<string, double>();
            
            for (int i = 0; i < count && intStartIndex + i < keys.Count; i++)
            {             
                var key = keys[intStartIndex + i];
                double value;
                
                if (CharCodeCurrency.TryGetValue(key, out value)) {
                    res.Add(key, value);
                }
                else
                {
                    break;
                }
            }
            _logger.LogInformation($"Success currencies extraction after {prevValute}, count = {res.Count}");
            return new OutputCurrencies
            {
                LastUpdate = _lastUpdate,
                Rates = res
            };
        }
    }
}
