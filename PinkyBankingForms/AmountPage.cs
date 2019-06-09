using System;
using System.Timers;
using PinkyBankingForms.Helpers;
using PinkyBankingForms.Models;
using Xamarin.Forms;

namespace PinkyBankingForms
{
    public class AmountPage : ContentPage
    {
        private readonly ServerConnectionHelper _serverConnectionHelper;
        private static Timer aTimer;

        private double _amount;
        private Label _amountLabel;

        public AmountPage()
        {
            Title = "Amount";
            _amountLabel = new Label
            {
                Text = $"Your current bank account {_amount}",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Content = new StackLayout
            {
                Children = {
                    _amountLabel
                }
            };

            _serverConnectionHelper = new ServerConnectionHelper();

            TriggerTimer();
        }

        private void TriggerTimer()
        {
            double interval = 5000.0;
            aTimer = new System.Timers.Timer(interval);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            _amountLabel.Text = $"Your current bank account { _serverConnectionHelper.GetAmount().Result}";
        }
    }
}

