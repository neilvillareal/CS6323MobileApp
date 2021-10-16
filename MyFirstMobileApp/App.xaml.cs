using System;
using MonkeyCache.LiteDB;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyFirstMobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // this is a comment
            //MainPage = new NavigationPage(new MainPage()) { BarBackgroundColor = Color.Blue, BarTextColor = Color.White };
            //MainPage = new AppShell();
            //MainPage = new CalculatorPage();

            MainPage = new NavigationPage(new GroceryListPage());

            Barrel.ApplicationId = "myfirstApp";
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
