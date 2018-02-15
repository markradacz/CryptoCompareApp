using System;
using CryptoCompare.Views;
using Xamarin.Forms;

namespace CryptoCompare
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page coinsPage, itemsPage, aboutPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    coinsPage = new NavigationPage(new CoinsPage())
                    {
                        Title = "Crypto Compare.com"
                    };
                    itemsPage = new NavigationPage(new ItemsPage())
                    {
                        Title = "Coin Marketcap.com"
                    };

                    aboutPage = new NavigationPage(new AboutPage())
                    {
                        Title = "About"
                    };
                    coinsPage.Icon = "tab_feed.png";
                    itemsPage.Icon = "tab_feed.png";
                    aboutPage.Icon = "tab_about.png";
                    break;
                default:
                    coinsPage = new NavigationPage(new CoinsPage())
                    {
                        Title = "Crypto Currencies"
                    };
                    itemsPage = new ItemsPage()
                    {
                        Title = "coinmarketcap.com"
                    };

                    aboutPage = new AboutPage()
                    {
                        Title = "About"
                    };
                    break;
            }

            Children.Add(coinsPage);
            Children.Add(itemsPage);
            Children.Add(aboutPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
