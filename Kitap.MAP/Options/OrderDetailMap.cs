using Kitap.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.MAP.Options
{
   public class OrderDetailMap:BaseMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            ToTable("Satışlar");

            Ignore(x => x.ID);

            HasKey(x => new
            {
                x.BookID,
                x.OrderID
            });

            Property(x => x.Quantity).HasColumnName("Miktar").IsOptional();

            Property(x => x.TotalPrice).HasColumnName("Toplam Fiyat").IsOptional();

            Property(x => x.OrderID).HasColumnName("SiparisID");

            Property(x => x.BookID).HasColumnName("KitapID");
        }
    }
}
