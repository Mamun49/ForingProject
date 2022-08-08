using ForingProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForingProject.Controllers
{
    public class adminController : Controller
    {
        private ForingModel db = new ForingModel();
        // GET: admin
       [Authorize(Roles ="Admin")]
        public ActionResult ProductList(string searchString)
        {
            //var products = from c in cd.Product
            //                 select c;
            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    products = products.Where(c => c.ProductName == Contains(searchString)|| c.ProductId==searchString);
            //}
            //return View(Product);
            using (ForingModel db = new ForingModel())
            {
                return View(db.Products.ToList());

            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult ProductEntry(int? Id)
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult ProductEntry(Product product)
        {
            try
            {
                // TODO: Add insert logic here
                using (ForingModel db = new ForingModel())
                {
                    db.Products.Add(product);
                    db.SaveChanges();

                }

                return RedirectToAction("ProductList", "admin");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult ProductEdit(int Id)
        {
            using (ForingModel db = new ForingModel())
            {
                return View(db.Products.Where(x => x.ProductId.Equals(Id)).FirstOrDefault());

            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]

        public ActionResult ProductEdit(int ProductId, Product product)
        {
            try
            {
                // TODO: Add update logic here
                using (ForingModel db = new ForingModel())
                {
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("ProductList", "admin");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult ProductDelete(int Id)
        {
            using (ForingModel db = new ForingModel())
            {
                return View(db.Products.Where(x => x.ProductId.Equals(Id)).FirstOrDefault());

            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult ProductDelete(int Id, Product product)
        {
            try
            {
                // TODO: Add delete logic here
                using (ForingModel db = new ForingModel())
                {
                    product = db.Products.Where(x => x.ProductId.Equals(Id)).FirstOrDefault();
                    db.Products.Remove(product);
                    db.SaveChanges();
                }
                return RedirectToAction("ProductList", "admim");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult ProductDetails(int Id)
        {
            using (ForingModel db = new ForingModel())
            {
                return View(db.Products.Where(x => x.ProductId.Equals(Id)).FirstOrDefault());

            }
        }
        //[HttpPost]
        //public ActionResult ProductDetails()
        //{
        //    return View();
        //}
        [HttpGet]
        [Authorize(Roles = "Admin")]

        public ActionResult Edit(string Mail)
        {
            using (ForingModel db = new ForingModel())
            {
                return View(db.users.Where(x => x.Mail.Equals(Mail)).FirstOrDefault());

            }

        }
        [Authorize(Roles = "Admin")]
        // POST: Emp/Edit/5
        [HttpPost]
        public ActionResult Edit(string Mail, user user)
        {
            try
            {
                // TODO: Add update logic here
                using (ForingModel db = new ForingModel())
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("ProductList", "admim");
            }
            catch
            {
                return View();
            }

        }

        //public ActionResult Search(string searching)
        //{
        //    ForingModel db = new ForingModel();
        //    return View(db.Products.Where(x => x.ProductName.Contains(searching) || searching == null).ToList());
        //}
        [Authorize(Roles = "Admin")]
        public ActionResult UserList(string searchString)
        {
            //var products = from c in cd.Product
            //                 select c;
            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    products = products.Where(c => c.ProductName == Contains(searchString)|| c.ProductId==searchString);
            //}
            //return View(Product);
            using (ForingModel db = new ForingModel())
            {
                return View(db.users.ToList());

            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult UserDelete(string Mail)
        {
            using (ForingModel db = new ForingModel())
            {
                return View(db.users.Where(x => x.Mail.Equals(Mail)).FirstOrDefault());

            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult UserDelete(string Mail, user user)
        {
            try
            {
                // TODO: Add delete logic here
                using (ForingModel db = new ForingModel())
                {
                    user = db.users.Where(x => x.Mail.Equals(Mail)).FirstOrDefault();
                    db.users.Remove(user);
                    db.SaveChanges();
                }
                return RedirectToAction("ProductList", "admim");
            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        [Authorize(Roles = "Admin , User")]
        public ActionResult CardDisplay()
        {
            var Mail = Session["Mail"].ToString();
            var search = (from n in db.users where n.Mail == Mail select n).FirstOrDefault();

            return View(search);
        }
        //public ActionResult getUserList()
        //{
        //    var user = db.users.ToList();
        //    return View(user);
        //}
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public ActionResult RoleList(int id =0)
        {
            UserRole userrole = new UserRole();
            using (ForingModel db = new ForingModel())
            {
                userrole.UserCollection = db.users.ToList<user>();
            }
            var rolelist = new List<string>() { "User", "Admin" };
            ViewBag.list = rolelist;
            //userrole.RoleCollection = new List<UserRole>()
            //{
            //    new UserRole(){ Role= "User",RoleName="User" },
            //    new UserRole(){ Role= "Admin",RoleName="Admin" },
            //};
                return View(userrole);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]

        public ActionResult RoleList(UserRole userrole)
        {

            using (ForingModel db = new ForingModel())
            {
                db.UserRoles.Add(userrole);
                db.SaveChanges();

            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Success!!";
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Membershipdec(int id= 0)
        {
            ForingModel db = new ForingModel();

            var namelist = db.users.ToList();
            ViewBag.NameList = new SelectList(namelist, "UserId", "UserId");
            
            var rolelist = new List<string>() { "Silver", "Gold", "Diamond" };
            ViewBag.list = rolelist;


            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Membershipdec(user ForingModel)
        {
            using (ForingModel db = new ForingModel())
            {
                //db.users.Add(ForingModel);
                var search_data = (from n in db.users where n.UserId == ForingModel.UserId select n).FirstOrDefault();
                if(search_data!=null)
                {
                    search_data.MemberStatus = ForingModel.MemberStatus;
                }
              
                db.SaveChanges();

            }
            ModelState.Clear();

            ViewBag.SuccessMessage = "Success!!";
            return RedirectToAction("UserList", "admin");
        }
    }
}