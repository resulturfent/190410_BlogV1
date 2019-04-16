using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _190410_BlogV1.Areas.AdminPaneli.Controllers
{
    public class EtiketlerController : Controller
    {
        Models.Bloghi304DBEntities1 db = new Models.Bloghi304DBEntities1();
        // GET: AdminPaneli/Etiketler
        public ActionResult EtiketListesiIndex()
        {
            return View(db.Etiketler.ToList());
        }
    }
}