using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.DataAccessLayer.Abstract;
using FastFoodSignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.BusinessLayer.Concrate
{
    public class FeatureManager : IFeatureService
    {
       IFeatureDal _feature;

        public FeatureManager(IFeatureDal feature)
        {
            _feature = feature;
        }

        public void TAdd(Feature entity)
        {
            _feature.Add(entity);
        }

        public void TDelete(Feature entity)
        {
            _feature.Delete(entity);
        }

        public Feature TGetById(int Id)
        {
            return _feature.GetById(Id);
        }

        public List<Feature> TGetListAll()
        {
            return _feature.GetListAll();
        }

      

        public void Update(Feature entity, Feature unchanged)
        {
            _feature.Update(entity, unchanged);
        }
    }
}
