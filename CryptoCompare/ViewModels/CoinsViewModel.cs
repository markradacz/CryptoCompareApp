using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CryptoCompare
{
    public class CoinsViewModel : BaseViewModel
    {
        public ObservableCollection<Coin> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        string BaseURL = "https://min-api.cryptocompare";
        public int TotalCount { get; set;  }

        public CoinsViewModel()
        {
            Title = "Crypto Compare.com";
            Items = new ObservableCollection<Coin>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

         }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var coinList = await CoinDataStore.GetItemsAsync(true);

                if (coinList != null)
                {
                    var orderedList = coinList.OrderBy(x => x.SortOrder).ToList();
                   for (int i = 0; i < 100; i++) 
                    //foreach (var c in coinList)
                    {
                        Items.Add(orderedList[i]);
                        //Items.Add(c);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
