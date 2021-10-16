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

        private GroceryItem existingItem;

        public GroceryItemFormPage(GroceryItem item)
        {
            InitializeComponent();

            existingItem = item;

            Title = "Update Grocery item";

            txtItemName.Text = item.ItemName;
            txtPrice.Text = item.Price.ToString();
            txtUnit.Text = item.Unit;
            txtQuantity.Text = item.Quantity.ToString();
        }

        void btnSave_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItemName.Text))
            {
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Error", "Item name is required", "Ok");
                });

                return;
            }

            int.TryParse(txtQuantity.Text, out int quantity);

            double.TryParse(txtPrice.Text, out double price);

            if (existingItem is null)
            {
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

            }
            else
            {
                existingItem.ItemName = txtItemName.Text;
                existingItem.Quantity = quantity;
                existingItem.Unit = txtUnit.Text;
                existingItem.Price = price;

                // use the existing key to overwrite saved data
                Barrel.Current.Add(existingItem.Id.ToString(), existingItem, TimeSpan.FromDays(100));
            }

            MainThread.BeginInvokeOnMainThread(async () => await App.Current.MainPage.Navigation.PopAsync());

        }
    }
}
