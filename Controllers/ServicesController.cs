using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RocStudiosMVCProject.Models;

namespace RocStudiosMVCProject.Controllers
{
    public class ServicesController : Controller
    {
        context ct = new context();
        // GET: Services
        public ActionResult Index()
        {
            var serv = ct.servs.ToList();
            return View(serv);
        }
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, Services ser)
        {

            var serv = ct.servs.Add(ser);

            serv.ServTitleEng = ser.ServTitleEng;
            serv.ServDescEng = ser.ServDescEng;
            serv.ServTitleAr = ser.ServTitleAr;
            serv.ServDescAr = ser.ServDescAr;

            string imgName = Path.GetFileName(file.FileName);
            string imgext = Path.GetExtension(imgName);
            string imgPath = Path.Combine(Server.MapPath("~/public/Img/Services"), imgName);
            file.SaveAs(imgPath);

            serv.ServImg = imgName;
            serv.ServImgPath = imgPath;


            ct.SaveChanges();
            return RedirectToAction("Index", "Services");
        }
        [HttpPost]
        public ActionResult Delete(Services ser)
        {
            var serv = ct.servs.Single(a => a.id == ser.id);
            string oldImgPath = Path.Combine(Server.MapPath("~/public/Img/Services"), serv.ServImg);
            FileInfo fi = new FileInfo(oldImgPath);
            if (fi != null)
            {
                // System.IO.File.Delete(Server.MapPath(oldImgPath));
                fi.Delete();
            }
            var serv2 = ct.servs.Remove(serv);
            ct.SaveChanges();
            return RedirectToAction("Index", "Services");
        }
    }
}