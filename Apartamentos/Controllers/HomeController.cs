using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Apartamentos.Models;
using System.Threading.Tasks;

namespace Apartamentos.Controllers
{
    public class HomeController : Controller
    {
        private AptContext db;
        public HomeController()
        {
            db = new AptContext();
        }
        public async Task<ActionResult> Index()
        {
            var total1 = await db.AptSolo.ToListAsync();
            var aptOcupado = await db.AptSolo.SqlQuery("select * from dbo.AptSoloes where dbo.AptSoloes.Alugado = 1;").ToListAsync();

            ViewBag.total = total1.Count;
            ViewBag.aptOcupados = aptOcupado.Count;



            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}