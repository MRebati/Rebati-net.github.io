using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using GrabzIt;
using SinglePageCMS.Models;
using System.Net;
using System.Drawing;
using System.IO;

namespace SinglePageCMS.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            var persian = new PersianCalendar();
            var allInsight = db.Insights.ToList();
            DateTime week = DateTime.Now.AddDays(-7);

            var saturday = allInsight.Where(x => x.DateTime.Year == DateTime.Now.Year && x.DateTime.Month == DateTime.Now.Month && x.DateTime >= week).ToList().Where(x => x.DateTime.DayOfWeek.ToString() == DayOfWeek.Saturday.ToString()).Count();
            var sunday = allInsight.Where(x => x.DateTime.Year == DateTime.Now.Year && x.DateTime.Month == DateTime.Now.Month && x.DateTime >= week).ToList().Where(x => x.DateTime.DayOfWeek.ToString() == DayOfWeek.Sunday.ToString()).Count();
            var monday = allInsight.Where(x => x.DateTime.Year == DateTime.Now.Year && x.DateTime.Month == DateTime.Now.Month && x.DateTime >= week).ToList().Where(x => x.DateTime.DayOfWeek.ToString() == DayOfWeek.Monday.ToString()).Count();
            var tuesday = allInsight.Where(x => x.DateTime.Year == DateTime.Now.Year && x.DateTime.Month == DateTime.Now.Month && x.DateTime >= week).ToList().Where(x => x.DateTime.DayOfWeek.ToString() == DayOfWeek.Tuesday.ToString()).Count();
            var wednesday = allInsight.Where(x => x.DateTime.Year == DateTime.Now.Year && x.DateTime.Month == DateTime.Now.Month && x.DateTime >= week).ToList().Where(x => x.DateTime.DayOfWeek.ToString() == DayOfWeek.Wednesday.ToString()).Count();
            var thursday = allInsight.Where(x => x.DateTime.Year == DateTime.Now.Year && x.DateTime.Month == DateTime.Now.Month && x.DateTime >= week).ToList().Where(x => x.DateTime.DayOfWeek.ToString() == DayOfWeek.Thursday.ToString()).Count();
            var friday = allInsight.Where(x => x.DateTime.Year == DateTime.Now.Year && x.DateTime.Month == DateTime.Now.Month && x.DateTime >= week).ToList().Where(x => x.DateTime.DayOfWeek.ToString() == DayOfWeek.Friday.ToString()).Count();



            var farvardin = allInsight.Where(x => persian.GetYear(x.DateTime) == persian.GetYear(DateTime.Now) && persian.GetMonth(x.DateTime) == 1).Count();
            var ordibehesht = allInsight.Where(x => persian.GetYear(x.DateTime) == persian.GetYear(DateTime.Now) && persian.GetMonth(x.DateTime) == 2).Count();
            var khordad = allInsight.Where(x => persian.GetYear(x.DateTime) == persian.GetYear(DateTime.Now) && persian.GetMonth(x.DateTime) == 3).Count();
            var tir = allInsight.Where(x => persian.GetYear(x.DateTime) == persian.GetYear(DateTime.Now) && persian.GetMonth(x.DateTime) == 4).Count();
            var mordad = allInsight.Where(x => persian.GetYear(x.DateTime) == persian.GetYear(DateTime.Now) && persian.GetMonth(x.DateTime) == 5).Count();
            var shahrivar = allInsight.Where(x => persian.GetYear(x.DateTime) == persian.GetYear(DateTime.Now) && persian.GetMonth(x.DateTime) == 6).Count();
            var mehr = allInsight.Where(x => persian.GetYear(x.DateTime) == persian.GetYear(DateTime.Now) && persian.GetMonth(x.DateTime) == 7).Count();
            var aban = allInsight.Where(x => persian.GetYear(x.DateTime) == persian.GetYear(DateTime.Now) && persian.GetMonth(x.DateTime) == 8).Count();
            var azar = allInsight.Where(x => persian.GetYear(x.DateTime) == persian.GetYear(DateTime.Now) && persian.GetMonth(x.DateTime) == 9).Count();
            var dey = allInsight.Where(x => persian.GetYear(x.DateTime) == persian.GetYear(DateTime.Now) && persian.GetMonth(x.DateTime) == 10).Count();
            var bahman = allInsight.Where(x => persian.GetYear(x.DateTime) == persian.GetYear(DateTime.Now) && persian.GetMonth(x.DateTime) == 11).Count();
            var esfand = allInsight.Where(x => persian.GetYear(x.DateTime) == persian.GetYear(DateTime.Now) && persian.GetMonth(x.DateTime) == 12).Count();

            var h0 = allInsight.Where(x => x.DateTime.Date == DateTime.Now.Date && x.DateTime.Hour >= 0 && x.DateTime.Hour < 1).Count();
            var h1 = allInsight.Where(x => x.DateTime.Date == DateTime.Now.Date && x.DateTime.Hour >= 1 && x.DateTime.Hour < 2).Count();
            var h2 = allInsight.Where(x => x.DateTime.Date == DateTime.Now.Date && x.DateTime.Hour >= 2 && x.DateTime.Hour < 3).Count();
            var h3 = allInsight.Where(x => x.DateTime.Date == DateTime.Now.Date && x.DateTime.Hour >= 3 && x.DateTime.Hour < 4).Count();
            var h4 = allInsight.Where(x => x.DateTime.Date == DateTime.Now.Date && x.DateTime.Hour >= 4 && x.DateTime.Hour < 5).Count();
            var h5 = allInsight.Where(x => x.DateTime.Date == DateTime.Now.Date && x.DateTime.Hour >= 5 && x.DateTime.Hour < 6).Count();
            var h6 = allInsight.Where(x => x.DateTime.Date == DateTime.Now.Date && x.DateTime.Hour >= 6 && x.DateTime.Hour < 7).Count();
            var h7 = allInsight.Where(x => x.DateTime.Date == DateTime.Now.Date && x.DateTime.Hour >= 7 && x.DateTime.Hour < 8).Count();
            var h8 = allInsight.Where(x => x.DateTime.Date == DateTime.Now.Date && x.DateTime.Hour >= 8 && x.DateTime.Hour < 9).Count();
            var h9 = allInsight.Where(x => x.DateTime.Date == DateTime.Now.Date && x.DateTime.Hour >= 9 && x.DateTime.Hour < 10).Count();
            var h10 = allInsight.Where(x => x.DateTime.Date == DateTime.Now.Date && x.DateTime.Hour >= 10 && x.DateTime.Hour < 11).Count();
            var h11 = allInsight.Where(x => x.DateTime.Date == DateTime.Now.Date && x.DateTime.Hour >= 11 && x.DateTime.Hour < 12).Count();
            var h12 = allInsight.Where(x => x.DateTime.Date == DateTime.Now.Date && x.DateTime.Hour >= 12 && x.DateTime.Hour < 13).Count();
            var h13 = allInsight.Where(x => x.DateTime.Date == DateTime.Now.Date && x.DateTime.Hour >= 13 && x.DateTime.Hour < 14).Count();
            var h14 = allInsight.Where(x => x.DateTime.Date == DateTime.Now.Date && x.DateTime.Hour >= 14 && x.DateTime.Hour < 15).Count();
            var h15 = allInsight.Where(x => x.DateTime.Date == DateTime.Now.Date && x.DateTime.Hour >= 15 && x.DateTime.Hour < 16).Count();
            var h16 = allInsight.Where(x => x.DateTime.Date == DateTime.Now.Date && x.DateTime.Hour >= 16 && x.DateTime.Hour < 17).Count();
            var h17 = allInsight.Where(x => x.DateTime.Date == DateTime.Now.Date && x.DateTime.Hour >= 17 && x.DateTime.Hour < 18).Count();
            var h18 = allInsight.Where(x => x.DateTime.Date == DateTime.Now.Date && x.DateTime.Hour >= 18 && x.DateTime.Hour < 19).Count();
            var h19 = allInsight.Where(x => x.DateTime.Date == DateTime.Now.Date && x.DateTime.Hour >= 19 && x.DateTime.Hour < 20).Count();
            var h20 = allInsight.Where(x => x.DateTime.Date == DateTime.Now.Date && x.DateTime.Hour >= 20 && x.DateTime.Hour < 21).Count();
            var h21 = allInsight.Where(x => x.DateTime.Date == DateTime.Now.Date && x.DateTime.Hour >= 21 && x.DateTime.Hour < 22).Count();
            var h22 = allInsight.Where(x => x.DateTime.Date == DateTime.Now.Date && x.DateTime.Hour >= 22 && x.DateTime.Hour < 23).Count();
            var h23 = allInsight.Where(x => x.DateTime.Date == DateTime.Now.Date && x.DateTime.Hour >= 23).Count();

            var all = allInsight.Count();
            var thisweek = allInsight.Where(insight => insight.DateTime.AddDays(7).Date >= DateTime.Now.Date).Count();
            var thismonth = allInsight.Where(insight => insight.DateTime.AddDays(30).Date >= DateTime.Now.Date).Count();



            //For Sending Data To View

            ViewBag.saturday = saturday;
            ViewBag.sunday = sunday;
            ViewBag.monday = monday;
            ViewBag.tuesday = tuesday;
            ViewBag.wednesday = wednesday;
            ViewBag.thursday = thursday;
            ViewBag.friday = friday;

            ViewBag.farvardin = farvardin;
            ViewBag.ordibehesht = ordibehesht;
            ViewBag.khordad = khordad;
            ViewBag.tir = tir;
            ViewBag.mordad = mordad;
            ViewBag.shahrivar = shahrivar;
            ViewBag.mehr = mehr;
            ViewBag.aban = aban;
            ViewBag.azar = azar;
            ViewBag.dey = dey;
            ViewBag.bahman = bahman;
            ViewBag.esfand = esfand;

            ViewBag.h0 = h0;
            ViewBag.h1 = h1;
            ViewBag.h2 = h2;
            ViewBag.h3 = h3;
            ViewBag.h4 = h4;
            ViewBag.h5 = h5;
            ViewBag.h6 = h6;
            ViewBag.h7 = h7;
            ViewBag.h8 = h8;
            ViewBag.h9 = h9;
            ViewBag.h10 = h10;
            ViewBag.h11 = h11;
            ViewBag.h12 = h12;
            ViewBag.h13 = h13;
            ViewBag.h14 = h14;
            ViewBag.h15 = h15;
            ViewBag.h16 = h16;
            ViewBag.h17 = h17;
            ViewBag.h18 = h18;
            ViewBag.h19 = h19;
            ViewBag.h20 = h20;
            ViewBag.h21 = h21;
            ViewBag.h22 = h22;
            ViewBag.h23 = h23;

            ViewBag.yesterdayh0 = allInsight.Where(x => x.DateTime.AddDays(1).Date == DateTime.Now.Date && x.DateTime.Hour >= 0 && x.DateTime.Hour < 1).Count();
            ViewBag.yesterdayh1 = allInsight.Where(x => x.DateTime.AddDays(1).Date == DateTime.Now.Date && x.DateTime.Hour >= 1 && x.DateTime.Hour < 2).Count();
            ViewBag.yesterdayh2 = allInsight.Where(x => x.DateTime.AddDays(1).Date == DateTime.Now.Date && x.DateTime.Hour >= 2 && x.DateTime.Hour < 3).Count();
            ViewBag.yesterdayh3 = allInsight.Where(x => x.DateTime.AddDays(1).Date == DateTime.Now.Date && x.DateTime.Hour >= 3 && x.DateTime.Hour < 4).Count();
            ViewBag.yesterdayh4 = allInsight.Where(x => x.DateTime.AddDays(1).Date == DateTime.Now.Date && x.DateTime.Hour >= 4 && x.DateTime.Hour < 5).Count();
            ViewBag.yesterdayh5 = allInsight.Where(x => x.DateTime.AddDays(1).Date == DateTime.Now.Date && x.DateTime.Hour >= 5 && x.DateTime.Hour < 6).Count();
            ViewBag.yesterdayh6 = allInsight.Where(x => x.DateTime.AddDays(1).Date == DateTime.Now.Date && x.DateTime.Hour >= 6 && x.DateTime.Hour < 7).Count();
            ViewBag.yesterdayh7 = allInsight.Where(x => x.DateTime.AddDays(1).Date == DateTime.Now.Date && x.DateTime.Hour >= 7 && x.DateTime.Hour < 8).Count();
            ViewBag.yesterdayh8 = allInsight.Where(x => x.DateTime.AddDays(1).Date == DateTime.Now.Date && x.DateTime.Hour >= 8 && x.DateTime.Hour < 9).Count();
            ViewBag.yesterdayh9 = allInsight.Where(x => x.DateTime.AddDays(1).Date == DateTime.Now.Date && x.DateTime.Hour >= 9 && x.DateTime.Hour < 10).Count();
            ViewBag.yesterdayh10 = allInsight.Where(x => x.DateTime.AddDays(1).Date == DateTime.Now.Date && x.DateTime.Hour >= 10 && x.DateTime.Hour < 11).Count();
            ViewBag.yesterdayh11 = allInsight.Where(x => x.DateTime.AddDays(1).Date == DateTime.Now.Date && x.DateTime.Hour >= 11 && x.DateTime.Hour < 12).Count();
            ViewBag.yesterdayh12 = allInsight.Where(x => x.DateTime.AddDays(1).Date == DateTime.Now.Date && x.DateTime.Hour >= 12 && x.DateTime.Hour < 13).Count();
            ViewBag.yesterdayh13 = allInsight.Where(x => x.DateTime.AddDays(1).Date == DateTime.Now.Date && x.DateTime.Hour >= 13 && x.DateTime.Hour < 14).Count();
            ViewBag.yesterdayh14 = allInsight.Where(x => x.DateTime.AddDays(1).Date == DateTime.Now.Date && x.DateTime.Hour >= 14 && x.DateTime.Hour < 15).Count();
            ViewBag.yesterdayh15 = allInsight.Where(x => x.DateTime.AddDays(1).Date == DateTime.Now.Date && x.DateTime.Hour >= 15 && x.DateTime.Hour < 16).Count();
            ViewBag.yesterdayh16 = allInsight.Where(x => x.DateTime.AddDays(1).Date == DateTime.Now.Date && x.DateTime.Hour >= 16 && x.DateTime.Hour < 17).Count();
            ViewBag.yesterdayh17 = allInsight.Where(x => x.DateTime.AddDays(1).Date == DateTime.Now.Date && x.DateTime.Hour >= 17 && x.DateTime.Hour < 18).Count();
            ViewBag.yesterdayh18 = allInsight.Where(x => x.DateTime.AddDays(1).Date == DateTime.Now.Date && x.DateTime.Hour >= 18 && x.DateTime.Hour < 19).Count();
            ViewBag.yesterdayh19 = allInsight.Where(x => x.DateTime.AddDays(1).Date == DateTime.Now.Date && x.DateTime.Hour >= 19 && x.DateTime.Hour < 20).Count();
            ViewBag.yesterdayh20 = allInsight.Where(x => x.DateTime.AddDays(1).Date == DateTime.Now.Date && x.DateTime.Hour >= 20 && x.DateTime.Hour < 21).Count();
            ViewBag.yesterdayh21 = allInsight.Where(x => x.DateTime.AddDays(1).Date == DateTime.Now.Date && x.DateTime.Hour >= 21 && x.DateTime.Hour < 22).Count();
            ViewBag.yesterdayh22 = allInsight.Where(x => x.DateTime.AddDays(1).Date == DateTime.Now.Date && x.DateTime.Hour >= 22 && x.DateTime.Hour < 23).Count();
            ViewBag.yesterdayh23 = allInsight.Where(x => x.DateTime.AddDays(1).Date == DateTime.Now.Date && x.DateTime.Hour >= 23).Count();

            ViewBag.all = all;
            ViewBag.thisweek = thisweek;
            ViewBag.thismonth = thismonth;

            ViewBag.Title = "داشبورد";
            return View();
        }

        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult Clock()
        {
            ViewBag.Clock = ShowDateTime(DateTime.Now);
            return PartialView();
        }



        //public ActionResult GenerateImage()
        //{
        //    GrabzItClient grabzIt = GrabzItClient.Create("APPLICATION KEY", "APPLICATION SECRET");
        //    string id = grabzIt.TakePicture("http://www.google.com");
        //    bool completed = false;
        //    int attempts = 0;
        //    while (!completed && attempts <= 10)
        //    {
        //        Image image = grabzIt.GetPicture(id);
        //        if (image != null)
        //        {
        //            //string filename = url.Substring(url.IndexOf("://") + 3) + ".jpg";
        //            //image.Save(filename);
        //            completed = true;
        //        }
        //        attempts++;
        //        Thread.Sleep(1000);
        //        MediaTypeNames.Application.DoEvents();
        //    }
        //    HttpWebRequest request = HttpWebRequest.Create("http://images.websnapr.com/?size=s&url=www.google.com") as HttpWebRequest;
        //    Bitmap bitmap;
        //    FileContentResult result;

        //    using (var memStream = new System.IO.MemoryStream())
        //    {
        //        bitmap.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        //        result = this.File(memStream.GetBuffer(), "image/jpeg");
        //    }

        //    return result;
        //}

        #region Helpers
        public string ShowDateTime(DateTime date)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            var year = persianCalendar.GetYear(date);
            var month = persianCalendar.GetMonth(date);
            var day = persianCalendar.GetDayOfMonth(date);
            var dayofWeek = persianCalendar.GetDayOfWeek(date);

            string dayOfWeek = "";
            string monthOfyear = "";

            switch (dayofWeek)
            {
                case DayOfWeek.Saturday:
                    {
                        dayOfWeek = "شنبه";
                        break;
                    }
                case DayOfWeek.Sunday:
                    {
                        dayOfWeek = "یکشنبه";
                        break;
                    }
                case DayOfWeek.Monday:
                    {
                        dayOfWeek = "دوشنبه";
                        break;
                    }
                case DayOfWeek.Tuesday:
                    {
                        dayOfWeek = "سه شنبه";
                        break;
                    }
                case DayOfWeek.Wednesday:
                    {
                        dayOfWeek = "چهارشنبه";
                        break;
                    }
                case DayOfWeek.Thursday:
                    {
                        dayOfWeek = "پنجشنبه";
                        break;
                    }
                case DayOfWeek.Friday:
                    {
                        dayOfWeek = "جمعه";
                        break;
                    }

            }

            switch (month)
            {
                case 1:
                    {
                        monthOfyear = "فروردین";
                        break;
                    }
                case 2:
                    {
                        monthOfyear = "اردیبهشت";
                        break;
                    }
                case 3:
                    {
                        monthOfyear = "خرداد";
                        break;
                    }
                case 4:
                    {
                        monthOfyear = "تیر";
                        break;
                    }
                case 5:
                    {
                        monthOfyear = "مرداد";
                        break;
                    }
                case 6:
                    {
                        monthOfyear = "شهریور";
                        break;
                    }
                case 7:
                    {
                        monthOfyear = "مهر";
                        break;
                    }
                case 8:
                    {
                        monthOfyear = "آبان";
                        break;
                    }
                case 9:
                    {
                        monthOfyear = "آذر";
                        break;
                    }
                case 10:
                    {
                        monthOfyear = "دی";
                        break;
                    }
                case 11:
                    {
                        monthOfyear = "بهمن";
                        break;
                    }
                case 12:
                    {
                        monthOfyear = "اسفند";
                        break;
                    }
            }

            string text =" امروز " + dayOfWeek + "  " + day.ToString("####") + "  " + monthOfyear + "  " + year;

            return text;
        }
        #endregion
    }
}