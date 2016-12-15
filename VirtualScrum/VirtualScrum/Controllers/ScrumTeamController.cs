using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VirtualScrum.Models;

namespace VirtualScrum.Controllers
{
    [Authorize]
    public class ScrumTeamController : Controller
    {
        
        private VirtualScrumEntities db = new VirtualScrumEntities();

        // GET: /ScrumTeam/
      
        public ActionResult Index()
        {
            return View(db.ScrumTeams.ToList());
        }

        // GET: /ScrumTeam/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScrumTeam scrumteam = db.ScrumTeams.Find(id);
            if (scrumteam == null)
            {
                return HttpNotFound();
            }
            return View(scrumteam);
        }

        // GET: /ScrumTeam/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ScrumTeam/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ScrumTeamId,TeamProjectName,IsActive")] ScrumTeam scrumteam)
        {
            if (ModelState.IsValid)
            {
                db.ScrumTeams.Add(scrumteam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scrumteam);
        }

        // GET: /ScrumTeam/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScrumTeam scrumteam = db.ScrumTeams.Find(id);
            if (scrumteam == null)
            {
                return HttpNotFound();
            }
            return View(scrumteam);
        }

        // POST: /ScrumTeam/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ScrumTeamId,TeamProjectName,IsActive")] ScrumTeam scrumteam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scrumteam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scrumteam);
        }

        // GET: /ScrumTeam/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScrumTeam scrumteam = db.ScrumTeams.Find(id);
            if (scrumteam == null)
            {
                return HttpNotFound();
            }
            return View(scrumteam);
        }

        // POST: /ScrumTeam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScrumTeam scrumteam = db.ScrumTeams.Find(id);
            db.ScrumTeams.Remove(scrumteam);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
