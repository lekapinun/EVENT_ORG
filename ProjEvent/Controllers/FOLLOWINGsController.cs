using System;
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
    public class FOLLOWINGsController : Controller
    {
        private Entities db = new Entities();

        // GET: FOLLOWINGs
        public async Task<ActionResult> Index()
        {
            var fOLLOWINGs = db.FOLLOWINGs.Include(f => f.MEMBER).Include(f => f.MEMBER1);
            return View(await fOLLOWINGs.ToListAsync());
        }

        // GET: FOLLOWINGs/Details/5
        public async Task<ActionResult> Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FOLLOWING fOLLOWING = await db.FOLLOWINGs.FindAsync(id);
            if (fOLLOWING == null)
            {
                return HttpNotFound();
            }
            return View(fOLLOWING);
        }

        // GET: FOLLOWINGs/Create
        public ActionResult Create()
        {
            ViewBag.MEMBER_ID = new SelectList(db.MEMBERs, "MEMBER_ID", "USERNAME");
            ViewBag.FOLLOWING_ID = new SelectList(db.MEMBERs, "MEMBER_ID", "USERNAME");
            return View();
        }

        // POST: FOLLOWINGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MEMBER_ID,FOLLOWING_ID,HISTORY")] FOLLOWING fOLLOWING)
        {
            if (ModelState.IsValid)
            {
                db.FOLLOWINGs.Add(fOLLOWING);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MEMBER_ID = new SelectList(db.MEMBERs, "MEMBER_ID", "USERNAME", fOLLOWING.MEMBER_ID);
            ViewBag.FOLLOWING_ID = new SelectList(db.MEMBERs, "MEMBER_ID", "USERNAME", fOLLOWING.FOLLOWING_ID);
            return View(fOLLOWING);
        }

        // GET: FOLLOWINGs/Edit/5
        public async Task<ActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FOLLOWING fOLLOWING = await db.FOLLOWINGs.FindAsync(id);
            if (fOLLOWING == null)
            {
                return HttpNotFound();
            }
            ViewBag.MEMBER_ID = new SelectList(db.MEMBERs, "MEMBER_ID", "USERNAME", fOLLOWING.MEMBER_ID);
            ViewBag.FOLLOWING_ID = new SelectList(db.MEMBERs, "MEMBER_ID", "USERNAME", fOLLOWING.FOLLOWING_ID);
            return View(fOLLOWING);
        }

        // POST: FOLLOWINGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MEMBER_ID,FOLLOWING_ID,HISTORY")] FOLLOWING fOLLOWING)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fOLLOWING).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MEMBER_ID = new SelectList(db.MEMBERs, "MEMBER_ID", "USERNAME", fOLLOWING.MEMBER_ID);
            ViewBag.FOLLOWING_ID = new SelectList(db.MEMBERs, "MEMBER_ID", "USERNAME", fOLLOWING.FOLLOWING_ID);
            return View(fOLLOWING);
        }

        // GET: FOLLOWINGs/Delete/5
        public async Task<ActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FOLLOWING fOLLOWING = await db.FOLLOWINGs.FindAsync(id);
            if (fOLLOWING == null)
            {
                return HttpNotFound();
            }
            return View(fOLLOWING);
        }

        // POST: FOLLOWINGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(short id)
        {
            FOLLOWING fOLLOWING = await db.FOLLOWINGs.FindAsync(id);
            db.FOLLOWINGs.Remove(fOLLOWING);
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
