
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using PinkyBankingForms.Helpers;
using Plugin.Fingerprint.Abstractions;
using Xamarin.Forms;

namespace PinkyBankingForms
{
    public class RequestPage : ContentPage
    {
        private Entry _amountEntry;
        private ServerConnectionHelper _serverConnectionHelper;
        public RequestPage()
        {
            Title = "Request";
            _amountEntry = new Entry { HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand, WidthRequest = 300, Text = "" };
            _serverConnectionHelper = new ServerConnectionHelper();
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = {
                    new Label { Text = "Requested amount", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.StartAndExpand },
                    _amountEntry,
                    new Button { Text ="Make request", Command = new Command(async () => ExecuteMoneyRequest()), HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.EndAndExpand }
                }
            };
        }


        private async void ExecuteMoneyRequest()
        {
            if (!VerifyAmountText())
            {
                return;
            }

            await AuthenticationAsync("Touch the fingerprint scanner");

            await _serverConnectionHelper.MakeWithdrawRequest(Double.Parse(_amountEntry.Text));
        }

        private async Task AuthenticationAsync(string reason, string cancel = null, string fallback = null, string tooFast = null)
        {

            var dialogConfig = new AuthenticationRequestConfiguration(reason)
            {
                CancelTitle = cancel,
                FallbackTitle = fallback,
                UseDialog = true
            };

            var result = await Plugin.Fingerprint.CrossFingerprint.Current.AuthenticateAsync
                         (dialogConfig);

            await SetResultAsync(result);
        }

        private async Task SetResultAsync(FingerprintAuthenticationResult result)
        {

        }

        private bool VerifyAmountText()
        {
            if (_amountEntry?.Text?.Length == 0
                || !Double.TryParse(_amountEntry.Text, out var result))
            {
                RepaintEntry(_amountEntry);
                return false;
            }

            return true;
        }

        private void RepaintEntry(Entry entry)
        {
            entry.BackgroundColor = Color.Pink;
            Task.Delay(1000).ContinueWith((obj) => { entry.BackgroundColor = Color.Default; });
        }
    }
}

