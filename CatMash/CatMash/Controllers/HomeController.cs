using CatMash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CatMash.Controllers
{
    public class HomeController : Controller
    {
        public CatContext catContext;
        public HomeController()
        {
            catContext = new CatContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SeeCats() => View(catContext.Cats);

        public ActionResult VoteForCats(string id)
        {
            if (id != null)
                catContext.AddVote(id);

            List<Cat> RandomCats = catContext.GetTwoRandomCat();
            return View(RandomCats);
        }
    }
}