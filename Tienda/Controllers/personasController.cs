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
    public class personasController : Controller
    {
        private bd_supermercadoEntities2 db = new bd_supermercadoEntities2();

        // GET: personas
        public ActionResult Index()
        {
            var persona = db.persona.Include(p => p.ciudad).Include(p => p.sexo);
            return View(persona.ToList());
        }

        // GET: personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = db.persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: personas/Create
        public ActionResult Create()
        {
            ViewBag.ID_CIUDAD_RESIDENCIA_PERSONA = new SelectList(db.ciudad, "ID_CIUDAD", "NOMBRE_CIUDAD");
            ViewBag.ID_SEXO_PERSONA = new SelectList(db.sexo, "ID_SEXO", "SEXO1");
            return View();
        }

        // POST: personas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PERSONA,PRIMER_NOMBRE_PERSONA,SEGUNDO_NOMBRE_PERSONA,PRIMER_APELLIDO_PERSONA,SEGUNDO_APELLIDO_PERSONA,FECHA_NACIMIENTO_PERSONA,NUMERO_IDENTIDAD_PERSONA,DIRECCION_RESIDENCIA_PERSONA,ID_CIUDAD_RESIDENCIA_PERSONA,ID_SEXO_PERSONA")] persona persona)
        {
            if (ModelState.IsValid)
            {
                db.persona.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CIUDAD_RESIDENCIA_PERSONA = new SelectList(db.ciudad, "ID_CIUDAD", "NOMBRE_CIUDAD", persona.ID_CIUDAD_RESIDENCIA_PERSONA);
            ViewBag.ID_SEXO_PERSONA = new SelectList(db.sexo, "ID_SEXO", "SEXO1", persona.ID_SEXO_PERSONA);
            return View(persona);
        }

        // GET: personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = db.persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CIUDAD_RESIDENCIA_PERSONA = new SelectList(db.ciudad, "ID_CIUDAD", "NOMBRE_CIUDAD", persona.ID_CIUDAD_RESIDENCIA_PERSONA);
            ViewBag.ID_SEXO_PERSONA = new SelectList(db.sexo, "ID_SEXO", "SEXO1", persona.ID_SEXO_PERSONA);
            return View(persona);
        }

        // POST: personas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PERSONA,PRIMER_NOMBRE_PERSONA,SEGUNDO_NOMBRE_PERSONA,PRIMER_APELLIDO_PERSONA,SEGUNDO_APELLIDO_PERSONA,FECHA_NACIMIENTO_PERSONA,NUMERO_IDENTIDAD_PERSONA,DIRECCION_RESIDENCIA_PERSONA,ID_CIUDAD_RESIDENCIA_PERSONA,ID_SEXO_PERSONA")] persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CIUDAD_RESIDENCIA_PERSONA = new SelectList(db.ciudad, "ID_CIUDAD", "NOMBRE_CIUDAD", persona.ID_CIUDAD_RESIDENCIA_PERSONA);
            ViewBag.ID_SEXO_PERSONA = new SelectList(db.sexo, "ID_SEXO", "SEXO1", persona.ID_SEXO_PERSONA);
            return View(persona);
        }

        // GET: personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = db.persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            persona persona = db.persona.Find(id);
            db.persona.Remove(persona);
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
