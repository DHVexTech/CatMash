using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace CatMash.Models
{
    public class Cat
    {
        public string ID { get; set; }
        public string URL { get; set; }
    }

    public class CatContext
    {
        public List<Cat> GetAll()
        {
            var json = new WebClient().DownloadString("https://latelier.co/data/cats.json");
            JObject catsJson = JObject.Parse(json);
            List<JToken> results = catsJson["images"].Children().ToList();
            List<Cat> cats = new List<Cat>();
            foreach (JToken result in results)
            {
                Cat cat = result.ToObject<Cat>();

                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(cat.URL);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    if (response.StatusCode == HttpStatusCode.OK)
                        cats.Add(cat);
                }
                catch(Exception e) {}
            }
            return cats;
        }
    }
}