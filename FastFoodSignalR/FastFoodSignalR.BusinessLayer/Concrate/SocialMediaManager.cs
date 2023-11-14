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
    public class SocialMediaManager : ISocialMediaService
    {
        ISocialMediaDal _socialMedia;

        public SocialMediaManager(ISocialMediaDal socialMedia)
        {
            _socialMedia = socialMedia;
        }

        public void TAdd(SocialMedia entity)
        {
            _socialMedia.Add(entity);
        }

        public void TDelete(SocialMedia entity)
        {
            _socialMedia.Delete(entity);
        }

        public SocialMedia TGetById(int Id)
        {
            return _socialMedia.GetById(Id);
        }

        public List<SocialMedia> TGetListAll()
        {
            return _socialMedia.GetListAll();
        }

        public void Update(SocialMedia entity, SocialMedia unchanged)
        {
            _socialMedia.Update(entity, unchanged);
        }
    }
}
