﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;
using Deneme.Core.Entities;

namespace Deneme.Core.DataAccess
{
    public interface IEntityRespository<T> where T: class,IEntity,new()
    {
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetList(Expression<Func<T, bool>> filter=null);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
