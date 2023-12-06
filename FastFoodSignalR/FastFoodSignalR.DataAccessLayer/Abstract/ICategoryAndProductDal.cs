﻿using FastFoodSignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.DataAccessLayer.Abstract
{
    public interface ICategoryAndProductDal:IGenericDal<CategoryAndProduct>
    {
        List<CategoryAndProduct> GetProductWithCategories();
    }
}