using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }

        public void Delete(T t)
        {
            var deletedEntity = c.Entry(t);
            deletedEntity.State = EntityState.Deleted;
            c.SaveChanges();
        }

        public T TGetByID(int id)
        {
            return _object.Find(id);
        }

        public List<T> GetListAll()
        {
            return _object.ToList();
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Insert(T t)
        {
            var addedEntity = c.Entry(t);
            addedEntity.State = EntityState.Added;
            c.SaveChanges();
        }

        public void Update(T t)
        {
            var uptadedEntity = c.Entry(t);
            uptadedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
