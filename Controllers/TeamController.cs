using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RocStudiosMVCProject.Models;

namespace RocStudiosMVCProject.Controllers
{
    public class TeamController : Controller
    {
        context ct = new context();
        // GET: Team
        public ActionResult Index()
        {
            var team = ct.teams.ToList();  

            return View(team);
        }
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, Team team)
        {

            var teams = ct.teams.Add(team);

            teams.TeamMemEngName = team.TeamMemEngName;
            teams.TeamMemArName = team.TeamMemArName;
            teams.TeamMemEngJob = team.TeamMemEngJob;
            teams.TeamMemArJob = team.TeamMemArJob;
            string imgName = Path.GetFileName(file.FileName);
            string imgext = Path.GetExtension(imgName);
            string imgPath = Path.Combine(Server.MapPath("~/public/Img/Team"), imgName);
            file.SaveAs(imgPath);

            teams.TeamMemImge = imgName;
            teams.TeamMemImgPath = imgPath;


            ct.SaveChanges();
            return RedirectToAction("Index", "Team");
        }
        [HttpPost]
        public ActionResult Delete(Team team)
        {
            var teams = ct.teams.Single(a => a.id == team.id);
            string oldImgPath = Path.Combine(Server.MapPath("~/public/Img/Team"), teams.TeamMemImge);
            FileInfo fi = new FileInfo(oldImgPath);
            if (fi != null)
            {
                fi.Delete();
            }
            var teams2 = ct.teams.Remove(teams);
            ct.SaveChanges();
            return RedirectToAction("Index", "Team");
        }
    }
}