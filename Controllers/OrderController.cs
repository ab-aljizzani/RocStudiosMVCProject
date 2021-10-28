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


namespace RocStudiosMVCProject.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        context ct = new context();
        public ActionResult Index()
        {
            var condition = ct.orders.ToList();
            return View(condition);
        }
        public ActionResult Edit(int id)
        {
            var order = ct.orders.Single(a => a.id == id);

            return View(order);
        }
        [HttpPost]
        public ActionResult Edit(Order ord)
        {

            var order = ct.orders.Single(a => a.id == ord.id);
            if (ord.id == 0)
            {
                return HttpNotFound();
            }
            else
            {
                order.OrderCase = ord.OrderCase;
            }
            ct.SaveChanges();
            sendMail(order.CustomerEmail,order.OrderCase);
            return RedirectToAction("Index");
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
                mail.Subject = "حالة طلبك";
                mail.Body = "<h2>عزيزي العميل تم تعديل حالة طلبك بنجاح </h2> <br /> <h3>حالة طلبك هي :</h3> <br /> <h4>" + Ordercase + "</h4>";
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(fromMail, fromMailPass);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }

        }
    }
}