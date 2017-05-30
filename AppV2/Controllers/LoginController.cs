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
    public class LoginController : Controller
    {


        // GET: Login
        public ActionResult Index()
        {
            Session["usuario"] = null;
            if (Session["malInicio"] != null)
            {
                if ((bool)Session["malInicio"])
                {
                    ViewBag.mensaje = "No se han podido validar sus credenciales";
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario cuenta)
        {
            LogicAcceso logic = new LogicAcceso();
            Session.Timeout = 1440;
            Session["usuario"] =logic.Login(cuenta.usuario,cuenta.password);
            if (Session["usuario"] == null)
            {
                Session["malInicio"] = true;
                return RedirectToAction("Index", "Login");
            }
            else {
                return RedirectToAction("PorSede", "Presupuesto");
            }
          
        }

        public ActionResult Logout()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Logout(int idUsuario)
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Configuracion()
        {
            if (Session["usuario"] != null)
            {
                LogicAcceso logic = new LogicAcceso();
                List<Perfil> rpta= logic.getPerfiles();
                if (rpta != null)
                {
                    return View(rpta);
                }else
                {

                    return RedirectToAction("Index", "Login");
                }

            }
            else {
                return RedirectToAction("Index", "Login");
            }

        }

        public ActionResult getAccesosDePerfil(int idPerfil) {
           
                LogicAcceso logic = new LogicAcceso();
                List<Acceso> rpta = logic.getAccesos();
                List<Acceso> rpta2 = logic.getAccesosDePerfil(idPerfil);
            if (rpta != null )
            {
                ViewBag.AccesosPerfil = rpta2;
                ViewBag.idPerfil = idPerfil;
                return PartialView(rpta);
            }
            
            return PartialView();


        }

        public ActionResult MostrarCrearPerfil() {
            
            return PartialView();

        }

        public ActionResult CrearPerfil(string nombre, string codPerfil) {
            LogicAcceso login = new LogicAcceso();
           int rpta= login.crearPrefil(nombre,codPerfil);

            return PartialView(rpta);
        }

        public ActionResult EliminarPerfil(string codPerfil) {
            LogicAcceso login = new LogicAcceso();
            int rpta = login.EliminarPerfil(codPerfil);

            return PartialView(rpta);

        }

        public ActionResult GuardarAccesos(string codPerfil,string accesos)
        {
            LogicAcceso login = new LogicAcceso();
            int rpta = login.GuardarAccesos(codPerfil, accesos);
            ViewBag.idPerfil = codPerfil;
            return PartialView(rpta);

        }

    }
}