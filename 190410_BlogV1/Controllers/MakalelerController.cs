using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _190410_BlogV1.Models;

namespace _190410_BlogV1.Controllers
{
    public class MakalelerController : Controller
    {
        //*****************************************************************
        Bloghi304DBEntities1 db = new Bloghi304DBEntities1();
        // GET: Makaleler
        public ActionResult MakaleListesIndex()
        {
            return View(db.Makaleler.ToList());
        }

        public ActionResult KategoriListeiIndex()
        {
            return View();
        }

        public ActionResult KategoriListesi()
        {

            return View(db.Kategoriler.ToList());
        }

       
        public ActionResult MakaleDetay(int? Makale_ID)
        {
            Session["makalexid"]= (int)Makale_ID;
            //makalex_id =(int)Makale_ID;
            var tekMakale = db.Makaleler.FirstOrDefault(k => k.MakalelerID == Makale_ID);
            return View(tekMakale);
        }

        //YorumIndex Partial Metot
        public ActionResult YorumIndex(int makale_Id)
        {
            makale_Id =(int)Session["makalexid"];
            //var makale_Yorum = db.Yorumlar.Where(l => l.MakaleID == makale_Id).ToList();
            return View(db.Makaleler.FirstOrDefault(k => k.MakalelerID == makale_Id));
        }
       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nesneTablo"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult YorumIndex(string yorumbasligi, string Yorumicerik, int Makale_ID)
        {
            Yorumislemleri yi = new Yorumislemleri();
            int Kaydet = yi.YorumEkle(yorumbasligi, Yorumicerik, Makale_ID, 1);
            return RedirectToAction("MakaleDetay","Makaleler",new {Makale_ID });
        }

        //JQuery Ajax kodlaması için metot yazdık
        //[HttpPost]
        //public void YorumEkle(string yorumbasligi, string Yorumicerik, int Makale_ID)
        //{
        //    Yorumislemleri yi = new Yorumislemleri();
        //    int Kaydet = yi.YorumEkle(yorumbasligi, Yorumicerik, Makale_ID, 1);
        //}
    }
}