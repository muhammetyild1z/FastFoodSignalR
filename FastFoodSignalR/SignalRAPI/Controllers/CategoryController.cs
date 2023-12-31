﻿using AutoMapper;
using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.DtoLayer.AboutDto;
using FastFoodSignalR.DtoLayer.CategoryDto;
using FastFoodSignalR.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("ListCategory")]
        public IActionResult ListCategory()
        {
            var values = _categoryService.TGetListAll();
            return Ok(values);
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            var values = _categoryService.TCategoryCount();
            return Ok(values);
        }

        [HttpGet("AktiveCategoryCount")]
        public IActionResult AktiveCategoryCount()
        {
            var values = _categoryService.TAktiveCategoryCount();
            return Ok(values);
        }

        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            var values = _categoryService.TPassiveCategoryCount();
            return Ok(values);
        }

        [HttpGet("GetByIdCategory/{id}")]
        public IActionResult GetByIdCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            return Ok(value);
        }
       
        [HttpPost("CreateCategory")]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            _categoryService.TAdd(_mapper.Map<Category>(createCategoryDto));
            return Ok("Ekleme Basarili..");
        }

        [HttpPut("UpdateCategory/{id}")]
        public IActionResult UpdateCategory(int id, UpdateCategoryDto updateCategoryDto)
        {
            var value = _categoryService.TGetById(id);
            _categoryService.Update(_mapper.Map<Category>(updateCategoryDto), value);
            return Ok();
        }
       
        [HttpDelete("DeleteCategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            if (value == null)
            {
                return NotFound(); 
            }
            _categoryService.TDelete(value);
            return Ok("Silme Basarili");
        }
    }
}
