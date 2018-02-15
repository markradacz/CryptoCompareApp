using System;
using System.Collections.Generic;
using System.Linq;
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
    public class CryptoCompareStore : IDataStore<Coin>
    {
        HttpClient client;
        IEnumerable<Coin> items;
        CoinListResult clResult; 

        public CryptoCompareStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");

            items = new List<Coin>();
        }

        public async Task<IEnumerable<Coin>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"https://min-api.cryptocompare.com/data/all/coinlist");
                clResult = await Task.Run(() => JsonConvert.DeserializeObject<CoinListResult>(json, Converter.Settings));//JsonConvert.DeserializeObject<IEnumerable<Item1>>(json));
                var coins = new List<Coin>();
                foreach(var i in clResult.Data)
                {
                    coins.Add(i.Value); 
                }

                items = coins; 
            }

            return items.AsEnumerable();
        }

        public async Task<Coin> GetItemAsync(string id)
        {
            if (id != null && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"https://www.cryptocompare.com/api/data/coinsnapshotfullbyid/?id={id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Coin>(json));
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

        public Task<IEnumerable<Coin>> GetCoinListAsync(bool forceRefresh = false)
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

        public Task<bool> AddItemAsync(Coin item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Coin item)
        {
            throw new NotImplementedException();
        }
        public async Task<CoinDetailsResponse> GetCoinDetailsAsync(string id)
        {
            CoinDetailsResponse result = null; 

            if (id != null && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"https://www.cryptocompare.com/api/data/coinsnapshotfullbyid/?id={id}");
                result = await Task.Run(() => JsonConvert.DeserializeObject<CoinDetailsResponse>(json, Converter.Settings));
            }

            return result;
        }


        public async Task<IEnumerable<Item1>> GetCoinMarketDataAsync(bool forceRefresh = false)
        {
            IEnumerable<Item1> items = new List<Item1>();
            if (forceRefresh && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"https://api.coinmarketcap.com/v1/ticker/?limit=100");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Item1>>(json));
            }

            return items;
        }

    }
}
