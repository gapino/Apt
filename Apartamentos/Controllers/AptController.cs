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
    public class AptController : Controller
    {
        private AptContext db = new AptContext();

        // GET: Apt
        public async Task<ActionResult> Index(int? id)
        {
            if (id != null)
            {
                var persona = await db.Persona.FindAsync(id);

                ViewBag.nomePersona = persona.Nombre;

                ViewBag.idPersona = id;
            }

            var aptLibres = db.AptSolo.SqlQuery("select * from dbo.AptSoloes where dbo.AptSoloes.Alugado = 0;");

            return View(await aptLibres.ToListAsync());
        }
        public async Task<ActionResult> Index1()
        {
            var aptLibres = db.Apt.SqlQuery("select * from dbo.Apts");

            return View(await aptLibres.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Cuentas(Cuentas cuentas)
        {
            if (ModelState.IsValid)
            {
                db.Cuentas.Add(cuentas);
                await db.SaveChangesAsync();
               
            }
            var apt = await db.Apt.FindAsync(cuentas.AptsIdentificador);
            return PartialView(apt);
        }


        // GET: Apt/Details/5
        [HttpPost]
        public async Task<ActionResult> Details(int? idApt)
        {
            if (idApt == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apt apt = await db.Apt.FindAsync(idApt.ToString());
            Persona persona = await db.Persona.FindAsync(apt.PersonaID);

            ViewBag.objPersona = persona;
            ViewBag.fecha = DateTime.Now.ToShortDateString();
            if (apt == null)
            {
                return HttpNotFound();
            }
            return View(apt);
        }

        // GET: Apt/Create
        public async Task<ActionResult> Create(int? idPersona, int idApt)
        {
            var apt = await db.AptSolo.FindAsync(idApt);
            var aptAlugado = new Apt();

            if (idPersona != null)
            {
                aptAlugado.AptsIdentificador = apt.AptSoloID.ToString();
                aptAlugado.PersonaID = (int)idPersona;
                ViewBag.PersonaID = aptAlugado.PersonaID;
                var person = new Persona();
                person = await db.Persona.FindAsync(idPersona);
                ViewBag.PersonaName = person.Nombre;
                aptAlugado.Descripcion = apt.Descripcion;
                aptAlugado.Precio = apt.Precio;
                aptAlugado.Foto1 = apt.Foto1;
                aptAlugado.Foto2 = apt.Foto2;
                aptAlugado.Foto3 = apt.Foto3;
                ViewBag.LlegoId = true;
                aptAlugado.FechaInicio = DateTime.Now.ToShortDateString();

                return View(aptAlugado);
            }
            else
            {
                aptAlugado.AptsIdentificador = apt.AptSoloID.ToString();
                aptAlugado.Descripcion = apt.Descripcion;
                aptAlugado.Precio = apt.Precio;
                aptAlugado.Foto1 = apt.Foto1;
                aptAlugado.Foto2 = apt.Foto2;
                aptAlugado.Foto3 = apt.Foto3;
                aptAlugado.FechaInicio = DateTime.Now.ToShortDateString();
                ViewBag.PersonaID = new SelectList(db.Persona, "PersonaID", "Nombre");
                return View(aptAlugado);
            }
        }

        // POST: Apt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Apt apt)
        {
            if (ModelState.IsValid)
            {
                var aptSolo = await db.AptSolo.FindAsync(int.Parse(apt.AptsIdentificador));
               
                apt.Foto1 = aptSolo.Foto1;
                apt.Foto2 = aptSolo.Foto2;
                apt.Foto3 = aptSolo.Foto3;
                db.Apt.Add(apt);


                aptSolo.Alugado = true;
                db.Entry(aptSolo).State = EntityState.Modified;

                await db.SaveChangesAsync();
                return RedirectToAction("Index1");
            }

            ViewBag.PersonaID = new SelectList(db.Persona, "PersonaID", "Nombre", apt.PersonaID);
            return View(apt);
        }

        // GET: Apt/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apt apt = await db.Apt.FindAsync(id);
            if (apt == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonaID = new SelectList(db.Persona, "PersonaID", "Nombre", apt.PersonaID);
            return View(apt);
        }

        // POST: Apt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AptID,Descripcion,PersonaID,Precio,Foto1,Foto2,Foto3")] Apt apt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apt).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PersonaID = new SelectList(db.Persona, "PersonaID", "Nombre", apt.PersonaID);
            return View(apt);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int? id, string fecha)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var apt = await db.Apt.FindAsync(id.ToString());
                var conta = new CuentasHistory();
                var aptHistory = new AlugueHistory
                {
                    AIdentificador = apt.AptsIdentificador,
                    Descripcion = apt.Descripcion,
                    Precio = apt.Precio,
                    PersonaID = apt.PersonaID,
                    FechaInicio = apt.FechaInicio,
                    FechaSalida = fecha,
                    Foto1 = apt.Foto1,
                    Foto2 = apt.Foto2,
                    Foto3 = apt.Foto3,
                    Persona = apt.Persona,
                    
                    
                };
                
                db.AlugueHistory.Add(aptHistory);
                MudarCuentas(apt.Cuentas);
                db.Cuentas.RemoveRange(apt.Cuentas);
                var aptSolo = await db.AptSolo.FindAsync(int.Parse(apt.AptsIdentificador));
                aptSolo.Alugado = false;
                db.Entry(aptSolo).State = EntityState.Modified;
                db.Apt.Remove(apt);
               
                await db.SaveChangesAsync();
                return RedirectToAction("Index1");
            }
        }
        public void MudarCuentas(ICollection<Cuentas> cuentas)
        {
           
            foreach (var item in cuentas)
            {
                var cuentasHistory = new CuentasHistory();
                cuentasHistory.AIdentificador = item.AptsIdentificador;
                cuentasHistory.Tipo = item.Tipo;
                cuentasHistory.Monto = item.Monto;
                cuentasHistory.fecha = item.fecha;
                db.CuentasHistory.Add(cuentasHistory);
               
            }
          
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
