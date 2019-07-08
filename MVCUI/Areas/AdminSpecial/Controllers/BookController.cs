using Kitap.BLL.RepositoryPattern.ConcreteRepo;
using Kitap.MODEL.Entities;
using Kitap.TOOLS.MyTools;
using MVCUI.AuthenticationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCUI.Areas.AdminSpecial.Controllers
{
    [AdminAuthentication]
    public class BookController : Controller
    {
        BookRepository b_repo = new BookRepository();
        CategoryRepository cat_repo = new CategoryRepository();
        // GET: AdminSpecial/Book
        public ActionResult BookList()
        {
            return View(b_repo.SelectActives());
        }

        public ActionResult AddBook()
        {
            return View(Tuple.Create(new Book(),cat_repo.SelectActives()));
        }

        [HttpPost]
        public ActionResult AddBook([Bind(Prefix ="Item1")] Book item,HttpPostedFileBase resim)
        {
            item.ImagePath = ImageUploader.UploadImage("~/Pictures/", resim);
            b_repo.Add(item);

            return RedirectToAction("BookList");
        }

        public ActionResult UpdateBook(int id)
        {
            return View(Tuple.Create(b_repo.GetByID(id),cat_repo.SelectActives()));
        }

        [HttpPost]
        public ActionResult UpdateBook([Bind(Prefix = "Item1")] Book item, HttpPostedFileBase resim)
        {
            item.ImagePath = ImageUploader.UploadImage("~/Pictures", resim);
            b_repo.Update(item);

            return RedirectToAction("BookList");
        }

        public ActionResult DeleteBook(int id)
        {
            b_repo.SpecialDelete(id);
            return RedirectToAction("BookList");
        }

        public ActionResult BookDetail(int id)
        {
            return View(b_repo.GetByID(id));
        }
    }
}