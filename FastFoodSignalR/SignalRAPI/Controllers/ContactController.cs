using AutoMapper;
using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.DtoLayer.AboutDto;
using FastFoodSignalR.DtoLayer.ContactDto;
using FastFoodSignalR.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SignalRAPI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet("ListContact")]
        public IActionResult AboutList()
        {
            var values = _contactService.TGetListAll();
            return Ok(values);
        }

        [HttpGet("GetByIdContact")]
        public IActionResult GetByIdAbout(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }

        [HttpPost("CreateContact")]
        public IActionResult CreateAbout(CreateContactDto createContactDto)
        {
            _contactService.TAdd(_mapper.Map<Contact>(createContactDto));
            return Ok("Ekleme Basarili..");
        }

        [HttpPut("UpdateContact")]
        public IActionResult UpdateAbout(int id, UpdateContactDto updateContactDto)
        {
            var value = _contactService.TGetById(id);
            _contactService.Update(_mapper.Map<Contact>(updateContactDto), value);
            return Ok();
        }

        [HttpDelete("DeleteContact")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok("Silme Basarili");
        }
    }
}
