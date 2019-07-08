using Kitap.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.VIEWMODEL.VMs
{
   public class OrderDetailVM:BaseEntity
    {
        public int OrderID { get; set; }

        public int BookID { get; set; }

        public short Quantity { get; set; }

        public decimal? TotalPrice { get; set; }

    }
}
