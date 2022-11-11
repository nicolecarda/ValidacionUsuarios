using Entidades;
using Newtonsoft.Json;
using Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProyectoFinalTADP.Controllers
{
    [Authorize]

    public class UsuariosController : Controller
    {
        [HttpPost]

        public ActionResult Autenticar(Servicios.Usuarios usuario)
        {

          
                List<Servicios.Usuarios> listaUsuarios = Servicios.Usuarios.Listar();


                usuario = listaUsuarios.Where(x => x.Email == usuario.Email && x.Clave == usuario.Clave).FirstOrDefault();

                if (usuario != null)
                {
                    FormsAuthentication.SetAuthCookie(usuario.Email, false);
                    Session["Usuario"] = usuario;

                    return RedirectToAction("Index", "Home");
                }

                return View();  
            
        }

        [HttpPost]

        public JsonResult Validar(Servicios.Usuarios usuario)
        {

            Respuesta respuesta = new Respuesta();

            try
            {
                List<Servicios.Usuarios> listaUsuarios = Servicios.Usuarios.Listar();


                usuario = listaUsuarios.Where(x => x.Email == usuario.Email && x.Clave == usuario.Clave).FirstOrDefault();

                if (usuario != null)
                {
                    FormsAuthentication.SetAuthCookie(usuario.Email, false);
                    Session["Usuario"] = usuario;

                    respuesta.Codigo = (int)HttpStatusCode.OK;
                    respuesta.esCorrecto = true;
                    respuesta.Mensaje = "El usuario es válido";
                    respuesta.Objeto = listaUsuarios;

                    Session["usuario"] = usuario;
                }
                else
                {
                    respuesta.Codigo = (int)HttpStatusCode.OK;
                    respuesta.esCorrecto = false;
                    respuesta.Mensaje = "El usuario no se encuentra registrado";
                    respuesta.Objeto = null;
                }

                return Json(respuesta);

            }
            catch (Exception ex)
            {
                respuesta.Codigo = (int)HttpStatusCode.BadRequest;
                respuesta.esCorrecto = false;
                respuesta.Mensaje = "Error al validar el usuario: " + ex.Message;
                respuesta.Objeto = null;

                Session["usuario"] = new Servicios.Usuarios
                {
                    Nombre = "Ingresar",
                    Clave = " ",
                    Email = " ",
                    IdTipoUsuario = 0
                };

                return Json(respuesta);
            }


        }


        // GET: Usuarios
        public ActionResult Index()
        {
            string listUsuariosJson = new Servicios.Rest(ConfigurationManager.AppSettings["UrlServicios"] + "/Usuarios").CreateObject();
            List<Servicios.Usuarios> listUsuarios = JsonConvert.DeserializeObject<List<Servicios.Usuarios>>(listUsuariosJson);

            return View(listUsuarios);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View(new Entidades.Usuario());
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(Entidades.Usuario collection)
        {
            try
            {
                string listUsuariosJson = new Servicios.Rest(ConfigurationManager.AppSettings["UrlServicios"] + "/Usuarios", JsonConvert.SerializeObject(collection),"Post").CreateObject();
                List<Servicios.Usuarios> listUsuarios = JsonConvert.DeserializeObject<List<Servicios.Usuarios>>(listUsuariosJson);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
