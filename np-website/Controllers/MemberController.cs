using np_website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace np_website.Controllers
{
    public class MemberController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NewMemberModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.CreateMember();
                return RedirectToAction("AccountCreated");
            }

            return View();
        }

        [HttpGet]
        public ActionResult AccountCreated()
        {
            return View();
        }
    }
}
