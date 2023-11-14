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
    public class BookingManager : IBookingService
    {
        IBookingDal _booking;

        public BookingManager(IBookingDal booking)
        {
            _booking = booking;
        }

        public void TAdd(Booking entity)
        {
            _booking.Add(entity);
        }

        public void TDelete(Booking entity)
        {
            _booking.Delete(entity);
        }

        public Booking TGetById(int Id)
        {
           return _booking.GetById(Id);    
        }

        public List<Booking> TGetListAll()
        {
           return _booking.GetListAll();
        }

        public void Update(Booking entity, Booking unchanged)
        {
            _booking.Update(entity, unchanged);    
        }
    }
}
