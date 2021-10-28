using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RocStudiosMVCProject.Models;

namespace RocStudiosMVCProject.Controllers
{
    public class ClientsController : Controller
    {
        context ct = new context();
        // GET: Clients
        public ActionResult Index()
        {
            var cli = ct.clis.ToList();
            return View(cli);
        }
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, Clients clie)
        {
            if(!ModelState.IsValid)
            { return View("New"); }
            var cli = ct.clis.Add(clie);
            cli.ClientName = clie.ClientName;
            string imgName = Path.GetFileName(file.FileName);
            string imgext = Path.GetExtension(imgName);
            string imgPath = Path.Combine(Server.MapPath("~/public/Img/clients"), imgName);
            file.SaveAs(imgPath);

            cli.ClientImg = imgName;
            cli.ClientImgPath = imgPath;


            ct.SaveChanges();
            return RedirectToAction("Index", "Clients");
        }
        [HttpPost]
        public ActionResult Delete(Clients clie)
        {
            var cli = ct.clis.Single(a => a.id == clie.id);
            string oldImgPath = Path.Combine(Server.MapPath("~/public/Img/clients"), cli.ClientImg);
            FileInfo fi = new FileInfo(oldImgPath);
            if (fi != null)
            {
                // System.IO.File.Delete(Server.MapPath(oldImgPath));
                fi.Delete();
            }
            var cli2 = ct.clis.Remove(cli);
            ct.SaveChanges();
            return RedirectToAction("Index", "Clients");
        }
    }
}