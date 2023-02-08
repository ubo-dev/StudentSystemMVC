using OgrenciSistemiMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciSistemiMVC.Controllers
{
    public class OgrenciDersController : Controller
    {
        // GET: OgrenciDers

        DbOgrenciYonetimiEntities db = new DbOgrenciYonetimiEntities();
        public ActionResult Index()
        {
            var od = db.OgrenciDers.ToList();
            return View(od);
        }

        [HttpGet]
        public ActionResult OgrenciDersEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OgrenciDersEkle(OgrenciDers ders)
        {
            db.OgrenciDers.Add(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OgrenciDersSil(int id)
        {
            var ders = db.OgrenciDers.Find(id);
            db.OgrenciDers.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OgrenciDersGetir(int id)
        {
            var od = db.OgrenciDers.Find(id);
            return View("OgrenciDersGetir", od);
        }

        public ActionResult OgrenciDersGuncelle(OgrenciDers t)
        {
            var ders = db.OgrenciDers.Find(t.Id);
            ders.DersId = t.DersId;
            ders.OgrenciId = t.OgrenciId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}