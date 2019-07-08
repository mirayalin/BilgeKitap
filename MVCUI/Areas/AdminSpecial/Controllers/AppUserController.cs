using Kitap.BLL.RepositoryPattern.ConcreteRepo;
using Kitap.MODEL.Entities;
using Kitap.TOOLS.MyTools;
using MVCUI.AuthenticationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCUI.Areas.AdminSpecial.Controllers
{
    [AdminAuthentication]
    public class AppUserController : Controller
    {
        AppUserRepository ap_repo = new AppUserRepository();
        // GET: AdminSpecial/AppUser
        public ActionResult ListAppUsers()
        {
            return View(ap_repo.SelectAll());
        }

        public ActionResult AddAppUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAppUser(AppUser item,HttpPostedFileBase resim)
        {
            ResimVeHash(item, resim);
            ap_repo.Add(item);
            return RedirectToAction("ListAppUsers", "AppUser", new { area = "AdminSpecial" });
        }

        //Resim yükleme ve Password Hashleme metodu.
        private static void ResimVeHash(AppUser item, HttpPostedFileBase resim)
        {
            item.ImagePath = ImageUploader.UploadImage("~/Pictures/", resim);
            item.Password = Crypto.HashPassword(item.Password);
        }

        public ActionResult DeleteAppUser(int id)
        {
            ap_repo.Delete(ap_repo.GetByID(id));
            return RedirectToAction("ListAppUsers", "AppUser", new { area = "AdminSpecial" });
        }

        public ActionResult AppUserOptions(int id)
        {
            
            return View(ap_repo.GetByID(id));
        }

        [HttpPost]
        public ActionResult AppUserOptions(AppUser item, HttpPostedFileBase resim)
        {
            ResimVeHash(item, resim);
            ap_repo.Update(item);
            return RedirectToAction("ListAppUsers", "AppUser", new { area = "AdminSpecial" });
        }

        public ActionResult ChangePassword(int id)
        {
            return View(ap_repo.GetByID(id));
        }

        [HttpPost]
        public ActionResult ChangePassword(AppUser item)
        {
            item.Password = Crypto.HashPassword(item.Password);
            ap_repo.Update(item);

            return RedirectToAction("ListAppUsers", "AppUser", new { area = "AdminSpecial" });
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login","Home",new {area="" });
        }
    }
}