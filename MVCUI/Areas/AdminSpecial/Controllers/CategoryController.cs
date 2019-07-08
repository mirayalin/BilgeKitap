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
    public class CategoryController : Controller
    {
        CategoryRepository cat_repo = new CategoryRepository();
        // GET: AdminSpecial/Category
        public ActionResult CategoryList()
        {
            return View(cat_repo.SelectActives());
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category item)
        {
            cat_repo.Add(item);
            return RedirectToAction("CategoryList");
        }

        public ActionResult UpdateCategory(int id)
        {
            return View(cat_repo.GetByID(id));
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category item)
        {
            cat_repo.Update(item);
            return RedirectToAction("CategoryList");
        }

        public ActionResult DeleteCategory(int id)
        {
            cat_repo.SpecialDelete(id);
            return RedirectToAction("CategoryList");
        }
    }
}