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
    public class MEMBERsController : Controller
    {
        private Entities db = new Entities();

        // GET: MEMBERs
        public async Task<ActionResult> Index()
        {
            return View(await db.MEMBERs.ToListAsync());
        }

        // GET: MEMBERs/Details/5
        public async Task<ActionResult> Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBER mEMBER = await db.MEMBERs.FindAsync(id);
            if (mEMBER == null)
            {
                return HttpNotFound();
            }
            return View(mEMBER);
        }

        // GET: MEMBERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MEMBERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MEMBER_ID,NATIONAL_ID,USERNAME,PASSWORD,FNAME,LNAME,SEX,B_DATE,ADDRESS,E_MAIL,PHONE,CREDIT_CARD,URL_IMG")] MEMBER mEMBER)
        {
            if (ModelState.IsValid)
            {
                mEMBER.MEMBER_ID = (short)(db.MEMBERs.Count()+1);
                
                string[] date = mEMBER.B_DATE.Split('-');
                mEMBER.B_DATE = date[1] + '/' + date[0] + '/' + date[2];
                mEMBER.BIRTH_DATE = Convert.ToDateTime(mEMBER.B_DATE);

                db.MEMBERs.Add(mEMBER);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mEMBER);
        }

        // GET: MEMBERs/Edit/5
        public async Task<ActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBER mEMBER = await db.MEMBERs.FindAsync(id);
            if (mEMBER == null)
            {
                return HttpNotFound();
            }
            return View(mEMBER);
        }

        // POST: MEMBERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MEMBER_ID,NATIONAL_ID,USERNAME,PASSWORD,FNAME,LNAME,SEX,BIRTH_DATE,ADDRESS,E_MAIL,PHONE,CREDIT_CARD,URL_IMG")] MEMBER mEMBER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mEMBER).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mEMBER);
        }

        // GET: MEMBERs/Delete/5
        public async Task<ActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBER mEMBER = await db.MEMBERs.FindAsync(id);
            if (mEMBER == null)
            {
                return HttpNotFound();
            }
            return View(mEMBER);
        }

        // POST: MEMBERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(short id)
        {
            MEMBER mEMBER = await db.MEMBERs.FindAsync(id);
            db.MEMBERs.Remove(mEMBER);
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

        
    }
}
