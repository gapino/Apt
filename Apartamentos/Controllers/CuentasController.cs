using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Apartamentos.Models;

namespace Apartamentos.Controllers
{
    public class CuentasController : Controller
    {
        //        private AptContext db = new AptContext();

        //        // GET: Cuentas
        //        public async Task<ActionResult> Index()
        //        {
        //            var cuentas = db.Cuentas.Include(c => c.AlugueHistory).Include(c => c.Apt);
        //            return View(await cuentas.ToListAsync());
        //        }

        //        // GET: Cuentas/Details/5
        //        public async Task<ActionResult> Details(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //            }
        //            Cuentas cuentas = await db.Cuentas.FindAsync(id);
        //            if (cuentas == null)
        //            {
        //                return HttpNotFound();
        //            }
        //            return View(cuentas);
        //        }

        //        // GET: Cuentas/Create
        //        public ActionResult Create()
        //        {
        //            ViewBag.AIdentificador = new SelectList(db.AlugueHistory, "AIdentificador", "Descripcion");
        //            ViewBag.AptsIdentificador = new SelectList(db.Apt, "AptsIdentificador", "Descripcion");
        //            return View();
        //        }

        //        // POST: Cuentas/Create
        //        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public async Task<ActionResult> CreateConta( Cuentas cuentas)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                db.Cuentas.Add(cuentas);
        //                await db.SaveChangesAsync();

        //            }
        //            return PartialView();
        //        }

        //        // GET: Cuentas/Edit/5
        //        public async Task<ActionResult> Edit(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //            }
        //            Cuentas cuentas = await db.Cuentas.FindAsync(id);
        //            if (cuentas == null)
        //            {
        //                return HttpNotFound();
        //            }
        //            ViewBag.AIdentificador = new SelectList(db.AlugueHistory, "AIdentificador", "Descripcion", cuentas.AIdentificador);
        //            ViewBag.AptsIdentificador = new SelectList(db.Apt, "AptsIdentificador", "Descripcion", cuentas.AptsIdentificador);
        //            return View(cuentas);
        //        }

        //        // POST: Cuentas/Edit/5
        //        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public async Task<ActionResult> Edit([Bind(Include = "CuentasID,Tipo,Monto,fecha,AptsIdentificador,AIdentificador")] Cuentas cuentas)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                db.Entry(cuentas).State = EntityState.Modified;
        //                await db.SaveChangesAsync();
        //                return RedirectToAction("Index");
        //            }
        //            ViewBag.AIdentificador = new SelectList(db.AlugueHistory, "AIdentificador", "Descripcion", cuentas.AIdentificador);
        //            ViewBag.AptsIdentificador = new SelectList(db.Apt, "AptsIdentificador", "Descripcion", cuentas.AptsIdentificador);
        //            return View(cuentas);
        //        }

        //        // GET: Cuentas/Delete/5
        //        public async Task<ActionResult> Delete(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //            }
        //            Cuentas cuentas = await db.Cuentas.FindAsync(id);
        //            if (cuentas == null)
        //            {
        //                return HttpNotFound();
        //            }
        //            return View(cuentas);
        //        }

        //        // POST: Cuentas/Delete/5
        //        [HttpPost, ActionName("Delete")]
        //        [ValidateAntiForgeryToken]
        //        public async Task<ActionResult> DeleteConfirmed(int id)
        //        {
        //            Cuentas cuentas = await db.Cuentas.FindAsync(id);
        //            db.Cuentas.Remove(cuentas);
        //            await db.SaveChangesAsync();
        //            return RedirectToAction("Index");
        //        }

        //        protected override void Dispose(bool disposing)
        //        {
        //            if (disposing)
        //            {
        //                db.Dispose();
        //            }
        //            base.Dispose(disposing);
        //        }
    }
}
