using System;
using System.Collections.Generic;
using System.Threading;
using CryptoCompare.ViewModels;
using Plugin.TextToSpeech;
using Xamarin.Forms;

namespace CryptoCompare.Views
{
    public partial class CoinDetailPage : ContentPage
    {
        public CoinDetailViewModel ViewModel;
        CancellationTokenSource _cancellCurrent = null;
        private CancellationTokenSource CancellCurrent
        {
            get
            {
                if (_cancellCurrent == null)
                    _cancellCurrent = new CancellationTokenSource();

                return _cancellCurrent;
            }
        }

        public CoinDetailPage()
        {
            InitializeComponent();
        }

        public CoinDetailPage(string id)
        {
            this.BindingContext = this.ViewModel = new CoinDetailViewModel(id);
            InitializeComponent();
        }

        void Add_Clicked(object sender, System.EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void ButtonWebsite_Clicked(object sender, EventArgs e)
        {
            if (ViewModel.CoinDetails.Data != null)
                Device.OpenUri(new Uri(ViewModel.CoinDetails.Data.General.AffiliateUrl));
        }

        private void ButtonSpeak_Clicked(object sender, EventArgs e)
        {
            // TEXT-TO-SPEECH INTEGRATION
            string greeter = "";
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    greeter = "This is the voice of Android";
                    break;
                case Device.iOS:
                    greeter = "My name is Siri";
                    break;
                case Device.WinPhone:
                    greeter = "Hi, I'm Cortana";
                    break;
            }

            CrossTextToSpeech.Current.Speak(greeter);

            CrossTextToSpeech.Current.Speak(this.ViewModel.CoinDetails.Data.General.NoHtmlDescription, cancelToken: CancellCurrent.Token);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.LoadItems();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CancellCurrent.Cancel();
        }
    }
}
