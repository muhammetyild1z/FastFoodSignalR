using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.DtoLayer.BookingDto;
using Microsoft.AspNetCore.Mvc;

namespace SignalRAPI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingservice;

        public BookingController(IBookingService bookingservice)
        {
            _bookingservice = bookingservice;
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
            _bookingservice.TAdd(createBookingDto);
            return Ok("Rezervasyon Eklendi");
        }
        [HttpPut]
        public IActionResult UpdateBooking(int id,UpdateBookingDto updateBookingDto) 
        {
            var value=_bookingservice.TGetById(id);
            _bookingservice.Update(updateBookingDto, value);
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
