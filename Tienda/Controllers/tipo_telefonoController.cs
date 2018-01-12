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
    public class tipo_telefonoController : Controller
    {
        private bd_supermercadoEntities2 db = new bd_supermercadoEntities2();

        // GET: tipo_telefono
        public ActionResult Index()
        {
            return View(db.tipo_telefono.ToList());
        }

        // GET: tipo_telefono/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_telefono tipo_telefono = db.tipo_telefono.Find(id);
            if (tipo_telefono == null)
            {
                return HttpNotFound();
            }
            return View(tipo_telefono);
        }

        // GET: tipo_telefono/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipo_telefono/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TIPO_TELEFONO,TIPO_TELEFONO1,DESCRIPCION_TIPO_TELEFONO")] tipo_telefono tipo_telefono)
        {
            if (ModelState.IsValid)
            {
                db.tipo_telefono.Add(tipo_telefono);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_telefono);
        }

        // GET: tipo_telefono/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_telefono tipo_telefono = db.tipo_telefono.Find(id);
            if (tipo_telefono == null)
            {
                return HttpNotFound();
            }
            return View(tipo_telefono);
        }

        // POST: tipo_telefono/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TIPO_TELEFONO,TIPO_TELEFONO1,DESCRIPCION_TIPO_TELEFONO")] tipo_telefono tipo_telefono)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_telefono).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_telefono);
        }

        // GET: tipo_telefono/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_telefono tipo_telefono = db.tipo_telefono.Find(id);
            if (tipo_telefono == null)
            {
                return HttpNotFound();
            }
            return View(tipo_telefono);
        }

        // POST: tipo_telefono/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_telefono tipo_telefono = db.tipo_telefono.Find(id);
            db.tipo_telefono.Remove(tipo_telefono);
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
