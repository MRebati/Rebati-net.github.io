using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SinglePageCMS.Models;

namespace SinglePageCMS.Controllers
{
    public class SetDefaultsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: SetDefaults

        public ActionResult Index()
        {
            var s = db.Registeries.ToList();
            if (s.Count > 10)
            {
                var appname = db.Registeries.Find("ApplicationName").Value;
                var email = db.Registeries.Find("EmailAddress").Value;
                var address = db.Registeries.Find("Address").Value;
                var phonenumber = db.Registeries.Find("PhoneNumber").Value;
                var logo = db.Registeries.Find("Logo").Value;
                var googleId = db.Registeries.Find("GoogleId").Value;
                var fb = db.Registeries.Find("FacebookUrl").Value;
                var insta = db.Registeries.Find("InstagramUrl").Value;
                var googleUrl = db.Registeries.Find("GoogleUrl").Value;
                var publish = db.Registeries.Find("Publish").Value;

                ViewBag.address = false;
                ViewBag.appname = false;
                ViewBag.email = false;
                ViewBag.fb = false;
                ViewBag.googleId = false;
                ViewBag.insta = false;
                ViewBag.googleUrl = false;
                ViewBag.logo = false;
                ViewBag.phonenumber = false;
                ViewBag.publish = false;
                if (publish == "false")
                {
                    ViewBag.publish = true;
                }
                if (String.IsNullOrEmpty(googleUrl))
                {
                    ViewBag.googleUrl = true;
                }
                if (String.IsNullOrEmpty(googleId))
                {
                    ViewBag.googleId = true;
                }
                if (String.IsNullOrEmpty(insta))
                {
                    ViewBag.insta = true;
                }
                if (String.IsNullOrEmpty(fb))
                {
                    ViewBag.fb = true;
                }
                if (String.IsNullOrEmpty(logo))
                {
                    ViewBag.logo = true;
                }
                if (String.IsNullOrEmpty(phonenumber))
                {
                    ViewBag.phonenumber = true;
                }
                if (String.IsNullOrEmpty(address))
                {
                    ViewBag.address = true;
                }
                if (String.IsNullOrEmpty(email))
                {
                    ViewBag.email = true;
                }
                if (String.IsNullOrEmpty(appname))
                {
                    ViewBag.appname = true;
                }
            }
            return View();
        }

        public ActionResult Step1()
        {
            ViewBag.Title = "نام سایت";
            var data = db.Registeries.Find("ApplicationName");
            if (data == null)
            {
                return PartialView();
            }
            return PartialView(data);
        }

        [HttpPost]
        public ActionResult Step1(Registery model)
        {
            ViewBag.Title = "نام سایت";
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(model.Name))
                {
                    model.Name = "ApplicationName";
                    db.Entry(model).State = EntityState.Added;
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return PartialView(model);
        }

        public ActionResult Step2()
        {
            ViewBag.Title = "ایمیل سایت";
            var data = db.Registeries.Find("EmailAddress");
            if (data == null)
            {
                return PartialView();
            }
            return PartialView(data);
        }

        [HttpPost]
        public ActionResult Step2(Registery model)
        {
            ViewBag.Title = "ایمیل سایت";
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(model.Name))
                {
                    model.Name = "EmailAddress";
                    db.Entry(model).State = EntityState.Added;
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return PartialView(model);
        }

        public ActionResult Step3()
        {
            ViewBag.Title = "آدرس";
            var data = db.Registeries.Find("Address");
            if (data != null)
            {
                return PartialView(data);
            }
            return PartialView();
        }

        [HttpPost]
        public ActionResult Step3(Registery model)
        {
            ViewBag.Title = "آدرس";
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(model.Name))
                {
                    model.Name = "Address";
                    db.Entry(model).State = EntityState.Added;
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return PartialView(model);
        }

        public ActionResult Step4()
        {
            ViewBag.Title = "شماره تماس";
            var data = db.Registeries.Find("PhoneNumber");
            if (data != null)
            {
                return PartialView(data);
            }
            return PartialView();
        }

        [HttpPost]
        public ActionResult Step4(Registery model)
        {
            ViewBag.Title = "شماره تماس";
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(model.Name))
                {
                    model.Name = "PhoneNumber";
                    db.Entry(model).State = EntityState.Added;
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return PartialView(model);
        }

