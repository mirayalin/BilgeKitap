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
   public class CategoryVMRepository:BaseRepository<CategoryVM>
    {
        CategoryRepository cr_repo;
        public CategoryVMRepository()
        {
            cr_repo = new CategoryRepository();
        }

        public override List<CategoryVM> SelectActives()
        {
            return db.Categories.Where(x => x.Status != MODEL.Enums.DataStatus.Deleted).Select(x => new CategoryVM
            {
                ID = x.ID,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).ToList();
        }

        public List<CategoryVM> Add(Category item)
        {
            cr_repo.Add(item);
            return SelectActives();
        }

        public List<CategoryVM> Update(Category item)
        {
            cr_repo.Update(item);
            return SelectActives();
        }
    }
}
