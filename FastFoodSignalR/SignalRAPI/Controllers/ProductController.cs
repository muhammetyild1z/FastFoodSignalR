using AutoMapper;
using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.DtoLayer.ProductDto;
using FastFoodSignalR.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SignalRAPI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productservice;
        private readonly IMapper _mapper;

        public ProductController(IProductService productservice, IMapper mapper)
        {
            _productservice = productservice;
            _mapper = mapper;
        }

        [HttpGet("ListProduct")]
        public IActionResult ListProduct()
        {    
            return Ok(_productservice.TGetListAll());
        }

        [HttpGet("GetByIdProduct")]
        public IActionResult GetByIdProduct(int id)
        {
            return Ok(_productservice.TGetById(id));
        }

        [HttpGet("GetProductWithCategory")]
        public IActionResult GetProductWithCategory()
        {
            return Ok(_mapper.Map<Product>(_productservice.TGetProductWithCategories()));
            //return Ok(_productservice.TGetProductWithCategories()); 
        }

        [HttpPost("CreateProduct")]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productservice.TAdd(_mapper.Map<Product>(createProductDto));
            return Ok("Urun Ekleme Basarili");
        }

        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct(int id, UpdateProductDto updateProductDto)
        {
            var value = _productservice.TGetById(id);
            _productservice.Update(_mapper.Map<Product>(updateProductDto),value);
            return Ok("Guncelleme Basarili");
        }

        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            _productservice.TDelete(_productservice.TGetById(id));
            return Ok("Silme Islemi Basarili");
        }
    }
}
