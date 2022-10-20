﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IBaseRepository<T> where T : class
    {
        T GetFirstOrDefault(Expression<Func<T,bool>> Filter ,string? includeProperties=null, bool tracked = true);
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? Filter=null, string? includeProperties=null);
        void Add (T entity);
        void Remove (T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
