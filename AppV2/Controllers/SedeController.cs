using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppV2.Models;
using LogicAccess;
using Entidades;

namespace AppV2.Controllers
{
    public class SedeController : Controller
    {
        // GET: Sede
        public ActionResult Index()
        {
            LogicSede log = new LogicSede();
            List<Sede> sedes = log.getSedes();
            List<ViewModelSede> sedesView = new List<ViewModelSede>();
            foreach (Sede sede in sedes) {
                ViewModelSede sedeView = new ViewModelSede();
                sedeView.codSede = sede.codSede;
                sedeView.desSede = sede.desSede;
                sedesView.Add(sedeView);
            }                     

            return View(sedesView);
        }

        [HttpGet]
        public ActionResult Create() {

            return View();
        }
        [HttpPost]
        public ActionResult Create(ViewModelSede sede) {
            LogicSede log = new LogicSede();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id) {

            ViewModelSede sede = new ViewModelSede();

            if (id != 0)
            {
                LogicSede log = new LogicSede();

                Sede E_sede = new Sede();
                E_sede.codSede = id;

                Sede E_sedeRpta = new Sede();
                E_sedeRpta = log.buscarSede(E_sede);

                sede.codSede = E_sedeRpta.codSede;
                sede.desSede = E_sedeRpta.desSede;
            }
            

            return View(sede);
        }




    }
}