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
    public class telefonoesController : Controller
    {
        private bd_supermercadoEntities2 db = new bd_supermercadoEntities2();

        // GET: telefonoes
        public ActionResult Index()
        {
            var telefono = db.telefono.Include(t => t.persona).Include(t => t.tipo_telefono);
            return View(telefono.ToList());
        }

        // GET: telefonoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            telefono telefono = db.telefono.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            return View(telefono);
        }

        // GET: telefonoes/Create
        public ActionResult Create()
        {
            ViewBag.ID_PERSONA_TELEFONO = new SelectList(db.persona, "ID_PERSONA", "PRIMER_NOMBRE_PERSONA");
            ViewBag.ID_TIPO_TELEFONO = new SelectList(db.tipo_telefono, "ID_TIPO_TELEFONO", "TIPO_TELEFONO1");
            return View();
        }

        // POST: telefonoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TELEFONO,TELEFONO1,ID_TIPO_TELEFONO,ID_PERSONA_TELEFONO")] telefono telefono)
        {
            if (ModelState.IsValid)
            {
                db.telefono.Add(telefono);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PERSONA_TELEFONO = new SelectList(db.persona, "ID_PERSONA", "PRIMER_NOMBRE_PERSONA", telefono.ID_PERSONA_TELEFONO);
            ViewBag.ID_TIPO_TELEFONO = new SelectList(db.tipo_telefono, "ID_TIPO_TELEFONO", "TIPO_TELEFONO1", telefono.ID_TIPO_TELEFONO);
            return View(telefono);
        }

        // GET: telefonoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            telefono telefono = db.telefono.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PERSONA_TELEFONO = new SelectList(db.persona, "ID_PERSONA", "PRIMER_NOMBRE_PERSONA", telefono.ID_PERSONA_TELEFONO);
            ViewBag.ID_TIPO_TELEFONO = new SelectList(db.tipo_telefono, "ID_TIPO_TELEFONO", "TIPO_TELEFONO1", telefono.ID_TIPO_TELEFONO);
            return View(telefono);
        }

        // POST: telefonoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TELEFONO,TELEFONO1,ID_TIPO_TELEFONO,ID_PERSONA_TELEFONO")] telefono telefono)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefono).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PERSONA_TELEFONO = new SelectList(db.persona, "ID_PERSONA", "PRIMER_NOMBRE_PERSONA", telefono.ID_PERSONA_TELEFONO);
            ViewBag.ID_TIPO_TELEFONO = new SelectList(db.tipo_telefono, "ID_TIPO_TELEFONO", "TIPO_TELEFONO1", telefono.ID_TIPO_TELEFONO);
            return View(telefono);
        }

        // GET: telefonoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            telefono telefono = db.telefono.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            return View(telefono);
        }

        // POST: telefonoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            telefono telefono = db.telefono.Find(id);
            db.telefono.Remove(telefono);
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
