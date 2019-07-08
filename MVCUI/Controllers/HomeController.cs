using Kitap.BLL.RepositoryPattern.ConcreteRepo;
using Kitap.DAL.Context;
using Kitap.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCUI.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: Home
        public ActionResult Login()
        {
            AppUser girecekOlan = CheckCookie();
            if (girecekOlan == null)
            {
                return View();

            }
            return View(girecekOlan);
        }

        AppUserRepository ap_repo = new AppUserRepository();


        

        [HttpPost]
        public ActionResult Login(AppUser item, string Hatirla)
        {
            if (ap_repo.Any(x => x.UserName == item.UserName && x.Role==Kitap.MODEL.Enums.Role.Admin&&x.Status!=Kitap.MODEL.Enums.DataStatus.Deleted))
            {


                

                AppUser girisYapan = ap_repo.Default(x => x.UserName == item.UserName && x.Role == Kitap.MODEL.Enums.Role.Admin);



                if (girisYapan.Password=="1234")
                {
                    return Kontrol(item, Hatirla, girisYapan);
                }



                bool sonuc = Crypto.VerifyHashedPassword(girisYapan.Password, item.Password);

                if (sonuc)
                {
                    return Kontrol(item, Hatirla, girisYapan);
                }
            }
            else if (ap_repo.Any(x => x.UserName == item.UserName && x.Role == Kitap.MODEL.Enums.Role.Member))
            {
                AppUser girisYapanUye = ap_repo.Default(x => x.UserName == item.UserName && x.Role == Kitap.MODEL.Enums.Role.Member);

                bool sonuc = Crypto.VerifyHashedPassword(girisYapanUye.Password, item.Password);

                if (sonuc)
                {
                    HatirlaKontrol(item, Hatirla);

                    Session["member"] = girisYapanUye;

                    return RedirectToAction("ShoppingList", "Member");
                }
            }

            TempData["uyeYok"] = "Kullanıcı adı veya şifre hatalı";

            return View();
        }

        private ActionResult Kontrol(AppUser item, string Hatirla, AppUser girisYapan)
        {
            HatirlaKontrol(item, Hatirla);
            Session["admin"] = girisYapan;

            return RedirectToAction("ListAppUsers", "AppUser", new { area = "AdminSpecial" });
        }

        #region BenihatirlaKontrol
        private void HatirlaKontrol(AppUser item, string Hatirla)
        {
            //Burada kullanıcı cookie'de var mı bu kontrol edilecek.
            if (Hatirla == "true")
            {
                HttpCookie girisIsim = new HttpCookie("userName");//Cookie oluşturduk.
                girisIsim.Expires = DateTime.Now.AddMinutes(5);
                girisIsim.Value = item.UserName;

                Response.Cookies.Add(girisIsim);

                HttpCookie girisSifre = new HttpCookie("password");
                girisSifre.Expires = DateTime.Now.AddMinutes(5);
                girisSifre.Value = item.Password;

                Response.Cookies.Add(girisSifre);
            }
        } 

        private AppUser CheckCookie()
        {
            string userName = string.Empty;
            string password = string.Empty;

            AppUser cookiedeSaklanan = null;

            if (Request.Cookies["userName"] != null && Request.Cookies["password"] != null)
            {
                userName = Request.Cookies["userName"].Value;
                password = Request.Cookies["password"].Value;

            }

            //Client Side validation için bu kontrole gerek yok.
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                cookiedeSaklanan = new AppUser
                {
                    UserName = userName,
                    Password = password
                };
            }

            return cookiedeSaklanan;
        }
        #endregion


        public ActionResult Register(Guid? id)
        {
            if (id != null)
            {
                if (ap_repo.Any(x => x.ActivationCode == id))
                {
                    AppUser aktifEdilecek = Session["register"] as AppUser;
                    aktifEdilecek.IsActive = true;

                    ap_repo.Update(aktifEdilecek);//bunu yapmazsak kullanıcı pasif olarak kalır.

                    TempData["Tebrikler"] = "Tebrikler başarılı bir şekilde hesabınız aktif edilmiştir.";
                }
                else
                {
                    //Kişi özellikle 3th party uygulamlarla girmeye çalışıyorsa ve guid göndermeyi başarmışsa veritabanında engellenecek.
                    ViewBag.KullaniciYok = "Kullanıcı olarak giriş yapmadınız.";
                }
            }
            else if (Session["register"] != null && id == null)
            {
                ViewBag.AktifDegil = "Hesabınızı aktif etmemişsiniz.";
            }

            return View();
        }

        [HttpPost]
        public ActionResult Register(AppUser item)
        {
            if (ap_repo.Any(x => x.UserName == item.UserName))
            {
                ViewBag.ZatenVar = "Böyle bir kullanıcı zaten var";

                return View();
            }

            //Kullanıcı başarılı bir şekilde register işlemini tamamladıysa ona mail gönder

            string gonderilecekMesaj = "Tebrikler hesabınız oluşturulmuştur. Hesabınızı aktif etmek için http://localhost:58096/Home/Register"+item.ActivationCode+" linkine tıklayabilirsiniz";

            #region MailGondermeIslemi
            //göndericinin mail adresi sifresini buradaki gibi bos bırakmayın
            //MailSender.Send(item.Email, password: "", body: gonderilecekMesaj, subject: "Hosgeldiniz!");
            #endregion

            item.Password = Crypto.HashPassword(item.Password);//şifreyi hashledik.

            ap_repo.Add(item);

            Session["register"] = ap_repo.GetByID(item.ID);//Kullanıcı register oldugu anda onun için bir session açtık.

            return RedirectToAction("RegisterOk");
        }

        public ActionResult RegisterOk()
        {
            return View();
        }

        
    }
}