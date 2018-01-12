using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tienda.Models;

namespace Tienda.Controllers
{
    public class facturasController : Controller
    {
        private bd_supermercadoEntities2 db = new bd_supermercadoEntities2();

        // GET: facturas
        public ActionResult Index()
        {
            var factura = db.factura.Include(f => f.cliente).Include(f => f.empleado).Include(f => f.sucursal);
            return View(factura.ToList());
        }

        // GET: facturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura factura = db.factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: facturas/Create
        public ActionResult Create()
        {
            ViewBag.ID_CLIENTE_FACTURA = new SelectList(db.cliente, "ID_CLIENTE", "ID_CLIENTE");
            ViewBag.ID_EMPLEADO_FACTURA = new SelectList(db.empleado, "ID_EMPLEADO", "ID_EMPLEADO");
            ViewBag.ID_SUCURSAL_FACTURA = new SelectList(db.sucursal, "ID_SUCURSAL", "NOMBRE_SUCURSAL");
            ViewBag.FECHA_FACTURA = DateTime.Now.Date.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture); ;
            ViewBag.ListaProductos    = new SelectList(db.producto, "ID_PRODUCTO", "NOMBRE_PRODUCTO");
            return View();
        }

        // POST: facturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(factura factura)
        {
            factura.factura_producto = factura.factura_producto.Where(fp => !fp.Estado.Equals("EL")).ToList();
            if (ModelState.IsValid)
            {
                db.factura.Add(factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CLIENTE_FACTURA = new SelectList(db.cliente, "ID_CLIENTE", "ID_CLIENTE", factura.ID_CLIENTE_FACTURA);
            ViewBag.ID_EMPLEADO_FACTURA = new SelectList(db.empleado, "ID_EMPLEADO", "ID_EMPLEADO", factura.ID_EMPLEADO_FACTURA);
            ViewBag.ID_SUCURSAL_FACTURA = new SelectList(db.sucursal, "ID_SUCURSAL", "NOMBRE_SUCURSAL", factura.ID_SUCURSAL_FACTURA);
            return View(factura);
        }

        // GET: facturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura factura = db.factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CLIENTE_FACTURA = new SelectList(db.cliente, "ID_CLIENTE", "ID_CLIENTE", factura.ID_CLIENTE_FACTURA);
            ViewBag.ID_EMPLEADO_FACTURA = new SelectList(db.empleado, "ID_EMPLEADO", "ID_EMPLEADO", factura.ID_EMPLEADO_FACTURA);
            ViewBag.ID_SUCURSAL_FACTURA = new SelectList(db.sucursal, "ID_SUCURSAL", "NOMBRE_SUCURSAL", factura.ID_SUCURSAL_FACTURA);
            return View(factura);
        }

        // POST: facturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(factura factura)
        {
            if (ModelState.IsValid)
            {
                foreach (factura_producto producto in factura.factura_producto)
                {
                    if (producto.ID_FACPROD == 0)
                    {
                        db.Entry(producto).State = EntityState.Added;
                        producto.ID_FACTURA = factura.ID_FACTURA;
                    }
                    else
                        db.Entry(producto).State = EntityState.Modified;
                }
                db.Entry(factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CLIENTE_FACTURA = new SelectList(db.cliente, "ID_CLIENTE", "ID_CLIENTE", factura.ID_CLIENTE_FACTURA);
            ViewBag.ID_EMPLEADO_FACTURA = new SelectList(db.empleado, "ID_EMPLEADO", "ID_EMPLEADO", factura.ID_EMPLEADO_FACTURA);
            ViewBag.ID_SUCURSAL_FACTURA = new SelectList(db.sucursal, "ID_SUCURSAL", "NOMBRE_SUCURSAL", factura.ID_SUCURSAL_FACTURA);
            return View(factura);
        }

        // GET: facturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura factura = db.factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            factura factura = db.factura.Find(id);
            foreach (var facturaProducto in factura.factura_producto.ToList())
                db.factura_producto.Remove(facturaProducto);
            db.factura.Remove(factura);
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

        public ActionResult BuscarProducto(string idProducto, int cantidadProductos)
        {
            producto producto = db.producto.FirstOrDefault(p => p.CODIGO_PRODUCTO.Equals(idProducto));
            ViewBag.Indice = cantidadProductos.ToString();
            return PartialView("_partialDetalleVenta",producto);
        }
        [HttpPost]
        public ActionResult BuscarVentas(String fechaInicial, String fechaFinal)
        {
            DateTime fechaInicialLocal = DateTime.Parse(fechaInicial);
            DateTime fechaFinalLocal = DateTime.Parse(fechaFinal);
            return PartialView("_partialListFacturasView", db.factura.Where(v => v.FECHA_FACTURA >= fechaInicialLocal && v.FECHA_FACTURA <= fechaFinalLocal).ToList());
        }
    }
}
