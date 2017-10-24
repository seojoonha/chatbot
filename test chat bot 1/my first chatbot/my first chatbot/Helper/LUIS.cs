using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace my_first_chatbot.Helper
{

    public class Rootobject
    {
        public string query { get; set; }
        public Topscoringintent topScoringIntent { get; set; }
        public Intent[] intents { get; set; }
        public Entity[] entities { get; set; }
    }

    public class Topscoringintent
    {
        public string intent { get; set; }
        public float score { get; set; }
    }

    public class Intent
    {
        public string intent { get; set; }
        public float score { get; set; }
    }

    public class Entity
    {
        public string entity { get; set; }
        public string type { get; set; }
        public int startIndex { get; set; }
        public int endIndex { get; set; }
        public float score { get; set; }
    }

    public class LUIS
    {

        //public static async Task<Rootobject> parseUserInput(string strInput)
        //{
        //    string strRet = string.Empty;
        //    string strEscape = Uri.EscapeDataString(strInput);

        //    using (var client = new HttpClient())
        //    {

        //        HttpResponseMessage msg = await client.GetAsync(uri);

        //        if (msg.IsSuccessStatusCode)
        //        {
        //            var jsonResponse = await msg.Content.ReadAsStringAsync();
        //            var _data = JsonConvert.DeserializeObject<Rootobject>(jsonResponse);
        //            return _data;
        //        }
        //    }
        //}

        public static async Task<Rootobject> GetEntityFromLUIS(string Query)
        {
            Query = Uri.EscapeDataString(Query);
            Rootobject Data = new Rootobject();
            using (HttpClient client = new HttpClient())
            {
                string RequestURI = "https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/a3beb1a2-79fd-4d07-b06b-31e1f580930a?subscription-key=e19eae9ad78a40fab58918f9bbdc5a6a&timezoneOffset=0&verbose=true&q=" + Query;
                HttpResponseMessage msg = await client.GetAsync(RequestURI);

                if (msg.IsSuccessStatusCode)
                {
                    var JsonDataResponse = await msg.Content.ReadAsStringAsync();
                    Data = JsonConvert.DeserializeObject<Rootobject>(JsonDataResponse);
                }
            }
            return Data;
        }

    }
}