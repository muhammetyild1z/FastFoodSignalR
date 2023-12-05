﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T:class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity, T unchanged);
        T GetById(int Id);
        
        List<T> GetListAll();
       
    }
}
