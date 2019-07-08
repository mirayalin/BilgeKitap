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
    public class APIAppUserController : ApiController
    {
        AppUserVMRepository avm_repo = new AppUserVMRepository();

        [HttpGet]
        public List<AppUserVM> KullanicilariGetir()
        {
            return avm_repo.SelectActives();
        }

        [HttpGet]
        public AppUserVM KitapGetir(int id)
        {
            return avm_repo.GetByID(id);
        }

        [HttpDelete]
        public List<AppUserVM> KitapSil(int id)
        {
            avm_repo.SpecialDelete(id);
            return KullanicilariGetir();
        }

        [HttpPost]
        public List<AppUserVM> KitapGuncelle(AppUser item)
        {
            avm_repo.Update(item);
            return KullanicilariGetir();
        }

        [HttpPut]
        public List<AppUserVM> KategoriEkle(AppUser item)
        {
            avm_repo.Add(item);
            return KullanicilariGetir();
        }
    }
}
