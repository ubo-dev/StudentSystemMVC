using OgrenciSistemiMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace OgrenciSistemiMVC.Controllers
{
    public class DersController : Controller
    {
        // GET: Ders
        DbOgrenciYonetimiEntities db = new DbOgrenciYonetimiEntities();
        public ActionResult Index()
        {
            var ders = db.Ders.ToList();
            return View(ders);
        }

        [HttpGet]
        public ActionResult DersEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DersEkle(Ders ders)
        {
            db.Ders.Add(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DersSil(int id)
        {
            var ders = db.Ders.Find(id);
            db.Ders.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DersGetir(int id)
        {
            var ders = db.Ders.Find(id);
            return View("DersGetir", ders);
        }

        public ActionResult DersGuncelle(Ders t)
        {
            var ders = db.Ders.Find(t.Id);
            ders.Ad = t.Ad;
            ders.Kredi = t.Kredi;
            ders.OkulYonetimId = t.OkulYonetimId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}