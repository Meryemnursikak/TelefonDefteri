using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonDefteri.Models.Context;
using TelefonDefteri.Models.Entities;
using TelefonDefteri.Models.KisiModel;

namespace TelefonDefteri.Controllers
{
    public class KisiController : Controller
    {

        MVCRehberContext db = new MVCRehberContext();

        // GET: Kisi
        public ActionResult Index()
        {
           
            var model = new KisiIndexViewModel 
            {
                Kisiler= db.Kisiler.ToList(),
                Kategoriler = db.Kategoriler.ToList()
        };
            return View(model);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            var model = new KisiEkleViewModel
            {
                Kisi = new Kisi(),
                Kategoriler=db.Kategoriler.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Ekle(Kisi kisi)
        {
            try
            {
               db.Kisiler.Add(kisi);
               db.SaveChanges();

               TempData["BasariliMesaj"] = "Kayıt Ekleme İşlemi Başarıyla Gerçekleşti.";

            }
            catch (Exception)
            {

                TempData["HataliMesaj"] = "Kişi Kaydedilemedi Lütfen Tekrar Deneyiniz!";
            }
        

            return RedirectToAction("Index");
        }

        public ActionResult Guncelle(int id)
        {
            var kisi = db.Kisiler.Find(id);

            if(kisi==null)
            {
                TempData["HataliMesaj"] = "Güncellemek İstediğiniz Kişi Bulunamadı";
                return RedirectToAction("Index");
            }

            var model = new KisiGuncelleViewModel
            {
                kisi = kisi,
                Kategoriler = db.Kategoriler.ToList()
            };

            ViewBag.Kategoriler = new SelectList(db.Kategoriler.ToList(), "KategoriId", "KategoriAdi");
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Guncelle(Kisi kisi)
        {
            var oncekiKayit = db.Kisiler.Find(kisi.KisiId);

            if (oncekiKayit==null)
            {
                TempData["HataliMesaj"] = "Güncellemek İstediğiniz Kişi Bulunamadı";
                return RedirectToAction("Index");
            }

            oncekiKayit.KisiAdi = kisi.KisiAdi;
            oncekiKayit.Soyadi = kisi.Soyadi;
            oncekiKayit.Telefon = kisi.Telefon;
            oncekiKayit.KategoriId = kisi.KategoriId;

            db.SaveChanges();
            TempData["BasariliMesaj"] = "Kişi Bilgileri Güncellendi.";


            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var kisi = db.Kisiler.Find(id);

            if (kisi==null)
            {

                TempData["HataliMesaj"] = "Silmek İstediğiniz Kişi Bulunamadı";
                return RedirectToAction("Index");
            }
            db.Kisiler.Remove(kisi);
            db.SaveChanges();

            TempData["BasariliMesaj"] = "Kişi Başarıyla Silindi.";

            return RedirectToAction("Index");
        }
    }
}