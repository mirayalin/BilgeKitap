using Kitap.BLL.SingletonPattern;
using Kitap.DAL.Context;
using Kitap.MODEL.Entities;
using Kitap.VIEWMODEL.VMRepository;
using Kitap.VIEWMODEL.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kitap.API.Controllers
{
    
    public class APICategoryController : ApiController
    {
        CategoryVMRepository cvm_repo = new CategoryVMRepository();

        [HttpGet]
        public List<CategoryVM> KategorileriGetir()
        {
            return cvm_repo.SelectActives();
        }

        [HttpGet]
        public CategoryVM KategoriGetir(int id)
        {
            return cvm_repo.GetByID(id);
        }

        [HttpDelete]
        public List<CategoryVM> KategoriSil(int id)
        {
            cvm_repo.SpecialDelete(id);
            return KategorileriGetir();
        }

        [HttpPost]
        public List<CategoryVM> KategoriGuncelle(Category item)
        {
            cvm_repo.Update(item);
            return KategorileriGetir();
        }

        [HttpPut]
        public List<CategoryVM> KategoriEkle(Category item)
        {
            cvm_repo.Add(item);
            return KategorileriGetir();
        }
    }
}
