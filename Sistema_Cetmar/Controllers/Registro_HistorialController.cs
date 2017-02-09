using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sistema_Cetmar.Models;

namespace Sistema_Cetmar.Controllers
{
    public class Registro_HistorialController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Registro_Historial
        public ActionResult Index()
        {
            return View(db.registorHistorial.ToList());
        }

        // GET: Registro_Historial/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro_Historial registro_Historial = db.registorHistorial.Find(id);
            if (registro_Historial == null)
            {
                return HttpNotFound();
            }
            return View(registro_Historial);
        }

        // GET: Registro_Historial/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registro_Historial/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "registroHistorialID,registroHistorialnota,registroHistorialFecha,registroHistorialCanalizacion,expedianteID")] Registro_Historial registro_Historial)
        {
            if (ModelState.IsValid)
            {
                db.registorHistorial.Add(registro_Historial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registro_Historial);
        }

        // GET: Registro_Historial/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro_Historial registro_Historial = db.registorHistorial.Find(id);
            if (registro_Historial == null)
            {
                return HttpNotFound();
            }
            return View(registro_Historial);
        }

        // POST: Registro_Historial/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "registroHistorialID,registroHistorialnota,registroHistorialFecha,registroHistorialCanalizacion,expedianteID")] Registro_Historial registro_Historial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registro_Historial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registro_Historial);
        }

        // GET: Registro_Historial/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro_Historial registro_Historial = db.registorHistorial.Find(id);
            if (registro_Historial == null)
            {
                return HttpNotFound();
            }
            return View(registro_Historial);
        }

        // POST: Registro_Historial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registro_Historial registro_Historial = db.registorHistorial.Find(id);
            db.registorHistorial.Remove(registro_Historial);
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
