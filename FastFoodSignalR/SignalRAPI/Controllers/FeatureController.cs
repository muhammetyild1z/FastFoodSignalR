using AutoMapper;
using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.DtoLayer.DiscountDto;
using FastFoodSignalR.DtoLayer.FeatureDto;
using FastFoodSignalR.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SignalRAPI.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet("ListFeature")]
        public IActionResult ListFeature()
        {
            var values = _featureService.TGetListAll();
            return Ok(values);
        }

        [HttpGet("GetByIdFeature")]
        public IActionResult GetByIdFeature(int id)
        {
            var value = _featureService.TGetById(id);
            return Ok(value);
        }

        [HttpPost("CreateFeature")]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            _featureService.TAdd(_mapper.Map<Feature>(createFeatureDto));
            return Ok("Ekleme Basarili..");
        }

        [HttpPut("UpdateFeature")]
        public IActionResult UpdateFeature(int id, UpdateFeatureDto updateFeatureDto)
        {
            var value = _featureService.TGetById(id);
            _featureService.Update(_mapper.Map<Feature>(updateFeatureDto), value);
            return Ok();
        }

        [HttpDelete("DeleteFeature")]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetById(id);
            _featureService.TDelete(value);
            return Ok("Silme Basarili");
        }
    }
}
