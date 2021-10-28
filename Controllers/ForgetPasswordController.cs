using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using RocStudiosMVCProject.Models;


namespace RocStudiosMVCProject.Controllers
{
    public class ForgetPasswordController : Controller
    {
        context ct = new context();
        // GET: ForgetPassword
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string email)
        {
            using (context ct = new context())
            {
                var account = ct.accounts.Where(a => a.email == email).FirstOrDefault();
                if (account != null)
                {
                    string resetCode = Guid.NewGuid().ToString();
                    // sendVerifyLink(account.email, resetCode, "ResetPassword");
                    sendMail(account.email, resetCode, "ResetPassword");
                    account.code = resetCode;
                    ct.SaveChanges();
                }
                else
                {
                    var message = "Account Not Found";
                    ViewBag.message = message;
                }
            }
            return View();
        }

        private void sendVerifyLink(string email, string code, string type)
        {
            var verfiyUrl = "/ForgetPassword/" + type + "/" + code;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verfiyUrl);
            var fromMail = System.Configuration.ConfigurationManager.AppSettings["sendEmail"].ToString();
            var fromMailPass = System.Configuration.ConfigurationManager.AppSettings["sendPass"].ToString();
            MailAddress toMail = new MailAddress(email);

            string sub = "Reset Password";
            string body = "<h2>To reset Your Paswword Click On The Link .</h2><br /><a href ='" + link + "'>Reset Password</a>";

            var smtp = new SmtpClient
            {
                Host = "smtp-mail.outlook.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["sendEmail"].ToString(), System.Configuration.ConfigurationManager.AppSettings["sendPass"].ToString())
            };
            using (var message = new MailMessage(System.Configuration.ConfigurationManager.AppSettings["sendEmail"].ToString(), toMail.ToString())
            {
                Subject = sub,
                Body = body,
                IsBodyHtml = true

            })
                smtp.Send(message);
            var messageShow = "Likn Has Been Sent To your Email";
            ViewBag.Message = messageShow;


        }
        protected void sendMail(string email, string code, string type)
        {
            using (MailMessage mail = new MailMessage())
            {
                var verfiyUrl = "/ForgetPassword/" + type + "/" + code;
                var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verfiyUrl);
                var fromMail = System.Configuration.ConfigurationManager.AppSettings["sendGmail"].ToString();
                var fromMailPass = System.Configuration.ConfigurationManager.AppSettings["sendGmailPass"].ToString();
                var toMail = new MailAddress(email);
                mail.From = new MailAddress(fromMail);
                mail.To.Add(toMail);
                mail.CC.Add(new MailAddress(fromMail));
                mail.Subject = "Reset Password";
                mail.Body = "<h2>To reset Your Paswword Click On The Link .</h2><br /><a href ='" + link + "'>Reset Password</a>";
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
        public ActionResult ResetPassword(string id)
        {
            using (context ct = new context())
            {
                var account = ct.accounts.Single(a => a.code == id);
                if (account != null)
                {
                    ForgetPassword model = new ForgetPassword();
                    model.code = id;
                    return View(model);
                }
                else
                    return HttpNotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ForgetPassword model)
        {
            var message = "";


            using (context ct = new context())
            {
                var account = ct.accounts.Single(a => a.code == model.code);
                if (account != null)
                {
                    account.password = model.newPassword;
                    account.conFirmPass = model.conFirmNewPass;
                    account.code = "";
                    ct.Configuration.ValidateOnSaveEnabled = false;
                    ct.SaveChanges();
                    message = "Password Reset Successfuly";
                    ViewBag.messageSuccess = message;

                }
            }
            return RedirectToAction("Login", "Account");


        }
    }
}