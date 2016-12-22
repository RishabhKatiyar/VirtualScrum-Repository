using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualScrum.Models;

namespace VirtualScrum.Controllers
{
    public class TeamUserController : Controller
    {
        //private ScrumTeam db = new ScrumTeam();
        private VirtualScrumEntities db = new VirtualScrumEntities();
        //
        // GET: /TeamUser/
        public ActionResult Index()
        {
            //var TeamList = db.TeamProjectName; 
            //var TeamList = db.TeamProjectName;
            var TeamList = db.ScrumTeams;
            return View(TeamList);
        }

        //
        // GET: /TeamUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /TeamUser/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TeamUser/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /TeamUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /TeamUser/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /TeamUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /TeamUser/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
