using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProyectoFinalTADP.Permisos;

namespace ProyectoFinalTADP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [PermisosTipoUsuario(Entidades.Enumerables.TipoUsuario.Admin)]

        public ActionResult GestionUsuarios()
            {
                return View();
            }


            public ActionResult CerrarSesion()
        {
            Session["Usuario"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}