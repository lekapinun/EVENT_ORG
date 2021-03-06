﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjEvent.Models;

namespace ProjEvent.Controllers
{
    public class EVENTsController : Controller
    {
        private Entities db = new Entities();

        // GET: EVENTs
        public async Task<ActionResult> Index()
        {
            var eVENTs = db.EVENTs.Include(e => e.PROMOTE_E);
            return View(await eVENTs.ToListAsync());
        }

        // GET: EVENTs/Details/5
        public async Task<ActionResult> Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVENT eVENT = await db.EVENTs.FindAsync(id);
            if (eVENT == null)
            {
                return HttpNotFound();
            }
            return View(eVENT);
        }

        // GET: EVENTs/Create
        public ActionResult Create()
        {
            ViewBag.PROMOTE_E_ID = new SelectList(db.PROMOTE_E, "PROMOTE_ID", "TARGET_GENDER");
            ViewBag.LOCATION_NAME = new SelectList(db.LOCATIONs, "LOCATION_NAME", "LOCATION_NAME");
            return View();
        }

        // POST: EVENTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EVENT_ID,EVENT_NAME,CATEGORY,DETAIL,PICTURE,VIDEO,TIME_START_E,TIME_END_E,CONDITION_MIN_AGE,CONDITION_MAX_AGE,CONDITION_SEX,SOLD_OUT_SEAT,MAX_SEAT,PRICE,PROMOTE_E_ID,Event_location,S_DATE,E_DATE,S_TIME,E_TIME")] EVENT eVENT)
        {
            if (ModelState.IsValid)
            {
                eVENT.EVENT_ID = (short)(db.EVENTs.Count() + 1);

                eVENT.Owner_member = Session["username"].ToString();
                var owner_mem = db.MEMBERs.Where(a => a.USERNAME.Equals(eVENT.Owner_member)).FirstOrDefault();
                eVENT.MEMBERs1.Add(owner_mem);

                var location = db.LOCATIONs.Where(a => a.LOCATION_NAME.Equals(eVENT.Event_location)).FirstOrDefault();
                eVENT.LOCATIONs.Add(location);

                eVENT.TIME_START_E = eVENT.S_DATE.Add(eVENT.S_TIME);
                eVENT.TIME_END_E = eVENT.S_DATE.Add(eVENT.E_TIME);

                eVENT.SOLD_OUT_SEAT = 0;

                db.EVENTs.Add(eVENT);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PROMOTE_E_ID = new SelectList(db.PROMOTE_E, "PROMOTE_ID", "TARGET_GENDER", eVENT.PROMOTE_E_ID);
            return View(eVENT);
        }

        // GET: EVENTs/Edit/5
        public async Task<ActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVENT eVENT = await db.EVENTs.FindAsync(id);
            if (eVENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.PROMOTE_E_ID = new SelectList(db.PROMOTE_E, "PROMOTE_ID", "TARGET_GENDER", eVENT.PROMOTE_E_ID);
            return View(eVENT);
        }

        // POST: EVENTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EVENT_ID,EVENT_NAME,CATEGORY,DETAIL,PICTURE,VIDEO,TIME_START_E,TIME_END_E,CONDITION_MIN_AGE,CONDITION_MAX_AGE,CONDITION_SEX,SOLD_OUT_SEAT,MAX_SEAT,PRICE,PROMOTE_E_ID")] EVENT eVENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eVENT).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PROMOTE_E_ID = new SelectList(db.PROMOTE_E, "PROMOTE_ID", "TARGET_GENDER", eVENT.PROMOTE_E_ID);
            return View(eVENT);
        }

        // GET: EVENTs/Delete/5
        public async Task<ActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVENT eVENT = await db.EVENTs.FindAsync(id);
            if (eVENT == null)
            {
                return HttpNotFound();
            }
            return View(eVENT);
        }

        // POST: EVENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(short id)
        {
            EVENT eVENT = await db.EVENTs.FindAsync(id);
            db.EVENTs.Remove(eVENT);
            await db.SaveChangesAsync();
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

        public List<SelectListItem> Show_Location()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in db.LOCATIONs)
            {
                list.Add(new SelectListItem { Text = item.LOCATION_NAME, Value = item.LOCATION_NAME });
            }
            return list;
        }

        public async Task<ActionResult> EVENT()
        {
            var eVENTs = db.EVENTs;
            return View(await eVENTs.ToListAsync());
        }
    }
}
