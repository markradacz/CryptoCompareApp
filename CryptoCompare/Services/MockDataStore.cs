using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CryptoCompare.Helpers;
using CryptoCompare.Models;
using Newtonsoft.Json;

namespace CryptoCompare
{
    public class MockDataStore : IDataStore<Item1>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

		public async Task<IEnumerable<Item1>> GetCoinListAsync(bool forceRefresh = false)
		{
            var respJsonOk = ResourceManager.GetMockData(typeof(MockDataStore).GetTypeInfo().Assembly, "CoinList.json");

			string respJson = respJsonOk;

			//var task = new Task<CoinListResult>(() =>
			//{
				var response = JsonConvert.DeserializeObject<IEnumerable<Item1>>(respJson);
			//	return response;
			//});
			//task.Start();

            return await Task.FromResult(response);
		}

        public Task<bool> AddItemAsync(Item1 item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Item1 item)
        {
            throw new NotImplementedException();
        }

        Task<Item1> IDataStore<Item1>.GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Item1>> IDataStore<Item1>.GetItemsAsync(bool forceRefresh)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Item1>> IDataStore<Item1>.GetCoinListAsync(bool forceRefresh)
        {
            throw new NotImplementedException();
        }

        public Task<CoinDetailsResponse> GetCoinDetailsAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Item1>> GetCoinMarketDataAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }
    }
}
