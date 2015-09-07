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
    public class IndexAboutsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: IndexAbouts
        public ActionResult Index()
        {
            return View(db.IndexAbouts.ToList());
        }

        // GET: IndexAbouts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndexAbout indexAbout = db.IndexAbouts.Find(id);
            if (indexAbout == null)
            {
                return HttpNotFound();
            }
            return View(indexAbout);
        }

        // GET: IndexAbouts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IndexAbouts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Position,ShortDescribtion,LongDescribtion")] IndexAbout indexAbout, HttpPostedFileBase rightImage, HttpPostedFileBase userImage)
        {
            if (rightImage != null && rightImage.ContentLength > 0)
            {
                if (userImage == null || userImage.ContentLength == 0)
                {
                    ModelState.AddModelError("", "وجود عکس الزامیست");
                    return View(indexAbout);
                }

                //Saving the Files
                var fileName = indexAbout.Name+"-"+indexAbout.Position;
                var imageName = Regex.Replace(fileName, " ", "-");
                var directory = Server.MapPath("~/Uploads/About/Back/");
                Directory.CreateDirectory(directory);
                var fileType = Path.GetExtension(rightImage.FileName);
                var imageUrl = imageName + fileType;
                var path = Path.Combine(Server.MapPath("~/Uploads/About/Back"), imageUrl);
                rightImage.SaveAs(path);
                indexAbout.RightImageUrl = "/Uploads/About/Back/" + imageUrl;

                var directory1 = Server.MapPath("~/Uploads/About/Users/");
                Directory.CreateDirectory(directory1);
                var fileType1 = Path.GetExtension(userImage.FileName);
                var imageUrl1 = imageName + fileType1;
                var path1 = Path.Combine(Server.MapPath("~/Uploads/About/Users"), imageUrl1);
                userImage.SaveAs(path1);
                indexAbout.UserImageUrl = "/Uploads/About/Users/" + imageUrl1;

                //endregionFor Saving Files
                if (ModelState.IsValid)
                {
                    db.IndexAbouts.Add(indexAbout);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError("", "وجود عکس الزامیست");
            return View(indexAbout);
        }

        // GET: IndexAbouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndexAbout indexAbout = db.IndexAbouts.Find(id);
            if (indexAbout == null)
            {
                return HttpNotFound();
            }
            return View(indexAbout);
        }

        // POST: IndexAbouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Position,ShortDescribtion,LongDescribtion,UserImageUrl,RightImageUrl")] IndexAbout indexAbout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indexAbout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(indexAbout);
        }

        // GET: IndexAbouts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndexAbout indexAbout = db.IndexAbouts.Find(id);
            if (indexAbout == null)
            {
                return HttpNotFound();
            }
            return View(indexAbout);
        }

        // POST: IndexAbouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IndexAbout indexAbout = db.IndexAbouts.Find(id);
            db.IndexAbouts.Remove(indexAbout);
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
