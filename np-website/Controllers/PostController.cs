using np_website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace np_website.Controllers
{
    public class PostController : Controller
    {
        [SiteAuthorize(UserLevels = new int[] { 6, 7 })]
        public ActionResult Index()
        {
            var viewModel = new Models.PostListModel();

            viewModel.Posts = Models.PostListModel.GetPosts();

            return View(viewModel);
        }

        [HttpGet]
        [SiteAuthorize(UserLevels = new int[] { 6, 7 })]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        [SiteAuthorize(UserLevels = new int[] { 6, 7 })]
        public ActionResult New(NewPostModel viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    viewModel.CreatePost();
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

            return View();
        }

        [HttpGet]
        [SiteAuthorize(UserLevels = new int[] { 6, 7 })]
        public ActionResult Edit(int id)
        {
            return View(EditPostModel.GetDetails(id));
        }

        [HttpPost]
        [SiteAuthorize(UserLevels = new int[] { 6, 7 })]
        public ActionResult Edit(EditPostModel viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    viewModel.UpdatePost();
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

            return View();
        }

        [HttpPost]
        [SiteAuthorize(UserLevels = new int[] { 6, 7 })]
        public ActionResult Upload()
        {
            if (Request.Files?.Count > 0)
            {
                var file = Request.Files[0];

                var fileName = $"{System.IO.Path.GetFileNameWithoutExtension(file.FileName)}.{PostImageModel.GenerateThumbprint()}{System.IO.Path.GetExtension(file.FileName)}";

                file.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Uploads"), fileName));

                return Json(new PostImageModel() { location = $"/Uploads/{fileName}" });
            }

            return HttpNotFound();
        }

        [HttpGet]
        [SiteAuthorize(UserLevels = new int[] { 6, 7 })]
        public ActionResult Delete(int id)
        {
            return View(DeletePostViewModel.GetDetails(id));
        }

        [HttpPost]
        [SiteAuthorize(UserLevels = new int[] { 6, 7 })]
        public ActionResult Delete(DeletePostViewModel viewModel, string action)
        {
            try
            {
                if (action == "yes")
                    viewModel.Delete();

                return RedirectToAction("Index");

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

    }
}