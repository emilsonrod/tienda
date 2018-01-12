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
    public class usuariosController : Controller
    {
        private bd_supermercadoEntities2 db = new bd_supermercadoEntities2();

        // GET: usuarios
        public ActionResult Index()
        {
            var usuario = db.usuario.Include(u => u.persona).Include(u => u.tipo_usuario);
            return View(usuario.ToList());
        }

        // GET: usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: usuarios/Create
        public ActionResult Create()
        {
            ViewBag.ID_PERSONA_USUARIO = new SelectList(db.persona, "ID_PERSONA", "PRIMER_NOMBRE_PERSONA");
            ViewBag.ID_TIPO_USUARIO = new SelectList(db.tipo_usuario, "ID_TIPO_USUARIO", "DESCRIPCION_TIO_USUARIO");
            return View();
        }

        // POST: usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_USUARIO,NOMBRE_USUARIO,CONTRASENA_USUARIO,ID_TIPO_USUARIO,ID_PERSONA_USUARIO")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PERSONA_USUARIO = new SelectList(db.persona, "ID_PERSONA", "PRIMER_NOMBRE_PERSONA", usuario.ID_PERSONA_USUARIO);
            ViewBag.ID_TIPO_USUARIO = new SelectList(db.tipo_usuario, "ID_TIPO_USUARIO", "DESCRIPCION_TIO_USUARIO", usuario.ID_TIPO_USUARIO);
            return View(usuario);
        }

        // GET: usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PERSONA_USUARIO = new SelectList(db.persona, "ID_PERSONA", "PRIMER_NOMBRE_PERSONA", usuario.ID_PERSONA_USUARIO);
            ViewBag.ID_TIPO_USUARIO = new SelectList(db.tipo_usuario, "ID_TIPO_USUARIO", "DESCRIPCION_TIO_USUARIO", usuario.ID_TIPO_USUARIO);
            return View(usuario);
        }

        // POST: usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_USUARIO,NOMBRE_USUARIO,CONTRASENA_USUARIO,ID_TIPO_USUARIO,ID_PERSONA_USUARIO")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PERSONA_USUARIO = new SelectList(db.persona, "ID_PERSONA", "PRIMER_NOMBRE_PERSONA", usuario.ID_PERSONA_USUARIO);
            ViewBag.ID_TIPO_USUARIO = new SelectList(db.tipo_usuario, "ID_TIPO_USUARIO", "DESCRIPCION_TIO_USUARIO", usuario.ID_TIPO_USUARIO);
            return View(usuario);
        }

        // GET: usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usuario usuario = db.usuario.Find(id);
            db.usuario.Remove(usuario);
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
