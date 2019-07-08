using Kitap.BLL.RepositoryPattern.BaseRepo;
using Kitap.VIEWMODEL.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.VIEWMODEL.VMRepository
{
   public class ShipperVMRepository:BaseRepository<ShipperVM>
    {
        public override List<ShipperVM> SelectActives()
        {
            return db.Shippers.Where(x => x.Status != MODEL.Enums.DataStatus.Deleted).Select(x => new ShipperVM
            {
                CompanyName = x.CompanyName
            }).ToList();
        }
    }
}
