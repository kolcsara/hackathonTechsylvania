using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Xamarin.Forms;

namespace PinkyBankingForms.Services
{
    public class AuthenticationService
    {
        private static ISettings AppSettings => CrossSettings.Current;
        private static readonly string AppIdentifier = "PinkyBank";

        public static string UserName
        {
            get 
            {
                return Device.RuntimePlatform == Device.iOS ? "1" : "2";
            }

            set => AppSettings.AddOrUpdateValue(nameof(AppIdentifier), value);
        }

        public static double OwnedAmount
        {
            get
            {
                var amount = AppSettings.GetValueOrDefault(nameof(UserName), (double)0);

                if (amount == 0)
                {
                    OwnedAmount = 500;
                }

                return amount;
            }
            set => AppSettings.AddOrUpdateValue(nameof(UserName), value);
        }
    }
}
