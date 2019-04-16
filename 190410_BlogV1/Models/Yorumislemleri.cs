using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _190410_BlogV1.Models
{
    public class Yorumislemleri
    {
        Bloghi304DBEntities1 db = new Bloghi304DBEntities1();
        public List<Yorumlar> YorumListesi(int makale_Id)
        {
            return db.Yorumlar.Where(l => l.MakaleID == makale_Id && l.Aktifmi==true).ToList();
        }

        public int YorumEkle(string baslik,string icerik,int makaleId,int uyeId)
        {
            Yorumlar ekle = new Yorumlar();
            ekle.YorumBaslik = baslik;
            ekle.Yorumicerik =icerik;
            //*******varsayılan değerler********************************************
            ekle.Aktifmi = false;
            //ekle.GuncellemeTarihi =Convert.ToDateTime();
            //**********************************************************************
            ekle.YorumTarihi =Convert.ToDateTime(DateTime.Now.ToShortDateString());
            ekle.BegenmeSayisi = 0;
            ekle.BegenmemeSayisi = 0;
            ekle.MakaleID = makaleId;
            ekle.UyeID = uyeId;

            db.Yorumlar.Add(ekle);
            if (db.SaveChanges()>0)
            {
                return 1;
            }
            return 0;
        }
    }
}