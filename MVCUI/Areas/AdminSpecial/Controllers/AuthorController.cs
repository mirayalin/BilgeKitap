using Kitap.BLL.RepositoryPattern.ConcreteRepo;
using Kitap.MODEL.Entities;
using MVCUI.AuthenticationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCUI.Areas.AdminSpecial.Controllers
{
    [AdminAuthentication]
    public class AuthorController : Controller
    {
        AuthorRepository a_repo = new AuthorRepository();
        // GET: AdminSpecial/Author
        public ActionResult AuthorList()
        {
            return View(a_repo.SelectActives());
        }

        public ActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(Author item)
        {
            
            a_repo.Add(item);

            return RedirectToAction("AuthorList");
        }

        public ActionResult UpdateAuthor(int id)
        {
            return View(a_repo.GetByID(id));
        }

        [HttpPost]
        public ActionResult UpdateAuthor(Author item)
        {
            
            a_repo.Update(item);

            return RedirectToAction("AuthorList");
        }

        public ActionResult DeleteAuthor(int id)
        {
            a_repo.SpecialDelete(id);
            return RedirectToAction("AuthorList");
        }
    }
}