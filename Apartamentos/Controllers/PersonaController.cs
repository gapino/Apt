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
    public class PersonaController : Controller
    {
        private AptContext db;


        public PersonaController()
        {
            db = new AptContext();



        }

        public async Task<ActionResult> Index(int? cambio)
        {
            return View(await db.Persona.ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = await db.Persona.FindAsync(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(string Nombre, string Rg, string Cpf, string Telefone, string Email)
        {
            var persona = new Persona();
            if (Nombre.Length > 0)
            {


                persona.Nombre = Nombre;
                persona.Rg = Int32.Parse(Rg);
                persona.Cpf = Int64.Parse(Cpf);
                persona.Telefone = Int32.Parse(Telefone);
                persona.Email = Email;

                db.Persona.Add(persona);
                await db.SaveChangesAsync();
                return Redirect("/Persona/Index");
            }

            return View(persona);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = await db.Persona.FindAsync(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int Id, string Nombre, string Rg, string Cpf, string Telefone, string Email)
        {
            var persona = new Persona();

            if (Nombre.Length > 0)
            {
                persona.PersonaID = Id;
                persona.Nombre = Nombre;
                persona.Rg = Int32.Parse(Rg);
                persona.Cpf = Int64.Parse(Cpf);
                persona.Telefone = Int32.Parse(Telefone);
                persona.Email = Email;

                db.Entry(persona).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(persona);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = await db.Persona.FindAsync(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            else
            {

                db.Persona.Remove(persona);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }

    }
}
