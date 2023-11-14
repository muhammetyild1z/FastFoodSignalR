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
    public class TestimonialManager : IGenericService<Testimonial>
    {
        ITestimonialDal _testimonial;

        public TestimonialManager(ITestimonialDal testimonial)
        {
            _testimonial = testimonial;
        }

        public void TAdd(Testimonial entity)
        {
            _testimonial.Add(entity);
        }

        public void TDelete(Testimonial entity)
        {
            _testimonial.Delete(entity);
        }

        public Testimonial TGetById(int Id)
        {
            return _testimonial.GetById(Id);
        }

        public List<Testimonial> TGetListAll()
        {
            return _testimonial.GetListAll();
        }

        public void Update(Testimonial entity, Testimonial unchanged)
        {
            _testimonial.Update(entity, unchanged);
        }
    }
}
