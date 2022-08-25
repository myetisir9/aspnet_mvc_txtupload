using AspEntity.Abstract;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class Repository<T, C> : IRepository<T> where T : class, IEntity, new() where C : DbContext, new()
    {
        public void Add(T entity)
        {
            using (C context = new C())
            {
                context.Add(entity).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (C context = new C())
            {
                context.Add(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }


        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            using (C context = new C())
            {
              return  context.Set<T>().SingleOrDefault(filter);
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (C context=new C())
            {
                return filter==null? context.Set<T>().ToList():context.Set<T>().Where(filter).ToList();
            }
        }

        public void Update(T entity)
        {
            using (C context= new C())
            {
                context.Add(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
