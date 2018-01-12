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
    public class empleadoesController : Controller
    {
        private bd_supermercadoEntities2 db = new bd_supermercadoEntities2();

        // GET: empleadoes
        public ActionResult Index()
        {
            var empleado = db.empleado.Include(e => e.cargo_laboral).Include(e => e.persona).Include(e => e.sucursal);
            return View(empleado.ToList());
        }

        // GET: empleadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: empleadoes/Create
        public ActionResult Create()
        {
            ViewBag.ID_CARGO_LABORAL_EMPLEADO = new SelectList(db.cargo_laboral, "ID_CARGO_LABORAL", "CARGO_LABORAL1");
            ViewBag.PERSONA_ID_PERSONA = new SelectList(db.persona, "ID_PERSONA", "PRIMER_NOMBRE_PERSONA");
            ViewBag.ID_SUCURSAL_EMPLEADO = new SelectList(db.sucursal, "ID_SUCURSAL", "NOMBRE_SUCURSAL");
            return View();
        }

        // POST: empleadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_EMPLEADO,FECHA_CONTRATACION_EMPLEADO,HORAS_LABORALES_MENSUALES_EMPLEADO,ID_CARGO_LABORAL_EMPLEADO,ID_SUCURSAL_EMPLEADO,PERSONA_ID_PERSONA")] empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CARGO_LABORAL_EMPLEADO = new SelectList(db.cargo_laboral, "ID_CARGO_LABORAL", "CARGO_LABORAL1", empleado.ID_CARGO_LABORAL_EMPLEADO);
            ViewBag.PERSONA_ID_PERSONA = new SelectList(db.persona, "ID_PERSONA", "PRIMER_NOMBRE_PERSONA", empleado.PERSONA_ID_PERSONA);
            ViewBag.ID_SUCURSAL_EMPLEADO = new SelectList(db.sucursal, "ID_SUCURSAL", "NOMBRE_SUCURSAL", empleado.ID_SUCURSAL_EMPLEADO);
            return View(empleado);
        }

        // GET: empleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CARGO_LABORAL_EMPLEADO = new SelectList(db.cargo_laboral, "ID_CARGO_LABORAL", "CARGO_LABORAL1", empleado.ID_CARGO_LABORAL_EMPLEADO);
            ViewBag.PERSONA_ID_PERSONA = new SelectList(db.persona, "ID_PERSONA", "PRIMER_NOMBRE_PERSONA", empleado.PERSONA_ID_PERSONA);
            ViewBag.ID_SUCURSAL_EMPLEADO = new SelectList(db.sucursal, "ID_SUCURSAL", "NOMBRE_SUCURSAL", empleado.ID_SUCURSAL_EMPLEADO);
            return View(empleado);
        }

        // POST: empleadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_EMPLEADO,FECHA_CONTRATACION_EMPLEADO,HORAS_LABORALES_MENSUALES_EMPLEADO,ID_CARGO_LABORAL_EMPLEADO,ID_SUCURSAL_EMPLEADO,PERSONA_ID_PERSONA")] empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CARGO_LABORAL_EMPLEADO = new SelectList(db.cargo_laboral, "ID_CARGO_LABORAL", "CARGO_LABORAL1", empleado.ID_CARGO_LABORAL_EMPLEADO);
            ViewBag.PERSONA_ID_PERSONA = new SelectList(db.persona, "ID_PERSONA", "PRIMER_NOMBRE_PERSONA", empleado.PERSONA_ID_PERSONA);
            ViewBag.ID_SUCURSAL_EMPLEADO = new SelectList(db.sucursal, "ID_SUCURSAL", "NOMBRE_SUCURSAL", empleado.ID_SUCURSAL_EMPLEADO);
            return View(empleado);
        }

        // GET: empleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            empleado empleado = db.empleado.Find(id);
            db.empleado.Remove(empleado);
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
