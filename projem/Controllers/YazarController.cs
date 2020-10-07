using projem.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projem.Controllers
{
    public class YazarController : Controller
    {
        projeEntities db = new projeEntities();
        // GET: Yazar
        public ActionResult Index()
        {
            var model = db.yazar.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Kaydet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kaydet(yazar yazar)
        {
            if (yazar.ID == 0)
            {
                db.yazar.Add(yazar);
            }
            else
            {
                var guncellenecekYazarlar = db.yazar.Find(yazar.ID);
                if (guncellenecekYazarlar == null)
                {
                    return HttpNotFound();
                }
                guncellenecekYazarlar.AdSoyad = yazar.AdSoyad;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Yazar");
        }
        public ActionResult Guncelle(int ID)
        {
            var model = db.yazar.Find(ID);
            if (model == null)
                return HttpNotFound();
            return View("Kaydet", model);
        }
        public ActionResult Sil(int ID)
        {
            var silinecekYazarlar = db.yazar.Find(ID);
            if (silinecekYazarlar == null)
                return HttpNotFound();
            db.yazar.Remove(silinecekYazarlar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
