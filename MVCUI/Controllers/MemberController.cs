using Kitap.BLL.RepositoryPattern.ConcreteRepo;
using Kitap.MODEL.Entities;
using MVCUI.Models.MyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCUI.Controllers
{
    public class MemberController : Controller
    {
        BookRepository b_repo = new BookRepository();
        CategoryRepository cat_repo = new CategoryRepository();

        // GET: Member
        public ActionResult ShoppingList()
        {
            return View(Tuple.Create(b_repo.SelectActives(),cat_repo.SelectActives()));
        }

        public ActionResult SelectByCategory(int id)
        {
            List<Book> byCategory = b_repo.Where(x => x.CategoryID == id);

            return View(Tuple.Create(byCategory, cat_repo.SelectActives()));
        }

        public ActionResult BookDetail(int id)
        {
            List<Category> byCategory = cat_repo.SelectActives();

            Book secilenUrun = b_repo.GetByID(id);
            return View(Tuple.Create(byCategory, secilenUrun));
        }

        public ActionResult AddToCart(int id)
        {
            if (Session["member"] == null)
            {
                TempData["uyeYok"] = "Lütfen sepete ürün eklemeden önce üye olun veya üye girişi yapın";

                return RedirectToAction("Login", "Home");
            }

            Cart c = Session["scart"] == null ? new Cart() : Session["scart"] as Cart;

            Book eklenecekUrun = b_repo.GetByID(id);

            CartItem ci = new CartItem();
            ci.ID = eklenecekUrun.ID;
            ci.Name = eklenecekUrun.Name;
            ci.Price = eklenecekUrun.UnitPrice;
            c.SepeteEkle(ci);

            Session["scart"] = c;

            return RedirectToAction("ShoppingList");
        }

        public ActionResult CartPage()
        {
            if (Session["scart"] != null)
            {
                Cart c = Session["scart"] as Cart;
                return View(c);
            }
            TempData["message"] = "Sepetinizde ürün bulunmamaktadır";
            return RedirectToAction("ShoppingList");
        }

        public ActionResult RemoveFromCart(int id)
        {
            Cart c = Session["scart"] as Cart;

            c.SepettenSil(id);
            if (c.Sepetim.Count < 1)
            {
                Session.Remove("scart");
            }

            return RedirectToAction("CartPage");
        }

        public ActionResult SiparisVer()
        {
            if (Session["member"] != null)
            {
                AppUser mevcutKullanici = Session["member"] as AppUser;

                TempData["Kullanici"] = mevcutKullanici;
                return View();
            }

            TempData["uyeYok"] = "Üye olmadan sepete ürün ekleyemezsiniz.";

            return RedirectToAction("Login", "Home");
        }

        OrderRepository or_repo = new OrderRepository();
        OrderDetailRepository od_repo = new OrderDetailRepository();

        [HttpPost]
        public ActionResult SiparisVer(Order item)
        {
            if (TempData["Kullanici"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            AppUser kullanici = TempData["Kullanici"] as AppUser;

            //Kredi kartı işlemleri burada yapılacak.

            item.AppUserID = kullanici.ID;//Order'ın kim tarafından sipariş verildiğini belirliyoruz.

            or_repo.Add(item);//Save edildiğinde Order nesnesi bir ID alacak.

            //SU anda kullanıcı bir sipariş vermiştir. Biz bu siparişe ürün ekleyecegiz cünkü kullanıcının sepetinde birden fazla ürün olabilir. Ancak kullanıcının siparişne ürün ekleyebilmem icin o siparişin  id'sini bilmemiz gerekmektedir. ID sizin kontrolünüzde olmayan kendi kendine yaratılan bir primary key'dir. Siz bu id'yi yakalamalısınız. Bizim bu işi yapan bir Repository metodumuz var.

            int sonSiparisID = or_repo.GetLastAdded();

            Cart sepet = Session["scart"] as Cart;

            foreach (CartItem urun in sepet.Sepetim)
            {
                OrderDetail od = new OrderDetail();
                od.OrderID = sonSiparisID;
                od.BookID = urun.ID;
                od.TotalPrice = urun.SubTotal;
                od.Quantity = urun.Amount;
                od_repo.Add(od);
            }

            return RedirectToAction("ShoppingList");
        }
    }
}