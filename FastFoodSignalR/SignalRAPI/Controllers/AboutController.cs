﻿using AutoMapper;
using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.DtoLayer.AboutDto;
using FastFoodSignalR.DtoLayer.BookingDto;
using FastFoodSignalR.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SignalRAPI.Controllers
{
    public class AboutController : Controller
    {

        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet("test")]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll();
            return Ok(values);
        }
        [HttpPost("ekle")]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            _aboutService.TAdd(_mapper.Map<About>(createAboutDto));
            return Ok("Ekleme Basarili..");
        }
        [HttpPut("guncelle")]
        public IActionResult UpdateAbout(int id , UpdateAboutDto updateAboutDto)
        {
            var value=_aboutService.TGetById(id);
            _aboutService.Update(_mapper.Map<About>(updateAboutDto), value);
            return Ok();
        }
        [HttpDelete("sil")]
        public IActionResult DeleteAbout(int id)
        { 
            var value= _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Silme Basarili");
        }
        [HttpGet("GetByIdAbout")]
        public IActionResult GetByIdAbout(int id)
        {
            var value=_aboutService.TGetById(id);
            return Ok(value);
        }
    }
}
