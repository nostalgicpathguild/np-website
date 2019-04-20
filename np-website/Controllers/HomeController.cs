using np_website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace np_website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new HomeViewModel();

            viewModel.Posts = PostModel.GetPosts();

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}