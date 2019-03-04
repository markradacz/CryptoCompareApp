using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using CryptoCompare.Models;
using Plugin.TextToSpeech;
using Xamarin.Forms;

namespace CryptoCompare.ViewModels
{
    public class CoinDetailViewModel : BaseViewModel
    {
        public string ItemId { get; set; }
        public Command LoadItemCommand { get; set; }

        bool isNotBusy = false;
        public bool IsNotBusy
        {
            get { return isNotBusy; }
            set { SetProperty(ref isNotBusy, value); }
        }

        private CoinDetailsResponse _coinDetails = null; 
        public CoinDetailsResponse CoinDetails 
        {
            get {   
                if (_coinDetails == null)
                {
                    _coinDetails = new CoinDetailsResponse();
                }
                return _coinDetails; 
            }
            set { SetProperty(ref _coinDetails, value); }
        }

        public CoinDetailViewModel(string id)
        {
            Title = "Crypto Compare";
            ItemId = id;
            LoadItemCommand = new Command(async () => await LoadItems());
        }

        public async Task LoadItems()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            IsNotBusy = false; 

            try
            {
                var coinDetailResult = await CoinDataStore.GetCoinDetailsAsync(ItemId);

                if (coinDetailResult.Response == "Success")
                {
                    CoinDetails = coinDetailResult; 
                }
                else
                {
                 // inform about no result with msg/box   
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
                IsNotBusy = true; 
            }
        }

        Command openWeb;
        public Command OpenWebCommand =>
            openWeb ??
            (openWeb = new Command(async () => await ExecuteOpenWebCommand()));

        private async Task ExecuteOpenWebCommand()
        {
            if (CoinDetails.Data != null)
                Device.OpenUri(new Uri(CoinDetails.Data.General.WebsiteUrl.AbsolutePath));
        }
    }

}
