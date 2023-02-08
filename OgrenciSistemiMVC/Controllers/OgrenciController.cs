using OgrenciSistemiMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciSistemiMVC.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        DbOgrenciYonetimiEntities db = new DbOgrenciYonetimiEntities();
        public ActionResult Index()
        {
            var ogrenciler = db.Ogrenci.ToList();
            return View(ogrenciler);
        }

        [HttpGet]
        public ActionResult OgrenciEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OgrenciEkle(Ogrenci t)
        {
            db.Ogrenci.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OgrenciSil(int id)
        {
            var ogrenci = db.Ogrenci.Find(id);
            db.Ogrenci.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci = db.Ogrenci.Find(id);
            return View("OgrenciGetir", ogrenci);
        }

        public ActionResult OgrenciGuncelle(Ogrenci t)
        {
            var ogrenci = db.Ogrenci.Find(t.Id);
            ogrenci.AdSoyad = t.AdSoyad;
            ogrenci.KayitTarih = t.KayitTarih;
            ogrenci.OgrenciNo = t.OgrenciNo;
            ogrenci.DTarih = t.DTarih;
            ogrenci.Bolum = t.Bolum;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}