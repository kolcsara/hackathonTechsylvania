using System;
using System.Text;
using Newtonsoft.Json;
using PinkyBankingForms.Models;

namespace PinkyBankingForms.Extensions
{
    public static class HashDataExtension
    {
        public static string ToBase64(this Hash obj)
        {
            string json = JsonConvert.SerializeObject(obj);

            byte[] bytes = Encoding.Default.GetBytes(json);

            return Convert.ToBase64String(bytes);
        }

        public static Hash FromBase64(this string base64Text)
        {
            byte[] bytes = Convert.FromBase64String(base64Text);

            string json = Encoding.Default.GetString(bytes);

            return JsonConvert.DeserializeObject<Hash>(json);
        }
    }
}
