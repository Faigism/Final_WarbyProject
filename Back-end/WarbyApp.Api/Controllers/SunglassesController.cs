using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarbyApp.Service.Dtos.SunglassesDtos;
using WarbyApp.Service.Interfaces;

namespace WarbyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SunglassesController : ControllerBase
    {
        private readonly ISunglassesService _sunglassesService;

        public SunglassesController(ISunglassesService sunglassesService)
        {
            _sunglassesService = sunglassesService;
        }
        [HttpPost("")]
        public IActionResult Create([FromForm] SunglassesCreateDto createDto)
        {
            return StatusCode(201, _sunglassesService.Create(createDto));
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromForm] SunglassesEditDto editDto)
        {
            _sunglassesService.Edit(id, editDto);
            return NoContent();
        }
        [HttpGet("{id}")]
        public ActionResult<SunglassesGetDto> Get(int id)
        {
            return Ok(_sunglassesService.GetById(id));
        }
        [HttpGet("")]
        public ActionResult<List<SunglassesGetAllDto>> GetAll()
        {
            return Ok(_sunglassesService.GetAll());
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _sunglassesService.Delete(id);
            return NoContent();
        }
    }
}
