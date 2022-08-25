﻿using AspEntity.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
