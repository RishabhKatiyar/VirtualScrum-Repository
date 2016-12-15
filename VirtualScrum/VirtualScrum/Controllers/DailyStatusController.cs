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
    
    public class DailyStatusController : Controller
    {
        private VirtualScrumEntities db = new VirtualScrumEntities();

        // GET: /DailyStatus/
     
        public ActionResult Index()
        {

            var dailystatus = db.DailyStatus.Include(d => d.ScrumTeamMember);
            return View(dailystatus.ToList());
        }

        // GET: /DailyStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyStatus dailystatus = db.DailyStatus.Find(id);
            if (dailystatus == null)
            {
                return HttpNotFound();
            }
            return View(dailystatus);
        }

        // GET: /DailyStatus/Create
        public ActionResult Create()
        {
            //add list here
            DailyStatus dailystatus = new DailyStatus();

            dailystatus.Date = DateTime.Now;

            DailyStatusInfo dailystatusInfo = new DailyStatusInfo();

            var scrumTeamIdNames = from res in db.ScrumTeams select new { ScrumTeamId = res.ScrumTeamId, TeamProjectName = res.TeamProjectName };
            IList<SelectListItem> scrumTeamIdNameList = new List<SelectListItem>();
            foreach (var ob in scrumTeamIdNames)
            {
                scrumTeamIdNameList.Add(new SelectListItem { Text = ob.TeamProjectName, Value = (ob.ScrumTeamId).ToString() });
            }

            dailystatusInfo.ScrumTeamInfoList = scrumTeamIdNameList;

            ViewBag.ScrumTeamId = new SelectList(db.ScrumTeamMembers, "ScrumTeamId", "ScrumDesignation");

            var temp = new Tuple<DailyStatus, DailyStatusInfo>(dailystatus, dailystatusInfo);

            return View(temp);
        }


        // POST: /DailyStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1",Include="DailyStatusId,Date,ScrumTeamId,UserName,DidYesterday,DoToday,BlockingIssue")] DailyStatus dailystatus)
        {
            if (ModelState.IsValid)
            {
                db.DailyStatus.Add(dailystatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ScrumTeamId = new SelectList(db.ScrumTeamMembers, "ScrumTeamId", "ScrumDesignation", dailystatus.ScrumTeamId);
            return View(dailystatus);
        }

        // GET: /DailyStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyStatus dailystatus = db.DailyStatus.Find(id);
            if (dailystatus == null)
            {
                return HttpNotFound();
            }
            ViewBag.ScrumTeamId = new SelectList(db.ScrumTeamMembers, "ScrumTeamId", "ScrumDesignation", dailystatus.ScrumTeamId);
            return View(dailystatus);
        }

        // POST: /DailyStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DailyStatusId,Date,ScrumTeamId,UserName,DidYesterday,DoToday,BlockingIssue")] DailyStatus dailystatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dailystatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ScrumTeamId = new SelectList(db.ScrumTeamMembers, "ScrumTeamId", "ScrumDesignation", dailystatus.ScrumTeamId);
            return View(dailystatus);
        }

        // GET: /DailyStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyStatus dailystatus = db.DailyStatus.Find(id);
            if (dailystatus == null)
            {
                return HttpNotFound();
            }
            return View(dailystatus);
        }

        // POST: /DailyStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DailyStatus dailystatus = db.DailyStatus.Find(id);
            db.DailyStatus.Remove(dailystatus);
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
