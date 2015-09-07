using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace SinglePageCMS.Controllers
{
    public class TagController : Controller
    {
        // GET: Tag
        public ActionResult Index()
        {
            return HttpNotFound();
        }

        public ActionResult Show()
        {
            if (Session["Tag"] != null)
            {
                string s = Convert.ToString(Session["Tag"]);
                var items = new List<string>(s.Split(','));
                //var items = Session["Tag"].ToString().Split(',');
                ViewBag.Items = items.ToList();
            }
            return PartialView();
        }

        [HttpParamAction]
        public ActionResult Add(string item)
        {
            if (String.IsNullOrEmpty(item))
            {
                return RedirectToAction("Show");
            }
            if (Session["Tag"] != null)
            {
                Session["Tag"] += ',' + item;
            }
            else
            {
                Session["Tag"] += item;
            }
            return RedirectToAction("Show");
        }

        [HttpParamAction]
        public ActionResult Delete(string item)
        {
            if (String.IsNullOrEmpty(item))
            {
                return RedirectToAction("Show");
            }
            if (Session["Tag"].ToString().Contains(item))
            {
                string data = Session["Tag"].ToString();
                data = Regex.Replace(data,","+item, String.Empty);
                data = Regex.Replace(data,item, String.Empty);
                data = Regex.Replace(data,",,",",");
                Session["Tag"] = data;
            }
            return RedirectToAction("Show");
        }

        public ActionResult DeleteAll()
        {
            Session["Tag"] = "";
            return RedirectToAction("Show");
        }
    }
    #region Helpers

    public class HttpParamActionAttribute : ActionNameSelectorAttribute
    {
        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            if (actionName.Equals(methodInfo.Name, StringComparison.InvariantCultureIgnoreCase))
                return true;

            var request = controllerContext.RequestContext.HttpContext.Request;
            return request[methodInfo.Name] != null;
        }
    }

    #endregion
}