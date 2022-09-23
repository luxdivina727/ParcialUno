using ParcialUno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
namespace ParcialUno.Controllers
{
    public class PrestamoController : Controller
    {
        public ViewResult Index()
        {
            return View(Data.PrestamosDAO.Listar());
        }
        public ActionResult Create()
        {
            this.ViewBag.UsuarioCedula = new SelectList(Data.UsuarioDAO.Listar(), "UsuarioCedula", "UsuarioNombre");
            this.ViewBag.VideoJuegoCodigo = new SelectList(Data.VideojuegoDAO.Listar(), "VideoJuegoCodigo", "VideojuegoNombre");
            return View();
        }
        public ActionResult Edit(Int64 prestamoId)
        {
            if (prestamoId == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = Data.PrestamosDAO.Obtener(prestamoId);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);

        }
        [HttpPost]
        public ActionResult Edit(Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                prestamo.EsDevuelto = true;
                Data.PrestamosDAO.Actualizar(prestamo);
                return RedirectToAction("Index");

            }

            return View(prestamo);
        }
        [HttpPost]
        public ActionResult Create(Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                Prestamo _prestamo = Data.PrestamosDAO.ObtenerPrestamoVideoJuego(prestamo.VideoJuegoCodigo);
                if (_prestamo.PrestamoId!=0)
                {
                    ViewBag.sms = "Se realizó el prestamo con anterioridad";
                }
                else
                {
                    VideoJuego _videoJuego = Data.VideojuegoDAO.ObtenerCodigo(prestamo.VideoJuegoCodigo);
                    if (_videoJuego != null)
                    {
                        prestamo.VideoJuegoCodigoEjemplar = _videoJuego.VideoJuegoCodigoEjemplar;
                        prestamo.EsDevuelto = false;
                        Data.PrestamosDAO.Registrar(prestamo);
                        return RedirectToAction("Index");
                    }
                }
            }
            this.ViewBag.UsuarioCedula = new SelectList(Data.UsuarioDAO.Listar(), "UsuarioCedula", "UsuarioNombre");
            this.ViewBag.VideoJuegoCodigo = new SelectList(Data.VideojuegoDAO.Listar(), "VideoJuegoCodigo", "VideojuegoNombre");
            return View(prestamo);
        }
    }
}