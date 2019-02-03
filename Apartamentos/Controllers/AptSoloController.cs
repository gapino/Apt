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
using Apartamentos.Clases;

namespace Apartamentos.Controllers
{
    public class AptSoloController : Controller
    {
        private AptContext db = new AptContext();

        // GET: AptSolo
        public async Task<ActionResult> Index()
        {
            return View(await db.AptSolo.ToListAsync());
        }

        // GET: AptSolo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptSolo aptSolo = await db.AptSolo.FindAsync(id);
            if (aptSolo == null)
            {
                return HttpNotFound();
            }
            return View(aptSolo);
        }

        // GET: AptSolo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AptSolo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(string Descripcion, string Precio, HttpPostedFileBase Foto1, HttpPostedFileBase Foto2, HttpPostedFileBase Foto3)
        {
            var aptSolo = new AptSolo();
            var pic1 = string.Empty;
            var pic2 = string.Empty;
            var pic3 = string.Empty;
            var folder = "~/Content/apt";

            if (Descripcion.Length > 0)
            {
                if (Foto1 != null)
                {
                    pic1 = FileUpload.UploadFoto(Foto1, folder);
                    pic1 = string.Format("{0}/{1}", folder, pic1);
                }

                if (Foto2 != null)
                {
                    pic2 = FileUpload.UploadFoto(Foto2, folder);
                    pic2 = string.Format("{0}/{1}", folder, pic2);
                }

                if (Foto3 != null)
                {
                    pic3 = FileUpload.UploadFoto(Foto3, folder);
                    pic3 = string.Format("{0}/{1}", folder, pic3);
                }
                aptSolo.Descripcion = Descripcion;
                aptSolo.Precio = Int32.Parse(Precio);
                aptSolo.Alugado = false;
                aptSolo.Foto1 = pic1;
                aptSolo.Foto2 = pic2;
                aptSolo.Foto3 = pic3;
                db.AptSolo.Add(aptSolo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(aptSolo);
        }

        // GET: AptSolo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aptSolo = await db.AptSolo.FindAsync(id);
            if (aptSolo == null)
            {
                return HttpNotFound();
            }
            return View(aptSolo);
        }

        // POST: AptSolo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int Id, string Descripcion, string Precio, HttpPostedFileBase Foto1, HttpPostedFileBase Foto2, HttpPostedFileBase Foto3)
        {
            var aptSolo = await db.AptSolo.FindAsync(Id);
            var apt = await db.Apt.FindAsync(Id.ToString());

            var folder = "~/Content/apt";

            if (Descripcion.Length > 0)
            {
                if (Foto1 != null)
                {
                    var pic1 = FileUpload.UploadFoto(Foto1, folder);
                    pic1 = string.Format("{0}/{1}", folder, pic1);
                    aptSolo.Foto1 = pic1;
                    if (apt != null)
                    {
                        apt.Foto1 = pic1;
                    }
                }

                if (Foto2 != null)
                {
                    var pic2 = FileUpload.UploadFoto(Foto2, folder);
                    pic2 = string.Format("{0}/{1}", folder, pic2);
                    aptSolo.Foto2 = pic2;
                    if (apt != null)
                    {
                        apt.Foto2 = pic2;
                    }
                }

                if (Foto3 != null)
                {
                    var pic3 = FileUpload.UploadFoto(Foto3, folder);
                    pic3 = string.Format("{0}/{1}", folder, pic3);
                    aptSolo.Foto3 = pic3;
                    if (apt != null)
                    {
                        apt.Foto3 = pic3;
                    }
                }
                aptSolo.AptSoloID = Id;
                aptSolo.Descripcion = Descripcion;
                aptSolo.Precio = Int32.Parse(Precio);

                if (apt != null)
                {
                    apt.Descripcion = Descripcion;
                    apt.Precio = Int32.Parse(Precio);
                    db.Entry(apt).State = EntityState.Modified;
                }

                db.Entry(aptSolo).State = EntityState.Modified;

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(aptSolo);
        }

        // GET: AptSolo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptSolo apt = await db.AptSolo.FindAsync(id);
            if (apt == null)
            {
                return HttpNotFound();
            }
            else
            {

                db.AptSolo.Remove(apt);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }

    }
}
