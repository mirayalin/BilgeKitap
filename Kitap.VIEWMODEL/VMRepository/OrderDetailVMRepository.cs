using Kitap.BLL.RepositoryPattern.BaseRepo;
using Kitap.VIEWMODEL.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.VIEWMODEL.VMRepository
{
   public class OrderDetailVMRepository:BaseRepository<OrderDetailVM>
    {
        public override List<OrderDetailVM> SelectActives()
        {
            return db.OrderDetails.Where(x => x.Status != MODEL.Enums.DataStatus.Deleted).Select(x => new OrderDetailVM
            {
                OrderID = x.OrderID,
                BookID = x.BookID
            }).ToList();
        }
    }
}
