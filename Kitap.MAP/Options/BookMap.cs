using Kitap.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.MAP.Options
{
   public class BookMap:BaseMap<Book>
    {
        public BookMap()
        {
            ToTable("Kitaplar");

            Property(x => x.Name).IsRequired().HasColumnName("Kitap İsmi").HasMaxLength(100);

            Property(x => x.SPName).IsRequired().HasColumnName("Açıklama").HasMaxLength(100);

            Property(x => x.Publisher).IsOptional().HasColumnName("Yayınevi").HasMaxLength(50);

            Property(x => x.UnitPrice).IsRequired().HasColumnName("Fiyat");

            Property(x => x.UnitInStock).IsRequired().HasColumnName("Stok Adedi");
        }
    }
}
