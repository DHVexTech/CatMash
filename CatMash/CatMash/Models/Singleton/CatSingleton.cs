using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CatMash.Models.Singleton
{
    public class CatSingleton
    {
        private static CatSingleton instance = null;
        private static readonly object myLock = new object();
        private List<Cat> cats;

        private CatSingleton()
        {
            cats = GetAllCats();
        }

        public static CatSingleton GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new CatSingleton();

                return instance;
            }
        }

        public List<Cat> Cats => cats;

         public List<Cat> GetAllCats()
        {
            JObject catsJson = JObject.Parse(File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/Cats.JSON")));
            List<JToken> results = catsJson["images"].Children().ToList();
            List<Cat> listOfCats = new List<Cat>();
            foreach (JToken result in results)
            {
                Cat cat = result.ToObject<Cat>();
                listOfCats.Add(cat);
            }
            listOfCats.Sort((c1, c2) => c1.Vote.CompareTo(c2.Vote));
            return listOfCats;
        }
    }
}