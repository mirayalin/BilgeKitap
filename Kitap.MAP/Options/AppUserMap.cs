using Kitap.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.MAP.Options
{
   public class AppUserMap:BaseMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("Kullanıcılar");
            Property(x => x.UserName).HasColumnName("Kullanıcı İsmi").IsRequired().HasMaxLength(70);

            Property(x => x.Password).HasColumnName("Şifre").HasMaxLength(200).IsRequired();

            Ignore(x => x.RePassword);

            Property(x => x.ActivationCode).HasColumnName("Aktivasyon Kodu");

            Property(x => x.Role).HasColumnName("Rolü");

            Property(x => x.IsBanned).HasColumnName("Yasaklımı");

            Property(x => x.IsActive).HasColumnName("Hesap Aktifmi");

            Property(x => x.Email).IsRequired().HasMaxLength(200).HasColumnName("E-Posta");

            
            Property(x => x.Name).IsRequired().HasColumnName("İsim").HasMaxLength(100);

            Property(x => x.SPName).IsRequired().HasColumnName("Soyisim").HasMaxLength(100);

            Property(x => x.Address).IsOptional().HasColumnName("İkamet Adresi").HasMaxLength(300);

            Property(x => x.BirthDate).IsOptional().HasColumnName("Dogum Tarihi").HasColumnType("datetime2");
        }
    }
}
