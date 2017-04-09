using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Deliver.Helpers;
using Deliver.Models;

namespace Deliver.Services
{
    class CardService
    {
        private HttpClient _client;

        private static CardService _instance;

        public CardService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
            _client.MaxResponseContentBufferSize = 256000;
        }

        public static CardService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CardService();
                }

                return _instance;
            }
        }

        public async Task<List<Card>> GetItems()
        {
            var items = new List<Card>();
            var uri = new Uri(string.Format("{0}/tables/card", GlobalSettings.XamagramEndpoint));

            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<Card>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return items;
        }
    }
}
