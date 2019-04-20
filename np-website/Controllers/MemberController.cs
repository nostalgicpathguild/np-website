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
            try
            {

                if (ModelState.IsValid)
                {
                    viewModel.CreateMember();
                    return RedirectToAction("AccountCreated");
                }

            }
            catch (Exception ex)
            {
                while(ex != null)
                {
                    ModelState.AddModelError("", ex.Message);
                    ex = ex.InnerException;
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(MemberLoginModel viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (viewModel.Login())
                        return RedirectToAction("Index", "Home");
                    else
                        throw new Exception("Invalid username or password");
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

            return View();
        }

        [HttpGet]
        public ActionResult AccountCreated()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}
