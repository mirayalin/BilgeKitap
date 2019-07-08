using Kitap.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.MAP.Options
{
   public class ShipperMap:BaseMap<Shipper>
    {
        public ShipperMap()
        {
            ToTable("Kargo Şirketleri");

            Property(x => x.CompanyName).HasColumnName("Şirket Adı").HasMaxLength(50).IsRequired();

            Property(x => x.Phone).HasColumnName("Telefon Numarası").IsRequired();
        }
    }
}
