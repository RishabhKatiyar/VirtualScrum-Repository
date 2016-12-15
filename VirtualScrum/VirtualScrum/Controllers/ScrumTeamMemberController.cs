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
    public class ScrumTeamMemberController : Controller
    {
        private VirtualScrumEntities db = new VirtualScrumEntities();

        // GET: /ScrumTeamMember/
        public ActionResult Index()
        {
            var scrumteammembers = db.ScrumTeamMembers.Include(s => s.ScrumTeam);
            return View(scrumteammembers.ToList());
        }

        // GET: /ScrumTeamMember/Details/5
        public ActionResult Details(int scrumTeamID, string userName)
        {
            if (scrumTeamID == null || userName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScrumTeamMember scrumteammember = db.ScrumTeamMembers.Find(scrumTeamID, userName);
            if (scrumteammember == null)
            {
                return HttpNotFound();
            }
            return View(scrumteammember);
        }

        // GET: /ScrumTeamMember/Create
        public ActionResult Create()
        {
            ViewBag.ScrumTeamId = new SelectList(db.ScrumTeams, "ScrumTeamId", "TeamProjectName");
            return View();
        }

        // POST: /ScrumTeamMember/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ScrumTeamId,UserName,isActive,ScrumDesignation")] ScrumTeamMember scrumteammember)
        {
            if (ModelState.IsValid)
            {
                db.ScrumTeamMembers.Add(scrumteammember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ScrumTeamId = new SelectList(db.ScrumTeams, "ScrumTeamId", "TeamProjectName", scrumteammember.ScrumTeamId);
            return View(scrumteammember);
        }

        // GET: /ScrumTeamMember/Edit/5
        public ActionResult Edit(int  scrumTeamID, string userName)
        {
            if (scrumTeamID == null || userName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScrumTeamMember scrumteammember = db.ScrumTeamMembers.Find(scrumTeamID, userName);
            if (scrumteammember == null)
            {
                return HttpNotFound();
            }
            ViewBag.ScrumTeamId = new SelectList(db.ScrumTeams, "ScrumTeamId", "TeamProjectName", scrumteammember.ScrumTeamId);
            return View(scrumteammember);
        }

        // POST: /ScrumTeamMember/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ScrumTeamId,UserName,isActive,ScrumDesignation")] ScrumTeamMember scrumteammember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scrumteammember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ScrumTeamId = new SelectList(db.ScrumTeams, "ScrumTeamId", "TeamProjectName", scrumteammember.ScrumTeamId);
            return View(scrumteammember);
        }

        // GET: /ScrumTeamMember/Delete/5
        public ActionResult Delete(int scrumTeamID, string userName)
        {
            if (scrumTeamID == null || userName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScrumTeamMember scrumteammember = db.ScrumTeamMembers.Find(scrumTeamID, userName);
            if (scrumteammember == null)
            {
                return HttpNotFound();
            }
            return View(scrumteammember);
        }

        // POST: /ScrumTeamMember/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int scrumTeamID, string userName)
        {
            ScrumTeamMember scrumteammember = db.ScrumTeamMembers.Find(scrumTeamID, userName);
            db.ScrumTeamMembers.Remove(scrumteammember);
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
