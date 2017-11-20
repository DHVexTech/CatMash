using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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
            // change the path for the futur
            JObject catsJson = JObject.Parse(File.ReadAllText(@"D:\In'Tech\PI\CatMash\CatMash\CatMash\App_Data\Cats.JSON"));
            List<JToken> results = catsJson["images"].Children().ToList();
            List<Cat> cats = new List<Cat>();
            foreach (JToken result in results)
            {
                Cat cat = result.ToObject<Cat>();
                cats.Add(cat);
            }
            return cats;
        }
    }
}