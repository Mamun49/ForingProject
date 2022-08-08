using ForingProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ForingProject.Controllers
{
    public class UserController : Controller
    {
        ForingModel db = new ForingModel();
        //GET: User
       [HttpGet]
        
        public ActionResult registration(int Id = 0)
        {
            user ForingModel = new user();
            ViewBag.RoleName = new SelectList(db.users.ToList(), "RoleName", "RoleName");
            var rolelist = new List<string>() { "Male", "Female" };
            ViewBag.list = rolelist;
            return View(ForingModel);
        }
        [HttpPost]
        public ActionResult registration(user ForingModel)
        {
            if (db.users.Any(x => x.Mail == ForingModel.Mail))
            {
                ViewBag.Notification = "This account has already existed";
                return View();
            }
            else
            {
                using (ForingModel dbModel = new ForingModel())
                {
                    dbModel.users.Add(ForingModel);
                    dbModel.SaveChanges();

                }
                ModelState.Clear();
                ViewBag.SuccessMessage = "Registration Success";
                return RedirectToAction("login");
            }
        }


        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(ForingProject.Models.user ForingModel)
        {
            var checkLogin = db.users.Where(x => x.Mail.Equals(ForingModel.Mail) && x.Password.Equals(ForingModel.Password)).FirstOrDefault();
            if (checkLogin != null)
            {
                FormsAuthentication.SetAuthCookie(ForingModel.Mail, false);
                //Session["IdUsSS"] = For.IdUs.ToString();
                Session["Mail"] = ForingModel.Mail.ToString();
                
                return RedirectToAction("CardDisplay", "admin");
            }
            else
            {
                ViewBag.Notification1 = "Wrong Username or password";
            }

            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("login", "User");
        }

       
        [Authorize(Roles = "Admin")]

        public ActionResult GetRoleList()
        {
            using (ForingModel db = new ForingModel())
            {
                return View(db.UserRoles.ToList());

            }
        }
        [Authorize(Roles = "Admin")]

        public ActionResult GetRoleDelete(int Id)
        {
            using (ForingModel db = new ForingModel())
            {
                return View(db.UserRoles.Where(x => x.Id.Equals(Id)).FirstOrDefault());

            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult GetRoleDelete(int Id, UserRole urole)
        {
            try
            {
                // TODO: Add delete logic here
                using (ForingModel db = new ForingModel())
                {
                    urole = db.UserRoles.Where(x => x.Id.Equals(Id)).FirstOrDefault();
                    db.UserRoles.Remove(urole);
                    db.SaveChanges();
                }
                return RedirectToAction("GetRoleList", "User");
            }
            catch
            {
                return View();
            }
        }
    }
}