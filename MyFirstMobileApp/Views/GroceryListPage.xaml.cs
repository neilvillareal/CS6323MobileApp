using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MonkeyCache.LiteDB;
using MyFirstMobileApp.Views;
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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            LoadSavedData();
        }

        void btnAddToCart_Clicked(System.Object sender, System.EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new GroceryItemFormPage());

            });
        }


        void LoadSavedData()
        {
            Source = new ObservableCollection<GroceryItem>();

            foreach (var key in Barrel.Current.GetKeys())
            {
                var item = Barrel.Current.Get<GroceryItem>(key);
                Source.Add(item);
            }

            cvMainList.ItemsSource = Source;
        }

        void SwipeDelete_Invoked(object sender, EventArgs e)
        {
            if (sender is SwipeItem swipeItem)
            {
                if (swipeItem.BindingContext is GroceryItem item)
                {
                    var removeFromSource = Source.FirstOrDefault(s => s.Id == item.Id);

                    if (removeFromSource != null)
                    {
                        Source.Remove(removeFromSource);

                        Barrel.Current.Empty(new string[] { removeFromSource.Id.ToString() });
                    }
                }
            }
        }

        void SwipeUpdate_Invoked(object sender, EventArgs e)
        {
            if (sender is SwipeItem swipeItem)
            {
                if (swipeItem.BindingContext is GroceryItem item)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await App.Current.MainPage.Navigation.PushAsync(new GroceryItemFormPage(item));

                    });
                }
            }
        }
    }
}
