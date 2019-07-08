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
   public class AuthorVMRepository:BaseRepository<AuthorVM>
    {

        AuthorRepository a_repo;
        public AuthorVMRepository()
        {
            a_repo = new AuthorRepository();
        }

        public override List<AuthorVM> SelectActives()
        {
            return db.Authors.Where(x => x.Status != MODEL.Enums.DataStatus.Deleted).Select(x => new AuthorVM
            {
                ID = x.ID,
                Name = x.Name,
                SPName = x.SPName
            }).ToList();
        }

        public List<AuthorVM> Add(Author item)
        {
            a_repo.Add(item);
            return SelectActives();
        }

        public List<AuthorVM> Update(Author item)
        {
            a_repo.Update(item);
            return SelectActives();
        }
    }
}
