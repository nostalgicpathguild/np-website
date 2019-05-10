using np_website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace np_website.Controllers
{
    public class EventController : Controller
    {
        [HttpGet]
        [SiteAuthorize(UserLevels = new int[] { 6, 7 })]
        public ActionResult Index()
        {
            return View(new EventViewModel() { Events = EventItemModel.GetItems() });
        }

        [HttpPost]
        [SiteAuthorize(UserLevels = new int[] { 6, 7 })]
        public ActionResult Index(EventViewModel viewModel, string action = null, string delete = null)
        {
            if (action == "new")
            {
                ModelState.Clear();

                if (viewModel.Events == null)
                    viewModel.Events = new List<EventItemModel>();

                viewModel.Events.Add(new EventItemModel());
            }
            else if (action == "motd")
            {
                viewModel.Motd = viewModel.GenerateMotd();
            }
            else if (action == "save")
            {
                try
                {

                    if (ModelState.IsValid)
                    {
                        viewModel.SaveChanges();
                        return RedirectToAction("Index");
                    }

                }
                catch (Exception ex)
                {
                    while (ex != null)
                    {
                        ModelState.AddModelError("", ex.Message);
                        ex = ex.InnerException;
                    }
                }
            }
            else if (!string.IsNullOrWhiteSpace(delete))
            {
                viewModel.Events.RemoveAt(int.Parse(delete));
                ModelState.Clear();
            }

            return View(viewModel);
        }
    }
}