        public ActionResult Step5()
        {
            ViewBag.Title = "لوگو سایت";

            var data = db.Registeries.Find("Logo");
            if (data != null)
            {
                return PartialView(data);
            }
            var empty = new Registery();
            empty.Value = "Empty";
            return PartialView(empty);
        }

        [HttpPost]
        public ActionResult Step5(Registery model, HttpPostedFileBase file)
        {
            ViewBag.Title = "لوگو سایت";
            var imageName = "Logo";
            if (file != null)
            {
                var directory = Server.MapPath("~/Uploads/Logo/");
                Directory.CreateDirectory(directory);
                var fileType = Path.GetExtension(file.FileName);
                var imageUrl = imageName + fileType;
                var path = Path.Combine(Server.MapPath("~/Uploads/Logo"), imageUrl);
                file.SaveAs(path);
                model.Value = "/Uploads/Logo/" + imageUrl;
            }
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(model.Name))
                {

                    model.Name = "Logo";
                    db.Entry(model).State = EntityState.Added;
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return PartialView(model);
        }

        public ActionResult Step6()
        {
            ViewBag.Title = "آی دی گوگل";
            ViewBag.Caution = "آی دی گوگل پلاس را وارد کنید، از وارد کردن آدرس صفحه اجتناب کنید.";
            var data = db.Registeries.Find("GoogleId");
            if (data != null)
            {
                return PartialView(data);
            }
            return PartialView();
        }

        [HttpPost]
        public ActionResult Step6(Registery model)
        {
            ViewBag.Title = "آی دی گوگل";
            ViewBag.Caution = "آی دی گوگل پلاس را وارد کنید، از وارد کردن آدرس صفحه اجتناب کنید.";
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(model.Name))
                {
                    model.Name = "GoogleId";
                    db.Entry(model).State = EntityState.Added;
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return PartialView(model);
        }

        public ActionResult Step7()
        {
            ViewBag.Title = "آدرس فیس بوک";
            var data = db.Registeries.Find("FacebookUrl");
            if (data != null)
            {
                return PartialView(data);
            }
            return PartialView();
        }

        [HttpPost]
        public ActionResult Step7(Registery model)
        {
            ViewBag.Title = "آدرس فیس بوک";
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(model.Name))
                {
                    model.Name = "FacebookUrl";
                    db.Entry(model).State = EntityState.Added;
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return PartialView(model);
        }

        public ActionResult Step8()
        {
            ViewBag.Title = "آدرس اینستاگرام";
            var data = db.Registeries.Find("InstagramUrl");
            if (data != null)
            {
                return PartialView(data);
            }
            return PartialView();
        }

        [HttpPost]
        public ActionResult Step8(Registery model)
        {
            ViewBag.Title = "آدرس اینستاگرام";
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(model.Name))
                {
                    model.Name = "InstagramUrl";
                    db.Entry(model).State = EntityState.Added;
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return PartialView(model);
        }

        public ActionResult Step9()
        {
            ViewBag.Title = "آدرس گوگل";
            var data = db.Registeries.Find("GoogleUrl");
            if (data != null)
            {
                return PartialView(data);
            }
            return PartialView();
        }

        [HttpPost]
        public ActionResult Step9(Registery model)
        {
            ViewBag.Title = "آدرس گوگل";
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(model.Name))
                {
                    model.Name = "GoogleUrl";
                    db.Entry(model).State = EntityState.Added;
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return PartialView(model);
        }

        public ActionResult Step10()
        {
            ViewBag.Title = "انتشار سایت";
            var data = db.Registeries.Find("Publish");
            if (data != null)
            {
                return PartialView(data);
            }
            return PartialView();
        }

        [HttpPost]
        public ActionResult Step10(Registery model)
        {
            ViewBag.Title = "انتشار سایت";
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(model.Name))
                {
                    model.Name = "Publish";
                    db.Entry(model).State = EntityState.Added;
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return PartialView(model);
        }

        public ActionResult Step11()
        {
            ViewBag.Title = "توصیف نوع نمایشگاه";
            var data = db.Registeries.Find("GalleryDescribtion");
            if (data != null)
            {
                return PartialView(data);
            }
            return PartialView();
        }

        [HttpPost]
        public ActionResult Step11(Registery model)
        {
            ViewBag.Title = "توصیف نوع نمایشگاه";
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(model.Name))
                {
                    model.Name = "GalleryDescribtion";
                    db.Entry(model).State = EntityState.Added;
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return PartialView(model);
        }
    }
}