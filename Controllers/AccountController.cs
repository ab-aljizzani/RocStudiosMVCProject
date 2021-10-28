using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RocStudiosMVCProject.Models;
namespace RocStudiosMVCProject.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        context ct = new context();
        public ActionResult Index()
        {
            var account = ct.accounts.ToList();
            return View(account);
        }
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Account acc)
        {
            if (!ModelState.IsValid)
            {
                return View("New");
            }
            var account = ct.accounts.Add(acc);
            account.firstName = acc.firstName;
            account.lastName = acc.lastName;
            account.email = acc.email;
            account.password = acc.password;
            account.conFirmPass = acc.conFirmPass;
            ct.SaveChanges();
            return RedirectToAction("Index", "Account");
        }
        public ActionResult Edit(int id)
        {
            var account = ct.accounts.Single(a => a.id == id);

            return View(account);
        }
        [HttpPost]
        public ActionResult Edit(Account acc)
        {

            var account = ct.accounts.Single(a => a.id == acc.id);
            if (acc.id == 0)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View("Edit");
                }
                account.firstName = acc.firstName;
                account.lastName = acc.lastName;
                account.email = acc.email;
                account.password = acc.password;
                account.conFirmPass = acc.conFirmPass;
            }
            ct.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(Account acc)
        {
            var account = ct.accounts.Single(a => a.id == acc.id);
            var account2 = ct.accounts.Remove(account);
            ct.SaveChanges();
            return RedirectToAction("Index", "Account");
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Account acc,string ReturnUrl)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}
            var account = ct.accounts.SingleOrDefault(a => a.email == acc.email && a.password == acc.password);
            if (account == null)
            {
                return View("Login", acc);
            }
            else
            {
                FormsAuthentication.SetAuthCookie(acc.email,false);
                if(ReturnUrl == null)
                { ReturnUrl = "/Home"; }
                return Redirect(ReturnUrl);
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Account");
        }
        public ActionResult ResetPassword()
        {
            return View();
        }
    }
}