using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace SinglePageCMS.Models
{
    public class MessagesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Messages
        public ActionResult Index()
        {
            return HttpNotFound();
        }

        public ActionResult Show()
        {
            var model = db.Messages.Where(x => x.Show).ToList();
            return PartialView(model);
        }

        public ActionResult Send()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Send(Message model)
        {
            model.Show = true;
            if (Request.IsAuthenticated)
            {
                model.UserName = User.Identity.GetUserId();
            }
            model.Read = false;
            model.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Messages.Add(model);
                db.SaveChanges();
                ViewBag.Success = "پیام شما با موفقیت در سیستم ثبت شد.";
                return PartialView();
            }
            ModelState.AddModelError("","لطفا از درستی متون موجود اطمینان کسب کرده و دوباره ارسال کنید.");
            return PartialView(model);
        }

        #region Helpers

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SendAnonymous()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendAnonymous(Message model)
        {
            return View();
        }

        #endregion
    }
}