using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SportsManagement.Models;

namespace SportsManagement.Controllers
{
    public class EventController : Controller
    {
        private sportsmanagementEntities db = new sportsmanagementEntities();

        // GET: Event
        public ActionResult Index()
        {
            return View(db.eventcompetitorresults.ToList());
        }

        // GET: Event/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventcompetitorresult eventcompetitorresult = db.eventcompetitorresults.Find(id);
            if (eventcompetitorresult == null)
            {
                return HttpNotFound();
            }
            return View(eventcompetitorresult);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Event_ID,Competitor_ID,Competitor_Position,Competitor_Medal")] eventcompetitorresult eventcompetitorresult)
        {
            if (ModelState.IsValid)
            {
                db.eventcompetitorresults.Add(eventcompetitorresult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventcompetitorresult);
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventcompetitorresult eventcompetitorresult = db.eventcompetitorresults.Find(id);
            if (eventcompetitorresult == null)
            {
                return HttpNotFound();
            }
            return View(eventcompetitorresult);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Event_ID,Competitor_ID,Competitor_Position,Competitor_Medal")] eventcompetitorresult eventcompetitorresult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventcompetitorresult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventcompetitorresult);
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventcompetitorresult eventcompetitorresult = db.eventcompetitorresults.Find(id);
            if (eventcompetitorresult == null)
            {
                return HttpNotFound();
            }
            return View(eventcompetitorresult);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            eventcompetitorresult eventcompetitorresult = db.eventcompetitorresults.Find(id);
            db.eventcompetitorresults.Remove(eventcompetitorresult);
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
