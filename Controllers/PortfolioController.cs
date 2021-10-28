using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RocStudiosMVCProject.Models;

namespace RocStudiosMVCProject.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        context ct = new context();
        public ActionResult Index()
        {
            var porto = ct.ports.ToList();
            return View(porto);
        }
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, Portfolio port)
        {

            var porto = ct.ports.Add(port);

            string imgName = Path.GetFileName(file.FileName);
            string imgext = Path.GetExtension(imgName);
            string imgPath = Path.Combine(Server.MapPath("~/public/Img/portofolio"), imgName);
            file.SaveAs(imgPath);

            porto.PortImgName = imgName;
            porto.PortImgPath = imgPath;


            ct.SaveChanges();
            return RedirectToAction("Index", "Portfolio");
        }

        [HttpPost]
        public ActionResult Delete(Portfolio port)
        {
            var porto = ct.ports.Single(a => a.id == port.id);
            string oldImgPath = Path.Combine(Server.MapPath("~/public/Img/portofolio"), porto.PortImgName);
            FileInfo fi = new FileInfo(oldImgPath);
            if (fi != null)
            {
                // System.IO.File.Delete(Server.MapPath(oldImgPath));
                fi.Delete();
            }
            var porto2 = ct.ports.Remove(porto);
            ct.SaveChanges();
            return RedirectToAction("Index", "Portfolio");
        }

    }
}