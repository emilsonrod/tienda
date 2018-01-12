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
    public class productoesController : Controller
    {
        private bd_supermercadoEntities2 db = new bd_supermercadoEntities2();

        // GET: productoes
        public ActionResult Index()
        {
            var producto = db.producto.Include(p => p.sucursal).Include(p => p.tipo_producto);
            return View(producto.ToList());
        }

        // GET: productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: productoes/Create
        public ActionResult Create()
        {
            ViewBag.ID_SUCURSAL_PRODUCTO = new SelectList(db.sucursal, "ID_SUCURSAL", "NOMBRE_SUCURSAL");
            ViewBag.ID_TIPO_PRODUCTO = new SelectList(db.tipo_producto, "ID_TIPO_PRODUCTO", "NOMBRE_TIPO_PRODUCTO");
            return View();
        }

        // POST: productoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PRODUCTO,NOMBRE_PRODUCTO,FECHA_ELABORACION_PRODUCTO,FECHA_VENCIMIENTO_PRODUCTO,COMPRA_PRODUCTO,VENTA_PRODUCTO,CANTIDAD_PRODUCTO,DESCRIPCION_PRODUCTO,ID_TIPO_PRODUCTO,ID_SUCURSAL_PRODUCTO,Codigo_Producto")] producto producto)
        {
            if (ModelState.IsValid)
            {
                db.producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_SUCURSAL_PRODUCTO = new SelectList(db.sucursal, "ID_SUCURSAL", "NOMBRE_SUCURSAL", producto.ID_SUCURSAL_PRODUCTO);
            ViewBag.ID_TIPO_PRODUCTO = new SelectList(db.tipo_producto, "ID_TIPO_PRODUCTO", "NOMBRE_TIPO_PRODUCTO", producto.ID_TIPO_PRODUCTO);
            return View(producto);
        }

        // GET: productoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_SUCURSAL_PRODUCTO = new SelectList(db.sucursal, "ID_SUCURSAL", "NOMBRE_SUCURSAL", producto.ID_SUCURSAL_PRODUCTO);
            ViewBag.ID_TIPO_PRODUCTO = new SelectList(db.tipo_producto, "ID_TIPO_PRODUCTO", "NOMBRE_TIPO_PRODUCTO", producto.ID_TIPO_PRODUCTO);
            return View(producto);
        }

        // POST: productoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PRODUCTO,NOMBRE_PRODUCTO,FECHA_ELABORACION_PRODUCTO,FECHA_VENCIMIENTO_PRODUCTO,COMPRA_PRODUCTO,VENTA_PRODUCTO,CANTIDAD_PRODUCTO,DESCRIPCION_PRODUCTO,ID_TIPO_PRODUCTO,ID_SUCURSAL_PRODUCTO,Codigo_Producto")] producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_SUCURSAL_PRODUCTO = new SelectList(db.sucursal, "ID_SUCURSAL", "NOMBRE_SUCURSAL", producto.ID_SUCURSAL_PRODUCTO);
            ViewBag.ID_TIPO_PRODUCTO = new SelectList(db.tipo_producto, "ID_TIPO_PRODUCTO", "NOMBRE_TIPO_PRODUCTO", producto.ID_TIPO_PRODUCTO);
            return View(producto);
        }

        // GET: productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            producto producto = db.producto.Find(id);
            db.producto.Remove(producto);
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
        [HttpPost]
        public ActionResult BuscarProducto(string idProducto)
        {
            IEnumerable<producto> producto = db.producto.Where(p => p.CODIGO_PRODUCTO.Equals(idProducto));
            return PartialView("_partialListProductos", producto.ToList());
        }
    }
}
