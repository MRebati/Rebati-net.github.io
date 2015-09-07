using System;
using System.Net;
using System.Web.Mvc;
using SinglePageCMS.Models;
using System.Linq;

namespace SinglePageCMS.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Search(string search)
        {
            var blogPost = from m in db.Blogs select m;
            var contents = from m in db.Contents select m;
            if (!String.IsNullOrEmpty(search))
            {
                blogPost = blogPost.Where(x => x.ContentData.Contains(search) || x.Title.Contains(search));
                return View(blogPost);
            }
            return View("NoResultFound");
        }

        public ActionResult ContactUs()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ContactUs(ContactUs model)
        {
            if (ModelState.IsValid)
            {
                db.Contact.Add(model);
                db.SaveChanges();
            }
            else
            {
                ModelState.AddModelError("", "ارسال پیام با خطا مواجه شد. لطفا دوباره سعی کنید.");
            }
            return PartialView();
        }

        public ActionResult ContactInfo()
        {
            return PartialView();
        }

        public ActionResult Menu()
        {
            var model = db.Menus.ToList();
            return PartialView(model);
        }

        public ActionResult Slider()
        {
            var model = db.Sliders.ToList();
            return PartialView(model);
        }

        public ActionResult IndexAbout()
        {
            var model = db.IndexAbouts.ToList();
            return PartialView(model);
        }

        public ActionResult Gallery()
        {
            var model = db.Galleries.ToList();
            return PartialView(model);
        }

        public ActionResult IndexContent()
        {
            var model = db.IndexContents.ToList();
            return PartialView(model);
        }

        public ActionResult Map()
        {
            return PartialView();
        }

        public ActionResult IndexSocial()
        {
            return PartialView();
        }

        public ActionResult IndexContactForm()
        {
            return PartialView();
        }

        public ActionResult LastPosts()
        {
            return PartialView();
        }

        public ActionResult Header(int id)
        {
            if (id != null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.Contents.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return PartialView(model);
        }
    }
}