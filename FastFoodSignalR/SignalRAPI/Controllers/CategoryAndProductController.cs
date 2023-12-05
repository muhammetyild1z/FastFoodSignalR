using AutoMapper;
using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.DtoLayer.AboutDto;
using FastFoodSignalR.DtoLayer.CategoryAndProductDto;
using FastFoodSignalR.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SignalRAPI.Controllers
{
    public class CategoryAndProductController : Controller
    {

        private readonly ICategoryAndProductService _categoryAndProductService;
        private readonly IMapper _mapper;

        public CategoryAndProductController(ICategoryAndProductService categoryAndProductService, IMapper mapper)
        {
            _categoryAndProductService = categoryAndProductService;
            _mapper = mapper;
        }

        [HttpGet("ListCategoryAndProduct")]
        public IActionResult ListCategoryAndProduct()
        {
            var values = _categoryAndProductService.TGetListAll();
            return Ok(values);
        }

        [HttpGet("GetByIdCategoryAndProduct")]
        public IActionResult GetByIdCategoryAndProduct(int id)
        {
            var value = _categoryAndProductService.TGetCategoryById(id);
            return Ok(value);
        }
        [HttpGet("GetProductWithCategory")]
        public IActionResult GetProductWithCategory()
        {
            var value = _categoryAndProductService.TGetProductWithCategories().Select(x=> new {x.Product.ProductName, x.Category.CategoryName});
            return Ok(value);
        }

        [HttpPost("CreateCategoryAndProduct")]
        public IActionResult CreateCategoryAndProduct(CreateCategoryAndProductDto createCategoryAndProductDto)
        {
             _categoryAndProductService.TAdd(_mapper.Map<CategoryAndProduct>(createCategoryAndProductDto));
            return Ok("Ekleme Basarili..");
        }

        [HttpPut("UpdateCategoryAndProduct")]
        public IActionResult UpdateCategoryAndProduct(int id, UpdateCategoryAndProductDto updateCategoryAndProductDto)
        {
            var value = _categoryAndProductService.TGetById(id);
            _categoryAndProductService.Update(_mapper.Map<CategoryAndProduct>(updateCategoryAndProductDto), value);
            return Ok();
        }

        [HttpDelete("DeleteCategoryAndProduct")]
        public IActionResult DeleteCategoryAndProduct(int id)
        {
            var value = _categoryAndProductService.TGetById(id);
            _categoryAndProductService.TDelete(value);
            return Ok("Silme Basarili");
        }

    }
}
