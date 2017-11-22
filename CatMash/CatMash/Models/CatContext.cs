using Newtonsoft.Json;
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
        public string Id { get; set; }
        public string Url { get; set; }
        public int Vote { get; set; }
    }

    public class CatContext
    {
        Random rdm;
        List<Cat> cats;
        public CatContext()
        {
            rdm = new Random();
            cats = GetAll();
        }

        public List<Cat> Cats => cats;

        public List<Cat> GetAll()
        {
            JObject catsJson = JObject.Parse(File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/Cats.JSON")));
            List<JToken> results = catsJson["images"].Children().ToList();
            List<Cat> cats = new List<Cat>();
            foreach (JToken result in results)
            {
                Cat cat = result.ToObject<Cat>();
                cats.Add(cat);
            }
            cats.Sort((c1, c2) => c1.Vote.CompareTo(c2.Vote));
            return cats;
        }

        public List<Cat> GetTwoRandomCat()
        {
            List<Cat> rdmCats = new List<Cat>();
            List<int> rdmNumber = new List<int>();
            rdmNumber.Add(rdm.Next(0, cats.Count));
            rdmNumber.Add(rdm.Next(0, cats.Count));
            while (rdmNumber[0] == rdmNumber[1])
            {
                rdmNumber[1] = rdm.Next(0, cats.Count);
            }
            for (int i = 0; i <= 1; i++)
            {
                rdmCats.Add(cats[rdmNumber[i]]);
            }
            return rdmCats;
        }

        public void AddVote(string id)
        {
            Cat cat = Cats.Single(c => c.Id == id);
            cat.Vote++;
        }
    }
}