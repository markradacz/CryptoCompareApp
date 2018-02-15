using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoCompare.Models;

namespace CryptoCompare
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<CoinDetailsResponse> GetCoinDetailsAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
        Task<IEnumerable<T>> GetCoinListAsync(bool forceRefresh = false);
        Task<IEnumerable<Item1>> GetCoinMarketDataAsync(bool forceRefresh = false);
	}
}
