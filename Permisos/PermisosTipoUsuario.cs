using Entidades.Enumerables;
using Servicios;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinalTADP.Permisos
{
    public class PermisosTipoUsuario:ActionFilterAttribute
    {
        private TipoUsuario TipoUsuario;

        public PermisosTipoUsuario(TipoUsuario _tipoUsuario)
        {
            TipoUsuario = _tipoUsuario;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(HttpContext.Current.Session != null)
            {
                if (HttpContext.Current.Session["Usuario"] != null)
                {
                    Usuarios usuario = HttpContext.Current.Session["Usuario"] as Usuarios;

                    if (usuario.TipoUsuario != this.TipoUsuario)
                    {
                        filterContext.Result = new RedirectResult("~/Home/Index");
                    }
                }

                base.OnActionExecuting(filterContext);
            }
        }

    }
}