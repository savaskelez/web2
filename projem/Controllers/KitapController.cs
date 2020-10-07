using projem.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace projem.Controllers
{
    public class KitapController : Controller
    {
        projeEntities db = new projeEntities();
        // GET: Kitap
        public ActionResult Index()
        {
            var model = db.Kitap.Include(x => x.yazar).ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Yeni()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Yeni(Kitap kitap)
        {

            if (kitap.ID == 0)
            {
                db.Kitap.Add(kitap);
            }
            else
            {
                var guncellenecekKitap = db.Kitap.Find(kitap.ID);
                if (guncellenecekKitap == null)
                {
                    return HttpNotFound();
                }
                guncellenecekKitap.KitapAdi = kitap.KitapAdi;
                guncellenecekKitap.sayfasayisi = kitap.sayfasayisi;
                guncellenecekKitap.Yazarİd = kitap.Yazarİd;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Kitap");
        }
        public ActionResult Guncelle(int ID)
        {
            var model = db.Kitap.Find(ID);
            if (model == null)
                return HttpNotFound();
            return View("Yeni", model);
        }
        public ActionResult Sil(int ID)
        {
            var silinecekKitap = db.Kitap.Find(ID);
            if (silinecekKitap == null)
                return HttpNotFound();
            db.Kitap.Remove(silinecekKitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
