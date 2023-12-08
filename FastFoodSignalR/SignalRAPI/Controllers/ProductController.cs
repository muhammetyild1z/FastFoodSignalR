using AutoMapper;
using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.DtoLayer.ProductDto;
using FastFoodSignalR.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productservice;     
        private readonly IMapper _mapper;


        public ProductController(IProductService productservice, IMapper mapper)
        {
            _productservice = productservice;
            _mapper = mapper;
            
        }
      

        [HttpGet("GetByIdProduct")]
        public IActionResult GetByIdProduct(int id)
        {       
            return Ok(_productservice.TGetProductById(id));
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
            _productservice.Update(_mapper.Map<Product>(updateProductDto), value);
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
