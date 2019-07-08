using Kitap.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.VIEWMODEL.VMs
{
   public class ShipperVM:BaseEntity
    {
        public string CompanyName { get; set; }

        public string Phone { get; set; }
    }
}
