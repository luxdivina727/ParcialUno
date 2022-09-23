using ParcialUno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ParcialUno.Controllers
{
    public class UsuarioController : Controller
    {
        public ViewResult Index()
        {
            return View(Data.UsuarioDAO.Listar());
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(Int64 usuarioCedula)
        {
            if(usuarioCedula == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = Data.UsuarioDAO.Obtener(usuarioCedula);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
            
        }
        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                
                    Data.UsuarioDAO.Actualizar(usuario);
                    return RedirectToAction("Index");

            }

            return View(usuario);
        }
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                Usuario _usuario = Data.UsuarioDAO.Obtener(usuario.UsuarioCedula);
                if (_usuario.UsuarioNombre != null)
                {
                    ViewBag.sms = "Existe una cédula en el sistema";
                }
                else
                {
                    Data.UsuarioDAO.Registrar(usuario);
                    return RedirectToAction("Index");
                }

            }

            return View(usuario);
        }

    }
}