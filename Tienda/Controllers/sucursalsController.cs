using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tienda.Models;

namespace Tienda.Controllers
{
    public class sucursalsController : Controller
    {
        private bd_supermercadoEntities2 db = new bd_supermercadoEntities2();

        // GET: sucursals
        public ActionResult Index()
        {
            var sucursal = db.sucursal.Include(s => s.ciudad);
            return View(sucursal.ToList());
        }

        // GET: sucursals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sucursal sucursal = db.sucursal.Find(id);
            if (sucursal == null)
            {
                return HttpNotFound();
            }
            return View(sucursal);
        }

        // GET: sucursals/Create
        public ActionResult Create()
        {
            ViewBag.ID_CIUDAD_SUCURSAL = new SelectList(db.ciudad, "ID_CIUDAD", "NOMBRE_CIUDAD");
            return View();
        }

        // POST: sucursals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SUCURSAL,NOMBRE_SUCURSAL,ID_CIUDAD_SUCURSAL")] sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                db.sucursal.Add(sucursal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CIUDAD_SUCURSAL = new SelectList(db.ciudad, "ID_CIUDAD", "NOMBRE_CIUDAD", sucursal.ID_CIUDAD_SUCURSAL);
            return View(sucursal);
        }

        // GET: sucursals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sucursal sucursal = db.sucursal.Find(id);
            if (sucursal == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CIUDAD_SUCURSAL = new SelectList(db.ciudad, "ID_CIUDAD", "NOMBRE_CIUDAD", sucursal.ID_CIUDAD_SUCURSAL);
            return View(sucursal);
        }

        // POST: sucursals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SUCURSAL,NOMBRE_SUCURSAL,ID_CIUDAD_SUCURSAL")] sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sucursal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CIUDAD_SUCURSAL = new SelectList(db.ciudad, "ID_CIUDAD", "NOMBRE_CIUDAD", sucursal.ID_CIUDAD_SUCURSAL);
            return View(sucursal);
        }

        // GET: sucursals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sucursal sucursal = db.sucursal.Find(id);
            if (sucursal == null)
            {
                return HttpNotFound();
            }
            return View(sucursal);
        }

        // POST: sucursals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sucursal sucursal = db.sucursal.Find(id);
            db.sucursal.Remove(sucursal);
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
