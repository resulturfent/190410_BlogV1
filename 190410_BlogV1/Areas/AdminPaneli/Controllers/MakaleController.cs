using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _190410_BlogV1.Models;

namespace _190410_BlogV1.Areas.AdminPaneli.Controllers
{
    public class MakaleController : Controller
    {
        // GET: AdminPaneli/Makale


        Bloghi304DBEntities1 db = new Bloghi304DBEntities1();

        public ActionResult MakaleIndex()
        {
            return View(db.Makaleler.ToList());
        }
        public ActionResult CreateIndex()
        {
            ViewBag.Kategori = db.Kategoriler.ToList();

            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreateIndex(string Baslik, string icerik, int KategoriID)
        {
            ViewBag.Kategori = db.Kategoriler.ToList();
            MakaleEkle(Baslik, icerik, 1, KategoriID);
            /*(int)Session["YazarID"]*/

            return View();
        }

        public ActionResult UpdateIndex(int MakalelerID, int KategoriID)
        {
            ViewBag.Kategori = db.Kategoriler.ToList();
            ViewBag.KategoriBul = KategoriBul(KategoriID).KategoriAdi;

            return View(MakaleBul(MakalelerID));
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateIndex(int MakalelerID, string Baslik, string icerik, int KategoriID)
        {
            ViewBag.Kategori = db.Kategoriler.ToList();
            ViewBag.KategoriBul = KategoriBul(KategoriID).KategoriAdi;

            MakaleGuncelle(MakalelerID, Baslik, icerik, 1, KategoriID);
            return View(MakaleBul(MakalelerID));
        }
        public ActionResult MakaleSil(int MakalelerID)
        {
            MakaleSil1(MakalelerID);
            return RedirectToAction("MakaleIndex");
        }

        public Kategoriler KategoriBul(int id)
        {
            return db.Kategoriler.Where(k => k.KategorilerID == id).FirstOrDefault();
        }

        public void MakaleEkle(string baslik, string icerik, int yazarID, int kategoriID)
        {
            Makaleler makale = new Makaleler();

            makale.Baslik = baslik;
            makale.icerik = icerik;
            makale.EklenmeTarihi = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            makale.Aktifmi = false;
            makale.YazarID = yazarID;
            makale.KategoriID = kategoriID;

            db.Makaleler.Add(makale);
            db.SaveChanges();

        }
        public void MakaleGuncelle(int makaleID, string baslik, string icerik, int yazarID, int kategoriID)
        {
            Makaleler makale = MakaleBul(makaleID);

            makale.Baslik = baslik;
            makale.icerik = icerik;
            makale.GuncellenmeTarihi = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            makale.YazarID = yazarID;
            makale.KategoriID = kategoriID;

            db.SaveChanges();

        }
        public Makaleler MakaleBul(int id)
        {
            return db.Makaleler.Where(k => k.MakalelerID == id).FirstOrDefault();
        }

        public void MakaleSil1(int makaleID)
        {
            Makaleler silSorgu = MakaleBul(makaleID);

            if (silSorgu != null)
            {

                db.Makaleler.Remove(silSorgu);

                db.SaveChanges();
            }
        }
    }
}