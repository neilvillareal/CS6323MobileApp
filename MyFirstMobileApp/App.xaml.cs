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

            //MainPage = new NavigationPage(new MainPage()) { BarBackgroundColor = Color.Blue, BarTextColor = Color.White };
            //MainPage = new AppShell();
            //MainPage = new CalculatorPage();

            MainPage = new NavigationPage(new GroceryListPage());

            Barrel.ApplicationId = "myfirstApp";
        }

        protected override void OnStart()
        {

            // this is a change in the otherBranch

            // this change in this line is to demo i will make pull request

            // simplify
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
