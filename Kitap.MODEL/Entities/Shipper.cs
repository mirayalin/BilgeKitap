using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.MODEL.Entities
{
   public class Shipper:BaseEntity
    {
        public Shipper()
        {
            Orders = new List<Order>();
        }

        public string CompanyName { get; set; }

        public string Phone { get; set; }

        //Relational Properties

        public virtual List<Order> Orders { get; set; }

    }
}
