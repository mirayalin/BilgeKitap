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
    public class APIBookController : ApiController
    {
        BookVMRepository bm_repo = new BookVMRepository();

        [HttpGet]
        public List<BookVM> KitaplariGetir()
        {
            return bm_repo.SelectActives();
        }

        [HttpGet]
        public BookVM KitapGetir(int id)
        {
            return bm_repo.GetByID(id);
        }

        [HttpDelete]
        public List<BookVM> KitapSil(int id)
        {
            bm_repo.SpecialDelete(id);
            return KitaplariGetir();
        }

        [HttpPost]
        public List<BookVM> KitapGuncelle(Book item)
        {
            bm_repo.Update(item);
            return KitaplariGetir();
        }

        [HttpPut]
        public List<BookVM> KategoriEkle(Book item)
        {
            bm_repo.Add(item);
            return KitaplariGetir();
        }
    }
}
