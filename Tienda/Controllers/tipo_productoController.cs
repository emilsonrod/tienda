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
    public class tipo_productoController : Controller
    {
        private bd_supermercadoEntities2 db = new bd_supermercadoEntities2();

        // GET: tipo_producto
        public ActionResult Index()
        {
            return View(db.tipo_producto.ToList());
        }

        // GET: tipo_producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_producto tipo_producto = db.tipo_producto.Find(id);
            if (tipo_producto == null)
            {
                return HttpNotFound();
            }
            return View(tipo_producto);
        }

        // GET: tipo_producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipo_producto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TIPO_PRODUCTO,NOMBRE_TIPO_PRODUCTO,DESCRIPCION_TIPO_PRODUCTO")] tipo_producto tipo_producto)
        {
            if (ModelState.IsValid)
            {
                db.tipo_producto.Add(tipo_producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_producto);
        }

        // GET: tipo_producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_producto tipo_producto = db.tipo_producto.Find(id);
            if (tipo_producto == null)
            {
                return HttpNotFound();
            }
            return View(tipo_producto);
        }

        // POST: tipo_producto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TIPO_PRODUCTO,NOMBRE_TIPO_PRODUCTO,DESCRIPCION_TIPO_PRODUCTO")] tipo_producto tipo_producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_producto);
        }

        // GET: tipo_producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_producto tipo_producto = db.tipo_producto.Find(id);
            if (tipo_producto == null)
            {
                return HttpNotFound();
            }
            return View(tipo_producto);
        }

        // POST: tipo_producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_producto tipo_producto = db.tipo_producto.Find(id);
            db.tipo_producto.Remove(tipo_producto);
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
