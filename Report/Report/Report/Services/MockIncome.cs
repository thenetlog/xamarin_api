using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Report.Models;
using Xamarin.Forms;
using Report.Services;
using System.Collections.ObjectModel;

[assembly: Xamarin.Forms.Dependency(typeof(Report.Services.MockIncome))]
namespace Report.Services
{

    public class MockIncome : IDataStore<Income>
    {
        
        List<Income> items;
        //private JObject att_req_json;
        private IHttpClientProvider _HttpClientProvider;

        public MockIncome()
        {
            items = new List<Income>();
            _HttpClientProvider = DependencyService.Get<IHttpClientProvider>();

            var mockItems = new List<Income>
            {
                new Income { IncomeId = "1", TransactionDate = DateTime.Now, DonarName="inc1", Amount = "1111" },

            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }  

        public async Task<bool> AddItemAsync(Income item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Income arg) => arg.IncomeId == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Income> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.IncomeId == id));
        }

        // For Api
        private const string Url = "https://api.myjson.com/bins/yxkk0";
        private readonly HttpClient _client = new HttpClient();
        public async Task<IEnumerable<Income>> GetItemsAsync(bool forceRefresh = false)
        {
            List<Income> items = null;
            string string_response = await _client.GetStringAsync(Url);
            //string string_response = await _HttpClientProvider.HttpPostMobileApi(null, Url);
            if (string_response != "false")
            {
                JObject att_req_json = JObject.Parse(string_response);
                var gbw = att_req_json["data"].ToString();
                items = JsonConvert.DeserializeObject<List<Income>>(gbw);
            }
            return items;
            //return await Task.FromResult(items);
        }

        public async Task<bool> UpdateItemAsync(Income item)
        {
            var _item = items.Where((Income arg) => arg.IncomeId == item.IncomeId).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }
    }
}

