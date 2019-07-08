using Kitap.DAL.Context;
using Kitap.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.DAL.Strategy
{
   public class MyInitializer:CreateDatabaseIfNotExists<MyDBContext>
    {
        protected override void Seed(MyDBContext context)
        {
            //Admin Ekleme
            AppUser ap1 = new AppUser();
            ap1.UserName = "miray";
            ap1.Password = "1234";
            ap1.Role = MODEL.Enums.Role.Admin;
            ap1.IsActive = true;
            ap1.Email = "mirayalinn@gmail.com";
            ap1.Name = "Miray";
            ap1.SPName = "Alın";
            ap1.Address = "Fatih";
            ap1.BirthDate = new DateTime(1993, 10, 16);

            context.AppUsers.Add(ap1);
            context.SaveChanges();

            AppUser ap2 = new AppUser();
            ap2.UserName = "habip";
            ap2.Password = "1234";
            ap2.Role = MODEL.Enums.Role.Admin;
            ap2.IsActive = true;
            ap2.Email = "habiptirampaci@gmail.com";
            ap2.Name = "Habip";
            ap2.SPName = "Tırampacı";
            ap2.Address = "Kadıköy";
            ap2.BirthDate = new DateTime(1989, 12, 11);
            
            context.AppUsers.Add(ap2);
            context.SaveChanges();

            //Normal users

            for (int i = 0; i < 20; i++)
            {
                AppUser apMember = new AppUser();
                apMember.UserName = FakeData.NameData.GetFirstName();
                apMember.Password = FakeData.TextData.GetAlphaNumeric(8);
                apMember.IsActive = true;
                apMember.Email = FakeData.TextData.GetAlphabetical(6) + "@gmail.com";
                apMember.Name = FakeData.NameData.GetFirstName();
                apMember.SPName = FakeData.NameData.GetSurname();
                apMember.Address = FakeData.PlaceData.GetAddress();
                apMember.BirthDate = FakeData.DateTimeData.GetDatetime();

                context.AppUsers.Add(apMember);
                context.SaveChanges();
            }

            //Yazar ekleme
            

            for (int i = 0; i < 30; i++)
            {
                Author a = new Author();
                a.Name = FakeData.NameData.GetFirstName();
                a.SPName = FakeData.NameData.GetSurname();
                context.Authors.Add(a);
                context.SaveChanges();
            }


            

            //Category Ekleme
            for (int i = 0; i < 10; i++)
            {
                Category c = new Category();

                c.CategoryName = FakeData.NameData.GetFirstName();
                c.Description = FakeData.TextData.GetSentence();

                context.Categories.Add(c);

                for (int k = 0; k < 50; k++)
                {
                    Random rnd = new Random();
                    int id = context.Authors.Find(rnd.Next(1, 31)).ID;

                    Book b = new Book();
                    b.Name = FakeData.NameData.GetFullName();
                    b.SPName = FakeData.TextData.GetSentence();
                    b.UnitPrice = FakeData.NumberData.GetNumber(10, 100);
                    b.UnitInStock = Convert.ToInt16(FakeData.NumberData.GetNumber(10, 200));
                    b.Publisher = FakeData.NameData.GetCompanyName();
                    b.AuthorID = id; //=rnd.Next(1,31); şeklinde de yazılabilir.
                    b.ImagePath = "/Pictures/images.png";
                    c.Books.Add(b);
                }

            }
            context.SaveChanges();


            
        }
    }
}
