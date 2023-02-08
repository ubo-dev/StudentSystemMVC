using OgrenciSistemiMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciSistemiMVC.Controllers
{
    public class PersonalController : Controller
    {
        // GET: Personal
        DbOgrenciYonetimiEntities db = new DbOgrenciYonetimiEntities();
        public ActionResult Index()
        {
            var personal = db.Personal.ToList();
            return View(personal);
        }

        [HttpGet]
        public ActionResult PersonalEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonalEkle(Personal t)
        {
            db.Personal.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonalSil(int id)
        {
            var personal = db.Personal.Find(id);
            db.Personal.Remove(personal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonalGetir(int id)
        {
            var personal = db.Personal.Find(id);
            return View("PersonalGetir", personal);
        }

        public ActionResult PersonalGuncelle(Personal t)
        {
            var personal = db.Personal.Find(t.Id);
            personal.AdSoyad = t.AdSoyad;
            personal.Gorevi = t.Gorevi;
            personal.YonetimTip = t.YonetimTip;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}