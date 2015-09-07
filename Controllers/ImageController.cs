using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SinglePageCMS.Models;

namespace SinglePageCMS.Controllers
{
    public class ImageController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: Image
        public ActionResult Index()
        {
            ViewBag.Title = "مدیریت فایل ها";
            return View();
        }

        public ActionResult Folders()
        {
            var model = db.ImageCategories.ToList();
            return PartialView(model);
        }

        public ActionResult AddFolder()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddFolder(ImageCategory model)
        {
            Guid id = Guid.NewGuid();
            string s = Convert.ToBase64String(id.ToByteArray());
            model.Id = s;
            model.CreateDate = DateTime.Now;
            model.Modified = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.ImageCategories.Add(model);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
            //return Json(new
            //{
            //    Status = true,
            //    Message = "Succesfully saved"
            //});      
        }

        public ActionResult EditFolder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.ImageCategories.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditFolder(ImageCategory model)
        {
            model.Modified = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteFolder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.ImageCategories.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return PartialView(model);
        }

        [HttpPost, ActionName("DeleteFolder")]
        public ActionResult DeleteFolderConfirm(string id)
        {
            ImageCategory imageCategory = db.ImageCategories.Find(id);
            var images = db.Images.Where(x => x.ImageCategoryId == id);
            foreach (var item in images)
            {
                Image image = db.Images.Find(item.Id);
                string fullPath = Request.MapPath("~" + image.Path);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                db.Images.Remove(image);
                db.SaveChanges();
            }
            db.ImageCategories.Remove(imageCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ShowImage(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.Images.Where(x => x.ImageCategoryId == id).ToList();
            ViewBag.Title = db.ImageCategories.Find(id).Name;
            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }
            return RedirectToAction("ShowImageView", new { id });
        }

        public ActionResult ShowImageView(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.Images.Where(x => x.ImageCategoryId == id).ToList();
            ViewBag.Title = db.ImageCategories.Find(id).Name;

            return View(model);
        }

        public ActionResult AddImage()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddImage(Image model, List<HttpPostedFileBase> fileUpload)
        {
            foreach (var item in fileUpload)
            {
                if (item != null && item.ContentLength > 0)
                {
                    model.ImageName = item.FileName.ToLower();

                }

                if (ModelState.IsValid)
                {
                    db.Images.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("ShowImage", new { id = model.ImageCategoryId });
                }
            }
            ModelState.AddModelError("", "An Error Occured!");

            return View(model);

        }

        public ActionResult EditImage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.Images.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditImage(Image model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("ShowImage", new { id = model.ImageCategoryId });
        }

        //public ActionResult DeleteImage(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var model = db.Images.Find(id);
        //    if (model == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return PartialView(model);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteImage(int id)
        {
            Image image = db.Images.Find(id);
            string fullPath = Request.MapPath("~" + image.Path);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            var imgId = image.ImageCategoryId;
            db.Images.Remove(image);
            db.SaveChanges();
            return RedirectToAction("ShowImage", new { imgId });
        }
    }
}