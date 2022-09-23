using ParcialUno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ParcialUno.Controllers
{
    public class VideojuegoController : Controller
    {
        // GET: Videojuego
        public ActionResult Index()
        {
            return View(Data.VideojuegoDAO.Listar());
        }

        // GET: Videojuego/Details/5
        public ActionResult Details(Int64 videoJuegoCodigoEjemplar, Int64 videoJuegoCodigo)
        {
            if (videoJuegoCodigoEjemplar == 0 && videoJuegoCodigo == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoJuego videoJuego = Data.VideojuegoDAO.Obtener(videoJuegoCodigo, videoJuegoCodigoEjemplar);
            if (videoJuego == null)
            {
                return HttpNotFound();
            }
            return View(videoJuego);

        }

        [HttpPost]
        public ActionResult Edit(VideoJuego videoJuego)
        {
            if (ModelState.IsValid)
            {

                Data.VideojuegoDAO.Actualizar(videoJuego);
                return RedirectToAction("Index");

            }

            return View(videoJuego);
        }
        [HttpPost]
        public ActionResult Create(VideoJuego videoJuego)
        {
            if (ModelState.IsValid)
            {
                VideoJuego _videoJuego = Data.VideojuegoDAO.Obtener(videoJuego.VideoJuegoCodigo, videoJuego.VideoJuegoCodigoEjemplar);
                if (_videoJuego != null)
                {
                    ViewBag.sms = "Existe un codigo y un codigo ejemplar";
                }
                else
                {
                    Data.VideojuegoDAO.Registrar(videoJuego);
                    return RedirectToAction("Index");
                }

            }

            return View(videoJuego);
        }
    }
}
