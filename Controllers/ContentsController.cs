using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SinglePageCMS.Models;
using System.Text.RegularExpressions;

namespace SinglePageCMS.Controllers
{
    public class ContentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contents
        public ActionResult Index()
        {
            return View(db.Contents.Include(x => x.Category).ToList());
        }

        // GET: Contents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // GET: Contents/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(x => x.Name), "Id", "Name");
            return View();
        }

        // POST: Contents/Create   [Bind(Include = "Slug,Title,ContentData,Summery,Keywords,ImageUrl,BackGroundContent,CategoryId")] 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Content content, HttpPostedFileBase file)
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            var model = db.Contents.FirstOrDefault(x => x.Slug == content.Slug);
            if (model != null)
            {
                ModelState.AddModelError("", "آدرس متن را تغییر دهید.");
                return View(content);
            }

            content.CreateTime = DateTime.Now;
            content.Modified = DateTime.Now;
            content.Author = db.Registeries.Find("ApplicationName").Value;
            content.GooglePlusId = db.Registeries.Find("GoogleId").Value;
            if (file != null && file.ContentLength > 0)
            {
                var fileName = content.Summery;
                var imageName = Regex.Replace(fileName, " ", "-");
                var directory = Server.MapPath("~/Uploads/Content/");
                Directory.CreateDirectory(directory);
                var fileType = Path.GetExtension(file.FileName);
                var imageUrl = imageName + fileType;
                var path = Path.Combine(Server.MapPath("~/Uploads/Content"), imageUrl);
                file.SaveAs(path);
                content.ImageUrl = "/Uploads/Content/" + imageUrl;

                if (ModelState.IsValid)
                {
                    db.Contents.Add(content);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("","فایل یا ارسال نشده یا خالیست.");
                return View(content);
            }

            return View(content);
        }

        // GET: Contents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(x => x.Name), "Id", "Name");
            return View(content);
        }

        // POST: Contents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Slug,Title,ContentData,Summery,GooglePlusId,Author,Keywords,Modified,CreateTime,CategoryId,ImageUrl,BackGroundContent")] Content content, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                string fullPath = Request.MapPath("~" + content.ImageUrl);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }

                var fileName = content.Summery;
                var imageName = Regex.Replace(fileName, " ", "-");
                var directory = Server.MapPath("~/Uploads/Content/");
                Directory.CreateDirectory(directory);
                var fileType = Path.GetExtension(file.FileName);
                var imageUrl = imageName + fileType;
                var path = Path.Combine(Server.MapPath("~/Uploads/Content"), imageUrl);
                file.SaveAs(path);
                content.ImageUrl = "/Uploads/Content/" + imageUrl;
            }
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(x => x.Name), "Id", "Name");
            if (ModelState.IsValid)
            {
                content.Modified = DateTime.Now;
                db.Entry(content).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(content);
        }

        // GET: Contents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // POST: Contents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Content content = db.Contents.Find(id);
            
            string fullPath = Request.MapPath("~" + content.ImageUrl);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            db.Contents.Remove(content);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
