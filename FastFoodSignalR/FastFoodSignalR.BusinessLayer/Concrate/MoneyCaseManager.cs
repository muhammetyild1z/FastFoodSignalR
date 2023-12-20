using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.DataAccessLayer.Abstract;
using FastFoodSignalR.DataAccessLayer.Concrate;
using FastFoodSignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.BusinessLayer.Concrate
{
    public class MoneyCaseManager : IMoneyCaseService
    {
       
        private readonly IMoneyCaseDal _moneyCase;

        public MoneyCaseManager(IMoneyCaseDal moneyCase)
        {
            _moneyCase = moneyCase;
        }

        public void TAdd(MoneyCase entity)
        {
            _moneyCase.Add(entity);
        }

        public void TDelete(MoneyCase entity)
        {
            _moneyCase.Delete(entity);
        }

        public MoneyCase TGetById(int Id)
        {
            return _moneyCase.GetById(Id);  
        }

        public List<MoneyCase> TGetListAll()
        {
            return _moneyCase.GetListAll();
        }

        public decimal TTodayEarning()
        {
            return _moneyCase.TodayEarning();
        }

        public void Update(MoneyCase entity, MoneyCase unchanged)
        {
            _moneyCase.Update(entity, unchanged);
        }
    }
}
