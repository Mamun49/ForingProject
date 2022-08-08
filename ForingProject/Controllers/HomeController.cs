using ForingProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForingProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ImageShow db = new ImageShow();
            //var data = (from d in db.tblImages select d).ToList();
            return View();
        }

        public ActionResult About()
        {


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Foring Halishahar A-BLock";
            ViewBag.Message1 = "Foring Halishahar I-Block";

            return View();
        }
        [HttpGet]
        public ActionResult AddImage()
        {


            return View();
        }
        //[HttpPost]
        //public ActionResult AddImage(tblImage dbo)
        //{
        //    string imageName = Path.GetFileNameWithoutExtension(dbo.ImageFile.FileName);
        //    string imageExtension = Path.GetExtension(dbo.ImageFile.FileName);
        //    string fullName = imageName + imageExtension;
        //    dbo.ImagePath = "~/images/" + fullName;
        //    fullName = Path.Combine(Server.MapPath("~/images/" + fullName));
        //    dbo.ImageFile.SaveAs(fullName);
        //    using (ImageShow db = new ImageShow())
        //    {
        //        db.tblImages.Add(dbo);
        //        db.SaveChanges();
        //        ViewBag.Message = "Uploade Successfully.";
        //    }
        //    //if (ImagePath != null)
        //    //{
        //    //    string pic = System.IO.Path.GetFileName(ImagePath.FileName);
        //    //    string path = System.IO.Path.Combine(Server.MapPath("~/ images / "), pic);
        //    //    ImagePath.SaveAs(path);
        //    //    using (ImageShow db = new ImageShow())
        //    //    {
        //    //        ImageShow img = new ImageShow { ImagePath = "~/images/" + pic };
        //    //        db.tblImages.Add(img);
        //    //        db.SaveChanges();
        //    //    }
        //    //}
        //    return View();
        //}
    }
}