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
    public class DailyStatusDetailController : Controller
    {
        private VirtualScrumEntities db = new VirtualScrumEntities();

        // GET: /DailyStatusDetail/
        public ActionResult Index()
        {
            var dailystatusdetail = db.DailyStatusDetail.Include(d => d.DailyStatus);
            return View(dailystatusdetail.ToList());
        }

        // GET: /DailyStatusDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyStatusDetail dailystatusdetail = db.DailyStatusDetail.Find(id);
            if (dailystatusdetail == null)
            {
                return HttpNotFound();
            }
            return View(dailystatusdetail);
        }

        // GET: /DailyStatusDetail/Create
        public ActionResult Create()
        {
            ViewBag.DailyStatusDetailsId = new SelectList(db.DailyStatus, "DailyStatusId", "UserName");
            return View();
        }

        // POST: /DailyStatusDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="DailyStatusDetailsId,DidYesterday,DoToday,BlockingIssue")] DailyStatusDetail dailystatusdetail)
        {
            if (ModelState.IsValid)
            {
                db.DailyStatusDetail.Add(dailystatusdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DailyStatusDetailsId = new SelectList(db.DailyStatus, "DailyStatusId", "UserName", dailystatusdetail.DailyStatusDetailsId);
            return View(dailystatusdetail);
        }

        // GET: /DailyStatusDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyStatusDetail dailystatusdetail = db.DailyStatusDetail.Find(id);
            if (dailystatusdetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.DailyStatusDetailsId = new SelectList(db.DailyStatus, "DailyStatusId", "UserName", dailystatusdetail.DailyStatusDetailsId);
            return View(dailystatusdetail);
        }

        // POST: /DailyStatusDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DailyStatusDetailsId,DidYesterday,DoToday,BlockingIssue")] DailyStatusDetail dailystatusdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dailystatusdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DailyStatusDetailsId = new SelectList(db.DailyStatus, "DailyStatusId", "UserName", dailystatusdetail.DailyStatusDetailsId);
            return View(dailystatusdetail);
        }

        // GET: /DailyStatusDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyStatusDetail dailystatusdetail = db.DailyStatusDetail.Find(id);
            if (dailystatusdetail == null)
            {
                return HttpNotFound();
            }
            return View(dailystatusdetail);
        }

        // POST: /DailyStatusDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DailyStatusDetail dailystatusdetail = db.DailyStatusDetail.Find(id);
            db.DailyStatusDetail.Remove(dailystatusdetail);
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
