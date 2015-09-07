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
    public class ContentController : Controller
    {

        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Article(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.Contents.Include(x => x.Category).FirstOrDefault(x => x.Slug == id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
    }
}