using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using SinglePageCMS.Models;

namespace SinglePageCMS.Controllers
{
    public class GalleryItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GalleryItems
        public ActionResult Index()
        {
            var galleryItems = db.GalleryItems.Include(g => g.Gallery);
            return View(galleryItems.ToList());
        }

        // GET: GalleryItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GalleryItem galleryItem = db.GalleryItems.Find(id);
            if (galleryItem == null)
            {
                return HttpNotFound();
            }
            return View(galleryItem);
        }

        // GET: GalleryItems/Create
        public ActionResult Create()
        {
            ViewBag.GalleryId = new SelectList(db.Galleries, "Id", "Name");
            return View();
        }

        // POST: GalleryItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Describtion,MediaUrl,LinkUrl,GalleryId")] GalleryItem galleryItem,HttpPostedFileBase file)
        {
            galleryItem.DateTime = DateTime.Now;
            if (file != null && file.ContentLength > 0)
            {
                var filename = galleryItem.Name;
                var imageName = Regex.Replace(filename, " ","-");
                var directory = Server.MapPath("~/Uploads/Gallery/");
                Directory.CreateDirectory(directory);
                var fileType = Path.GetExtension(file.FileName);
                var imageUrl = imageName + fileType;
                var path = Path.Combine(Server.MapPath("~/Uploads/Gallery"), imageUrl);
                file.SaveAs(path);
                galleryItem.MediaUrl = "/Uploads/Gallery/" + imageUrl;

                if (ModelState.IsValid)
                {
                    db.GalleryItems.Add(galleryItem);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError("","فایل عکس را پیوست کنید.");

            ViewBag.GalleryId = new SelectList(db.Galleries, "Id", "Name", galleryItem.GalleryId);
            return View(galleryItem);
        }

        // GET: GalleryItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GalleryItem galleryItem = db.GalleryItems.Find(id);
            if (galleryItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.GalleryId = new SelectList(db.Galleries, "Id", "Name", galleryItem.GalleryId);
            return View(galleryItem);
        }

        // POST: GalleryItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Describtion,MediaUrl,LinkUrl,DateTime,GalleryId")] GalleryItem galleryItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(galleryItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GalleryId = new SelectList(db.Galleries, "Id", "Name", galleryItem.GalleryId);
            return View(galleryItem);
        }

        // GET: GalleryItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GalleryItem galleryItem = db.GalleryItems.Find(id);
            if (galleryItem == null)
            {
                return HttpNotFound();
            }
            return View(galleryItem);
        }

        // POST: GalleryItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GalleryItem galleryItem = db.GalleryItems.Find(id);
            db.GalleryItems.Remove(galleryItem);
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
