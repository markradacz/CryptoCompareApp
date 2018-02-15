using System;
using System.Collections.Generic;
using CryptoCompare.ViewModels;
using Xamarin.Forms;

namespace CryptoCompare.Views
{
    public partial class CoinsPage : ContentPage
    {
        CoinsViewModel viewModel;

        public CoinsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CoinsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Coin;
            if (item == null)
                return;

            await Navigation.PushAsync(new CoinDetailPage(item.Id));

            // Manually deselect item
            CoinListView.SelectedItem = null;
        }

        //async void AddItem_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new NewItemPage());
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

    }
}
