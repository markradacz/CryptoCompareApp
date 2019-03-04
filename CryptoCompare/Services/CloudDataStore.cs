using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CryptoCompare.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace CryptoCompare
{
	//https://coinmarketcap.com/api/
    //
	public class CloudDataStore : IDataStore<Item1>
    {
        HttpClient client;
        IEnumerable<Item1> items;

        public CloudDataStore()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri($"{App.BackendUrl}/");

            items = new List<Item1>();
        }

        public async Task<IEnumerable<Item1>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"https://api.coinmarketcap.com/v1/ticker/?limit=100");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Item1>>(json));
            }

            return items;
        }

        public async Task<Item1> GetItemAsync(string id)
        {
            if (id != null && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"api/item/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Item1>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            if (item == null || !CrossConnectivity.Current.IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"api/item", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            if (item == null || item.Id == null || !CrossConnectivity.Current.IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"api/item/{item.Id}"), byteContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !CrossConnectivity.Current.IsConnected)
                return false;

            var response = await client.DeleteAsync($"api/item/{id}");

            return response.IsSuccessStatusCode;
        }

        public Task<IEnumerable<Item1>> GetCoinListAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddItemAsync(Item1 item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Item1 item)
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
