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
    public class tipo_usuarioController : Controller
    {
        private bd_supermercadoEntities2 db = new bd_supermercadoEntities2();

        // GET: tipo_usuario
        public ActionResult Index()
        {
            return View(db.tipo_usuario.ToList());
        }

        // GET: tipo_usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_usuario tipo_usuario = db.tipo_usuario.Find(id);
            if (tipo_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tipo_usuario);
        }

        // GET: tipo_usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipo_usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TIPO_USUARIO,DESCRIPCION_TIO_USUARIO")] tipo_usuario tipo_usuario)
        {
            if (ModelState.IsValid)
            {
                db.tipo_usuario.Add(tipo_usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_usuario);
        }

        // GET: tipo_usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_usuario tipo_usuario = db.tipo_usuario.Find(id);
            if (tipo_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tipo_usuario);
        }

        // POST: tipo_usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TIPO_USUARIO,DESCRIPCION_TIO_USUARIO")] tipo_usuario tipo_usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_usuario);
        }

        // GET: tipo_usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_usuario tipo_usuario = db.tipo_usuario.Find(id);
            if (tipo_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tipo_usuario);
        }

        // POST: tipo_usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_usuario tipo_usuario = db.tipo_usuario.Find(id);
            db.tipo_usuario.Remove(tipo_usuario);
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
