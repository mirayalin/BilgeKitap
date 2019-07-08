using Kitap.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.MAP.Options
{
   public class AuthorMap:BaseMap<Author>
    {
        public AuthorMap()
        {
            ToTable("Yazarlar");

            Property(x => x.Name).IsRequired().HasColumnName("Yazar İsmi").HasMaxLength(100);
            Property(x => x.SPName).IsRequired().HasColumnName("Yazar Soyismi").HasMaxLength(100);
        }
    }
}
