using System;
using System.Collections.Generic;
using MonkeyCache.LiteDB;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyFirstMobileApp.Views
{
    public partial class GroceryItemFormPage : ContentPage
    {
        public GroceryItemFormPage()
        {
            InitializeComponent();
        }

        void btnSave_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItemName.Text))
            {
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Error","Item name is required", "Ok");
                });

                return;
            }

            int.TryParse(txtQuantity.Text, out int quantity);

            double.TryParse(txtPrice.Text, out double price);

            Guid guid = Guid.NewGuid();

            GroceryItem grocery = new GroceryItem
            {
                Id = guid,
                ItemName = txtItemName.Text,
                Quantity = quantity,
                Unit = txtUnit.Text,
                Price = price,
            };

            Barrel.Current.Add<GroceryItem>(guid.ToString(), grocery, TimeSpan.FromDays(100));

            MainThread.BeginInvokeOnMainThread(async () => await App.Current.MainPage.Navigation.PopAsync());

        }
    }
}
