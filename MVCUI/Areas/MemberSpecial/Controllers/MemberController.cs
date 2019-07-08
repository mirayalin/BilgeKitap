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

namespace MVCUI.Areas.MemberSpecial.Controllers
{
    [MemberAuthentication]
    public class MemberController : Controller
    {
        AppUserRepository ap_repo = new AppUserRepository();
        // GET: MemberSpecial/Member
        public ActionResult MemberOptions(int id)
        {
            return View(ap_repo.GetByID(id));
        }

        //Resim yükleme ve Password Hashleme metodu.
        private static void ResimVeHash(AppUser item, HttpPostedFileBase resim)
        {
            item.ImagePath = ImageUploader.UploadImage("~/Pictures/", resim);
            item.Password = Crypto.HashPassword(item.Password);
        }

        [HttpPost]
        public ActionResult AppUserOptions(AppUser item, HttpPostedFileBase resim)
        {
            ResimVeHash(item, resim);
            ap_repo.Update(item);
            return RedirectToAction("ShoppingList", "Member", new { area = "" });
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

            return RedirectToAction("ShoppingList", "Member", new { area = "" });
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Home", new { area = "" });
        }
    }
}