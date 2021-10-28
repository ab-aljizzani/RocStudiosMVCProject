using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RocStudiosMVCProject.Models;



namespace RocStudiosMVCProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        context ct = new context();

        public ActionResult Index()
        {
            var aboutData = ct.abouts.ToList();

            return View(aboutData);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var aboutData = ct.abouts.Single(a => a.id == id);

            return View(aboutData);
        }
        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase file,About about)
        {
            
            var aboutData = ct.abouts.Single(a => a.id == about.id );
            if (about.id == 0)
            {
                return HttpNotFound();
            }
            else
            {
                string imgName = Path.GetFileName(file.FileName);
                string imgext = Path.GetExtension(imgName);
                string imgPath = Path.Combine(Server.MapPath("~/public/Img/About"), imgName);
                string oldImgPath = Path.Combine(Server.MapPath("~/public/Img/About"), aboutData.aboutImg);
                FileInfo fi = new FileInfo(oldImgPath);
                if (fi != null)
                {
                   // System.IO.File.Delete(Server.MapPath(oldImgPath));
                    fi.Delete();
                }

                file.SaveAs(imgPath);

                aboutData.aboutEng = about.aboutEng;
                aboutData.aboutAr = about.aboutAr;
                aboutData.aboutImg = imgName;
                aboutData.ImgPath = imgPath;
            }
            ct.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}