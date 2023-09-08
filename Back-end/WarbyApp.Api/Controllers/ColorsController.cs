using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarbyApp.Service.Dtos.ColorDtos;
using WarbyApp.Service.Interfaces;

namespace WarbyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }
        [HttpPost("")]
        public IActionResult Create([FromForm] ColorCreateDto createDto)
        {
            return StatusCode(201, _colorService.Create(createDto));
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromForm] ColorEditDto editDto)
        {
            _colorService.Edit(id, editDto);
            return NoContent();
        }
        [HttpGet("all")]
        public ActionResult<List<ColorGetAllDto>> GetAll()
        {
            return Ok(_colorService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_colorService.GetById(id));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _colorService.Delete(id);
            return NoContent();
        }
    }
}
