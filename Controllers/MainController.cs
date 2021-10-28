using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using RocStudiosMVCProject.Models;
using RocStudiosMVCProject.ViewModels;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Threading;
using System.Globalization;

namespace RocStudiosMVCProject.Controllers
{
    [AllowAnonymous]
    public class MainController : Controller
    {
        context ct = new context();
        // GET: Main
        public ActionResult Index(string lang = "en")
        {
            if(!string.IsNullOrEmpty(lang))
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            }
            HttpCookie cookie = new HttpCookie(name: "Lang");
            cookie.Value = lang;
            Response.Cookies.Add(cookie);
            Session["lang"] = lang;
            AllModels am = new AllModels()
            {
                about = ct.abouts.ToList(),
                portfolio = ct.ports.ToList(),
                services = ct.servs.ToList(),
                team = ct.teams.ToList(),
                client = ct.clis.ToList()
        };
            
            return View(am);
        }
        public ActionResult Order(int id, string lang = "en")
        {
            if (!string.IsNullOrEmpty(lang))
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            }
            HttpCookie cookie = new HttpCookie(name: "Lang");
            cookie.Value = lang;
            Response.Cookies.Add(cookie);
            Session["lang"] = lang;
            var serv = ct.servs.Single(a => a.id == id);
            AllModels am = new AllModels() { dbserv = serv };
            return View(am);
        }
        [HttpPost]
        public ActionResult Order(Order ord, AllModels all)
        {
            //try
            //{
            DateTime dt = DateTime.Now;
            var order = ct.orders.Add(all.dborder);
            order.ServId = all.dbserv.id.ToString();
            order.OrderCase = ord.OrderCase1;
            order.OrderDate = DateTime.Now.ToLongDateString() ;
            var ChickEmail = ct.orders.Count(c => c.CustomerEmail == order.CustomerEmail && c.OrderCase == order.OrderCase1);
            if (ChickEmail >= 2)

            {
                if (Session["lang"].ToString() == "en")
                {
                    ViewBag.messageEng = ord.OrderErrorEng;
                    ViewBag.messageAr = null;
                }
                else
                {
                    ViewBag.messageAr = ord.OrderErrorAr;
                    ViewBag.messageEng = null;
                    Session["mes"] = ord.OrderErrorAr;
                }
                return View("Order", all);
            }

            else
            {
                ct.SaveChanges();
                sendMail(order.CustomerEmail, order.OrderCase);
                return RedirectToAction("OrderSuccess", "Main", new { id = order.id, lang = Session["lang"].ToString() });
            }
            //}
            //catch
            //{
            //    if (Session["lang"].ToString() == "en")
            //    {
            //        ViewBag.messageEng = ord.OrderErrorEng;
            //        ViewBag.messageAr = null;
            //    }
            //    else
            //    {
            //        ViewBag.messageAr = ord.OrderErrorAr;
            //        ViewBag.messageEng = null;
            //        Session["mes"] = ord.OrderErrorAr;
            //    }
            //    return RedirectToAction("Order", new { id=ord.id,lang=Session["lang"].ToString()});
            //}

        }
        public ActionResult OrderSuccess(int id, string lang = "en")
        {
            if (!string.IsNullOrEmpty(lang))
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            }
            HttpCookie cookie = new HttpCookie(name: "Lang");
            cookie.Value = lang;
            Response.Cookies.Add(cookie);
            Session["lang"] = lang;
            var ord = ct.orders.Single(a => a.id == id);
            return View(ord);
        }
        protected void sendMail(string email, string Ordercase)
        {
            using (MailMessage mail = new MailMessage())
            {
                var fromMail = System.Configuration.ConfigurationManager.AppSettings["sendGmail"].ToString();
                var fromMailPass = System.Configuration.ConfigurationManager.AppSettings["sendGmailPass"].ToString();
                var toMail = new MailAddress(email);
                mail.From = new MailAddress(fromMail);
                mail.To.Add(toMail);
                mail.CC.Add(new MailAddress(fromMail));
                mail.Subject = "تم استلام طلبك بنجاح";
                mail.Body = "<h2>عزيزي العميل تم استلام طلبك بنجاح وسيتم تنفيذ الطلب والتواصل معك بأسرع وقت ممكن</h2> <br /> <h3>حالة طلبك هي :</h3> <br /> <h4>"+ Ordercase + "</h4>";
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(fromMail, fromMailPass);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    var messageShow = "Likn Has Been Sent To your Email";
                    ViewBag.Message = messageShow;
                }
            }

        }
    }
}