using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PinkyBankingForms.Services
{
    public class HttpService
    {
        private HttpClient _client;

        public HttpService(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public async Task<string> MakeGetRequest(string resource, string userId)
        {
            var response = await _client.GetStringAsync($"{_client.BaseAddress}{resource}{userId}");
            var liberacao = JsonConvert.DeserializeObject<string>(response);
            return liberacao;

            //using (var c = new HttpClient())
            //{
            //     response = await _client.GetAsync(new Uri($"/{resource}/{userId}"));

            //    if (response.IsSuccessStatusCode)
            //    {
            //        var result = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
            //        var id = result;
            //        return id.ToString();
            //    }
            //}
            //return "0";
        }

        public async Task MakePostRequest(string resource, string userId, string otherUserFingerPrint, double amount)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(_client.BaseAddress + $"/{resource}/{userId}/{otherUserFingerPrint}/{amount}");
            httpWebRequest.ContentType = "plain/text";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write("{}");
            }
            
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }

        public async Task RegisterPostRequest(string resource, string userId, string fingerprintPhrase)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(_client.BaseAddress + $"/{resource}/{userId}/{fingerprintPhrase}");
            httpWebRequest.ContentType = "plain/text";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write("{}");
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }

        private Task<T> DeserializeObject<T>(string responseString)
        {
            throw new NotImplementedException();
        }
    }
}
