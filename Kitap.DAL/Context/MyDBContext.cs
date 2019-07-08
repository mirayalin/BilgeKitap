using Kitap.DAL.Strategy;
using Kitap.MAP.Options;
using Kitap.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.DAL.Context
{
   public class MyDBContext:DbContext
    {
        public MyDBContext():base("KitapDB")
        {
            //bu alanda iki kez validation calıstırıp password length yüzünden hashleme sonrasındaki kontrolü tekrar yapmasını istemiyorsanız
            Configuration.ValidateOnSaveEnabled = false;

            Database.SetInitializer(new MyInitializer());//Hazır verilerin çekilebilmesi için bu kod satırı gereklidir.
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new AuthorMap());
            modelBuilder.Configurations.Add(new BookMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new ShipperMap());
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
    }
}
