using Kitap.BLL.RepositoryPattern.BaseRepo;
using Kitap.BLL.RepositoryPattern.ConcreteRepo;
using Kitap.MODEL.Entities;
using Kitap.VIEWMODEL.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.VIEWMODEL.VMRepository
{
   public class AppUserVMRepository:BaseRepository<AppUserVM>
    {
        AppUserRepository avm_repo;
        public AppUserVMRepository()
        {
            avm_repo = new AppUserRepository();
        }
        public override List<AppUserVM> SelectActives()
        {
            return db.AppUsers.Where(x=>x.Status!=MODEL.Enums.DataStatus.Deleted).Select(x => new AppUserVM
            {
                ID = x.ID,
                UserName = x.UserName,
                Password = x.Password,
                Name = x.Name,
                SPName = x.SPName
            }).ToList();
        }

        public List<AppUserVM> Add(AppUser item)
        {
            avm_repo.Add(item);
            return SelectActives();
        }

        public List<AppUserVM> Update(AppUser item)
        {
            avm_repo.Update(item);
            return SelectActives();
        }
    }
}
