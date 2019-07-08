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
    public class APIAuthorController : ApiController
    {
        AuthorVMRepository a_repo = new AuthorVMRepository();

        [HttpGet]
        public List<AuthorVM> YazarlariGetir()
        {
            return a_repo.SelectActives();
        }

        [HttpGet]
        public AuthorVM YazarGetir(int id)
        {
            return a_repo.GetByID(id);
        }

        [HttpDelete]
        public List<AuthorVM> YazarSil(int id)
        {
            a_repo.SpecialDelete(id);
            return YazarlariGetir();
        }

        [HttpPost]
        public List<AuthorVM> KitapGuncelle(Author item)
        {
            a_repo.Update(item);
            return YazarlariGetir();
        }

        [HttpPut]
        public List<AuthorVM> KategoriEkle(Author item)
        {
            a_repo.Add(item);
            return YazarlariGetir();
        }
    }
}
