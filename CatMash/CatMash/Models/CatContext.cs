using CatMash.Models.Singleton;
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
        CatSingleton catSingleton;

        public CatContext()
        {
            catSingleton = CatSingleton.GetInstance;
            rdm = new Random();
            cats = new List<Cat>();
            GetAll();
        }

        public List<Cat> Cats => cats;

        public List<Cat> GetAll() => cats = catSingleton.Cats;

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
            for (int i = 0; i < 2; i++)
            {
                rdmCats.Add(cats[rdmNumber[i]]);
            }
            return rdmCats;
        }

        public void AddVote(string id) => catSingleton.Cats.Single(c => c.Id == id).Vote++;
    }
}