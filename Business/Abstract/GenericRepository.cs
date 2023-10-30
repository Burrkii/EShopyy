using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public class GenericRepository<T> : IRepository<T> where T : class, new()
    {
        DataDbContext dataDbContext = new DataDbContext(string.Format(string.Empty));
        DbSet<T> data;
        public GenericRepository()
        {
            data = dataDbContext.Set<T>();
        }

        public void Add(T entity)
        {
           data.Add(entity);
            dataDbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            data.Remove(entity);
            dataDbContext.SaveChanges();
        }

        public List<T> GetAll()
        {
           return data.ToList();
        }

        public T GetById(int id)
        {
            return data.Find(id);

        }

        public void Update(T entity)
        {
           dataDbContext.Entry<T>(entity).State= EntityState.Modified;
            dataDbContext.SaveChanges();
        }
    }
}
