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

namespace SinglePageCMS.Controllers
{
    public class SliderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Slider
        public ActionResult Index()
        {
            return View(db.Sliders.ToList());
        }

        // GET: Slider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // GET: Slider/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ImageUrl,Title,CaptionImg,LinkUrl")] Slider slider, HttpPostedFileBase imageBack, HttpPostedFileBase imageFront)
        {
            var exist = db.Sliders.FirstOrDefault(x => x.Title == slider.Title);
            if (exist != null)
            {
                ModelState.AddModelError("", "نام اسلاید را تغییر دهید.");
                return View(slider);
            }
            var imageName = slider.Title;

            if (imageBack != null && imageBack.ContentLength > 0)
            {
                var directory = Server.MapPath("~/Uploads/Slider/MainImage/");
                Directory.CreateDirectory(directory);
                var fileType = Path.GetExtension(imageBack.FileName);
                var imageUrl = imageName + fileType;
                var path = Path.Combine(Server.MapPath("~/Uploads/Slider/MainImage"), imageUrl);
                imageBack.SaveAs(path);
                slider.ImageUrl = "/Uploads/Slider/MainImage/" + imageUrl;


                if (imageFront != null && imageFront.ContentLength > 0)
                {
                    var directory1 = Server.MapPath("~/Uploads/Slider/Thumbnails/");
                    Directory.CreateDirectory(directory1);
                    var fileType1 = Path.GetExtension(imageBack.FileName);
                    var imageUrl1 = imageName + fileType1;
                    var path1 = Path.Combine(Server.MapPath("~/Uploads/Slider/Thumbnails"), imageUrl1);
                    imageFront.SaveAs(path1);
                    slider.CaptionImg = "/Uploads/Slider/Thumbnails/" + imageUrl;
                }
                if (ModelState.IsValid)
                {
                    db.Sliders.Add(slider);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError("", "عکسی را برای اسلاید انتخاب کنید.");
            return View(slider);
        }

        // GET: Slider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Slider/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ImageUrl,Title,CaptionImg,LinkUrl")] Slider slider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        // GET: Slider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Slider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = db.Sliders.Find(id);
            db.Sliders.Remove(slider);
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
