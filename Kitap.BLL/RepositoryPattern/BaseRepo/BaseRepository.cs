using Kitap.BLL.RepositoryPattern.InterfaceRepo;
using Kitap.BLL.SingletonPattern;
using Kitap.DAL.Context;
using Kitap.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.BLL.RepositoryPattern.BaseRepo
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        //Asagıda global alanda singletonpatterni cagırmaktansa BaseRepository tetiklendigi anda constructor'inda olusmasını sagladık.
        protected MyDBContext db;
        public BaseRepository()
        {
            db = DBTool.DBInstance;

        }
        //Güvenlik açısından dışarıdan çağrılmasın diye Save metodunu private yaptık.
        private void Save()
        {
            db.SaveChanges();
        }

        public void Add(T item)
        {
            db.Set<T>().Add(item);
            Save(); 
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
           return db.Set<T>().Any(exp);

        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Where(exp).ToList();
        }

        public T Default(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().FirstOrDefault(exp);
        }

        public void Delete(T item)
        {
            item.Status = MODEL.Enums.DataStatus.Deleted;
            Save();
        }

        public T GetByID(int id)
        {
            return db.Set<T>().Find(id);
        }

        public int GetLastAdded()
        {
            return db.Set<T>().OrderByDescending(x => x.ID).FirstOrDefault().ID;
        }

        public object ListAnonymus(Expression<Func<T, object>> exp)
        {
            return db.Set<T>().Select(exp).ToList();
        }

        public virtual List<T> SelectActives()
        {
            return db.Set<T>().Where(x => x.Status != MODEL.Enums.DataStatus.Deleted).ToList();
        }

        public List<T> SelectAll()
        {
            return db.Set<T>().ToList();
        }

        public List<T> SelectDeleteds()
        {
            return db.Set<T>().Where(x => x.Status == MODEL.Enums.DataStatus.Deleted).ToList();
        }

        public List<T> SelectModifieds()
        {
            return db.Set<T>().Where(x => x.Status == MODEL.Enums.DataStatus.Updated).ToList();
        }

        public void SpecialDelete(int id)
        {
             db.Set<T>().Remove(GetByID(id));
            Save();

        }

        public void Update(T item)
        {
            item.Status = MODEL.Enums.DataStatus.Updated;

            item.ModifiedDate = DateTime.Now;

            T guncellenecek = GetByID(item.ID);

            db.Entry(guncellenecek).CurrentValues.SetValues(item);
            Save();
        }
    }
}
