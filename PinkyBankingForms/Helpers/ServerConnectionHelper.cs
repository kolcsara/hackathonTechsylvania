using System;
using System.Net.Http;
using System.Threading.Tasks;
using PinkyBankingForms.Services;
using Xamarin.Forms;

namespace PinkyBankingForms.Helpers
{
    public class ServerConnectionHelper : IDisposable
    {
        public EventHandler IncomingMoneyWithdarwEventHandler;

        private const string _ipAddress = "http://192.168.71.218" + ":5000"; // todo add IP address each time
        private readonly HttpService _httpService;

        public ServerConnectionHelper()
        {
            _httpService = new HttpService(new HttpClient { BaseAddress = new Uri(_ipAddress) });

            IncomingMoneyWithdarwEventHandler += (sender, e) => CheckPendingRequest(sender, e);
        }

        private async Task CheckPendingRequest(object sender, EventArgs e)
        {
 }

        public async Task MakeWithdrawRequest(double amount)
        {
            await _httpService.MakePostRequest("/transaction", AuthenticationService.UserName, Device.RuntimePlatform is Device.iOS ? 2.ToString() : 1.ToString(), amount);
        }

        public async Task<double> GetAmount()
        {
            var value = await _httpService.MakeGetRequest("transaction/", AuthenticationService.UserName);
            return Double.Parse(value);
        }

        public async Task RegisterUser()
        {
            await _httpService.RegisterPostRequest("/register", AuthenticationService.UserName, 
                Device.RuntimePlatform is Device.iOS ? 1.ToString() : 2.ToString()).ConfigureAwait(false);
        }

        public void Dispose()
        {
            if (IncomingMoneyWithdarwEventHandler != null)
            {
                IncomingMoneyWithdarwEventHandler -= (sender, e) => CheckPendingRequest(sender, e);
            }
        }
    }
}
