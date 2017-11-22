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
        public CatContext catContext = new CatContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SeeCats()
        {
            ViewBag.Message = "Your application description page.";
            List<Cat> cats = catContext.GetAll();
            return View(cats);
        }

        public ActionResult VoteForCats()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}