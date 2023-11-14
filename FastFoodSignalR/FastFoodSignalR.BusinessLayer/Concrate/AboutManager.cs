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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TAdd(About entity)
        {
            _aboutDal.Add(entity);
        }

        public void TDelete(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public About TGetById(int Id)
        {
           return _aboutDal.GetById(Id);
        }

        public List<About> TGetListAll()
        {
           return _aboutDal.GetListAll();
        }

        public void Update(About entity, About unchanged)
        {
            _aboutDal.Update(entity, unchanged);
        }
    }
}
