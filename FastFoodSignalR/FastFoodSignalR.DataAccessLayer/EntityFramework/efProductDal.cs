﻿using FastFoodSignalR.DataAccessLayer.Abstract;
using FastFoodSignalR.DataAccessLayer.Concrate;
using FastFoodSignalR.DataAccessLayer.Repositories;
using FastFoodSignalR.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.DataAccessLayer.EntityFramework
{
    public class efProductDal : GenericRepository<Product>, IProductDal
    {
        private readonly FastFoodContext _fastFoodContext;

        public efProductDal(FastFoodContext context, FastFoodContext fastFoodContext) : base(context)
        {
            _fastFoodContext = fastFoodContext;
        }
   
        public List<Product> GetIncludeProductWithCategory()
        {

            return
                _fastFoodContext.Products.Include(x => x.Category).ToList();
        }

     

        //public decimal HamburgerPriceAVG()
        //{
        //    var value = _fastFoodContext.Products.Where(x => x.Category.CategoryName == "Hamburgerler").Average(x => x.ProductPrice);
        //    if (value != null)
        //    {
        //        return value;
        //    }
        //    else
        //    {
        //        return value = 0;
        //    }
        //}


        public int ProductCount()
        {
            return _fastFoodContext.Products.Count();
        }

        public decimal ProductPriceAVG()
        {
            return _fastFoodContext.Products.Average(x => x.ProductPrice);
        }

        public (decimal, string) ProductPriceMax()
        {
            var maxPrice = _fastFoodContext.Products.Max(x => x.ProductPrice);
            var maxPriceName = _fastFoodContext.Products.First(x => x.ProductPrice == maxPrice).ProductName;
            return (maxPrice, maxPriceName);

        }

        public (decimal, string) ProductPriceMin()
        {
            var minPrice = _fastFoodContext.Products.Min(x => x.ProductPrice);
            var minPriceName = _fastFoodContext.Products.First(x => x.ProductPrice == minPrice).ProductName;
            return (minPrice, minPriceName);
        }
    }
}
