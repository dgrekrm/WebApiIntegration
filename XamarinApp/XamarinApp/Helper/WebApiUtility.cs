using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinApp.LocalModels;

namespace XamarinApp.Helper {
    public class WebApiUtility {
        private static HttpClient client = new HttpClient();
        private static readonly string baseUrl = "http://192.168.1.2:81";
        private static string access_token = string.Empty;
        public static async Task<string> GetToken(string userName, string password) {
            var serviceUrl = $"{baseUrl}/token";
            List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>
                    {
                new KeyValuePair<string, string>( "grant_type", "password" ),
                new KeyValuePair<string, string>( "username", userName ),
                new KeyValuePair<string, string> ( "Password", password )
            };
            HttpContent content = new FormUrlEncodedContent(pairs);
            using(HttpResponseMessage response = await client.PostAsync(serviceUrl, content).ConfigureAwait(false))
                return await response.Content.ReadAsStringAsync();
        }

        public static async Task<string> Get(string method) {
            if(string.IsNullOrWhiteSpace(access_token)) {
                var s = GetToken("edeger", "Password1").Result;
                access_token = JsonConvert.DeserializeObject<Token>(s).access_token;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + access_token);
            }
            var serviceUrl = $"{baseUrl}/{method}";
            using(HttpResponseMessage response = await client.GetAsync(serviceUrl).ConfigureAwait(false))
                return await response.Content.ReadAsStringAsync();
        }
    }
}
