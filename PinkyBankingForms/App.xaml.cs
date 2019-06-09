using System;
using PinkyBankingForms.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PinkyBankingForms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var tabPage = new TabbedPage { Title= "PinkyBank"};
            tabPage.Children.Add(new RequestPage());
            tabPage.Children.Add(new AmountPage());

            new ServerConnectionHelper().RegisterUser();

            Current.MainPage = tabPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            //Device.BeginInvokeOnMainThread()
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
