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

            (viewModel.PostPageCount, viewModel.Posts) = PostModel.GetPosts(viewModel.PostsPageIndex, viewModel.PostsRecsPerPage);
            viewModel.Events = EventItemModel.GetItems();

            return View(viewModel);
        }

        [Route("posts/{id:int}")]
        public ActionResult IndexByPage(int id)
        {
            var viewModel = new HomeViewModel();

            viewModel.PostsPageIndex = id;
            (viewModel.PostPageCount, viewModel.Posts) = PostModel.GetPosts(id, viewModel.PostsRecsPerPage);
            viewModel.Events = EventItemModel.GetItems();

            return View("Index", viewModel);
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