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
    public class EspecialistasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Especialistas
        public ActionResult Index()
        {
            return View(db.especialistas.ToList());
        }

        // GET: Especialistas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialista especialista = db.especialistas.Find(id);
            if (especialista == null)
            {
                return HttpNotFound();
            }
            return View(especialista);
        }

        // GET: Especialistas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Especialistas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "especialistaID,especialistaRFC,especialistaNombre,especialistaApellido,especialidad,especialistaTelefono,especialistaDomicilio")] Especialista especialista)
        {
            if (ModelState.IsValid)
            {
                db.especialistas.Add(especialista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especialista);
        }

        // GET: Especialistas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialista especialista = db.especialistas.Find(id);
            if (especialista == null)
            {
                return HttpNotFound();
            }
            return View(especialista);
        }

        // POST: Especialistas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "especialistaID,especialistaRFC,especialistaNombre,especialistaApellido,especialidad,especialistaTelefono,especialistaDomicilio")] Especialista especialista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especialista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(especialista);
        }

        // GET: Especialistas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialista especialista = db.especialistas.Find(id);
            if (especialista == null)
            {
                return HttpNotFound();
            }
            return View(especialista);
        }

        // POST: Especialistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Especialista especialista = db.especialistas.Find(id);
            db.especialistas.Remove(especialista);
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
