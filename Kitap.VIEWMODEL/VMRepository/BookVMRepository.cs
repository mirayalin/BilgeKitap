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
   public class BookVMRepository:BaseRepository<BookVM>
    {
        BookRepository b_repo;
        public BookVMRepository()
        {
            b_repo = new BookRepository();
        }
        public override List<BookVM> SelectActives()
        {
            

            return db.Books.Where(x => x.Status != MODEL.Enums.DataStatus.Deleted).Select(x => new BookVM
            {
                ID = x.ID,
                Name = x.Name,
                SPName = x.SPName,
                Publisher = x.Publisher
            }).ToList();

            
        }

        public List<BookVM> Add(Book item)
        {
            b_repo.Add(item);
            return SelectActives();
        }

        public List<BookVM> Update(Book item)
        {
            b_repo.Update(item);
            return SelectActives();
        }
    }
}
