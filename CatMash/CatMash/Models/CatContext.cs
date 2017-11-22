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
        CatSingleton catSingleton;

        public CatContext()
        {
            catSingleton = CatSingleton.GetInstance;
            rdm = new Random();
        }

        public List<Cat> GetAll()
        {
            catSingleton.Cats.Sort((c1, c2) => c2.Vote.CompareTo(c1.Vote));
            return catSingleton.Cats;
        }

        public List<Cat> GetTwoRandomCat()
        {
            List<Cat> rdmCats = new List<Cat>();
            List<int> rdmNumber = new List<int>();
            rdmNumber.Add(rdm.Next(0, catSingleton.Cats.Count));
            rdmNumber.Add(rdm.Next(0, catSingleton.Cats.Count));
            while (rdmNumber[0] == rdmNumber[1])
            {
                rdmNumber[1] = rdm.Next(0, catSingleton.Cats.Count);
            }
            for (int i = 0; i < 2; i++)
            {
                rdmCats.Add(catSingleton.Cats[rdmNumber[i]]);
            }
            return rdmCats;
        }

        public void AddVote(string id) => catSingleton.Cats.Single(c => c.Id == id).Vote++;
    }
}