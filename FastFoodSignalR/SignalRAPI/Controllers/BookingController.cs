using AutoMapper;
using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.DtoLayer.BookingDto;
using FastFoodSignalR.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SignalRAPI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingservice;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingservice, IMapper mapper)
        {
            _bookingservice = bookingservice;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooking()
        {
            var value = _bookingservice.TGetListAll();
            return  Ok(value);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
          _bookingservice.TAdd(_mapper.Map<Booking>(createBookingDto));



            return Ok("Rezervasyon Eklendi");
        }
        [HttpPut]
        public IActionResult UpdateBooking(int id, UpdateBookingDto updateBookingDto)
        {
            var value = _bookingservice.TGetById(id);
            _bookingservice.Update(_mapper.Map<Booking>(updateBookingDto), value);
            return Ok("Rezervasyon Guncellendi");
        }
        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            _bookingservice.TDelete(_bookingservice.TGetById(id));  
            return Ok("silme basarili");
        }
        [HttpGet("GetByIdBooking")]
        public IActionResult GetByIdBooking(int id)
        {
           var value= _bookingservice.TGetById(id);
            return Ok(value);
        }
    }
}
