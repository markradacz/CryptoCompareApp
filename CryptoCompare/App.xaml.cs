using System;

using Xamarin.Forms;

namespace CryptoCompare
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = false;
        public static string BackendUrl = "https://min-api.cryptocompare.com/";//"https://api.coinmarketcap.com/v1/ticker/";

        public App()
        {
            InitializeComponent();

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
               DependencyService.Register<CryptoCompareStore>(); 
            //DependencyService.Register<CloudDataStore>();

            if (Device.RuntimePlatform == Device.iOS)
                MainPage = new MainPage();
            else
                MainPage = new NavigationPage(new MainPage());
        }
    }
}
