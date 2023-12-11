using AutoMapper;
using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.DtoLayer.AboutDto;
using FastFoodSignalR.DtoLayer.ContactDto;
using FastFoodSignalR.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SignalRAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        //[HttpGet("ListContact")]
        //public IActionResult ListContact()
        //{
        //    var values = _contactService.TGetListAll();
        //    return Ok(values);
        //}

        //[HttpPost("CreateContact")]
        //public IActionResult CreateContact(CreateContactDto createContactDto)
        //{
        //    _contactService.TAdd(_mapper.Map<Contact>(createContactDto));
        //    return Ok("Ekleme Basarili..");
        //}

        //[HttpDelete("DeleteContact")]
        //public IActionResult DeleteAbout(int id)
        //{
        //    var value = _contactService.TGetById(id);
        //    _contactService.TDelete(value);
        //    return Ok("Silme Basarili");
        //}

        [HttpGet("GetByIdContact/{id}")]
        public IActionResult GetByIdContact(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }

      
        [HttpPut("UpdateContact/{id}")]
        public IActionResult UpdateContact(int id, UpdateContactDto updateContactDto)
        {
            var value = _contactService.TGetById(id);
            _contactService.Update(_mapper.Map<Contact>(updateContactDto), value);
            return Ok();
        }

    
    }
}
