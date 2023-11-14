using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.DataAccessLayer.Abstract;
using FastFoodSignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.BusinessLayer.Concrate
{
    public class DiscountManager : IDiscountService
    {
        IDiscountDal _discount;

        public DiscountManager(IDiscountDal discount)
        {
            _discount = discount;
        }

        public void TAdd(Discount entity)
        {
            _discount.Add(entity);
        }

        public void TDelete(Discount entity)
        {
            _discount.Delete(entity);
        }

        public Discount TGetById(int Id)
        {
            return _discount.GetById(Id);
        }

        public List<Discount> TGetListAll()
        {
            return _discount.GetListAll();
        }

        public void Update(Discount entity, Discount unchanged)
        {
            _discount.Update(entity, unchanged);    
        }
    }
}
