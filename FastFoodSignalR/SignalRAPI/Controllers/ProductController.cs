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
        
        [HttpGet("THamburgerPriceAVG")]
        public IActionResult THamburgerPriceAVG()
        {
            var products = _productservice.THamburgerPriceAVG();
            return Ok(products);
        }

        [HttpGet("ListProduct")]
        public IActionResult ListProduct()
        {
            var products = _productservice.TGetIncludeProductWithCategory();
            return Ok(products);
        }

        [HttpGet("ProductPriceAVG")]
        public IActionResult ProductPriceAVG()
        {
            var products = _productservice.TProductPriceAVG();
            return Ok(products);
        }

        [HttpGet("ProductPriceMax")]
        public IActionResult ProductPriceMax()
        {
            var products = _productservice.TProductPriceMax();
            return Ok(products);
        }

        [HttpGet("ProductPriceMin")]
        public IActionResult ProductPriceMin()
        {
            var products = _productservice.TProductPriceMin();
            return Ok(products);
        }

        [HttpGet("GetByIdProduct/{id}")]
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

        [HttpPut("UpdateProduct/{id}")]
        public IActionResult UpdateCategory( UpdateProductDto updateProductDto)
        {
            var value = _productservice.TGetById(updateProductDto.ProductID);
            _productservice.Update(_mapper.Map<Product>(updateProductDto), value);
            return Ok();
        }

        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var removeProduct = _productservice.TGetById(id);
            if (removeProduct==null)
            {
                return BadRequest("Kullanici Bulunamadi..");
            }
            
            _productservice.TDelete(removeProduct);
            return Ok("Silme Islemi Basarili");
        }
    }
}
