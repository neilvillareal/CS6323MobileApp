using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MyFirstMobileApp
{
    public partial class GroceryListPage : ContentPage
    {
        private ObservableCollection<GroceryItem> Source;

        public GroceryListPage()
        {
            InitializeComponent();
            Source = new ObservableCollection<GroceryItem>();
        }

        void btnAddToCart_Clicked(System.Object sender, System.EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {

                string addedToCartItem = await DisplayPromptAsync(title: "Add to Cart", message: "Enter grocery item name", placeholder: "e.g. eggs and ham", maxLength: 30);

                if (string.IsNullOrEmpty(addedToCartItem))
                    return;

                string quantityOfItem = await DisplayPromptAsync(title: "Add to Cart", message: "Enter quantity for the item");

                string quantityUnit = await DisplayPromptAsync(title: "Add to Cart", message: "Enter quantity unit", placeholder: "e.g. kg or lb", maxLength: 10);

                int.TryParse(quantityOfItem , out int quantity);

                GroceryItem grocery = new GroceryItem
                {
                    ItemName = addedToCartItem,
                    Quantity = quantity,
                    Unit = quantityUnit,
                };

                Source.Add(grocery);

                cvMainList.ItemsSource = Source;
            });
        }
    }
}
