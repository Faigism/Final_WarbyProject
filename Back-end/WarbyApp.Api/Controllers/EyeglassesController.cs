using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarbyApp.Service.Dtos.EyeglassesDtos;
using WarbyApp.Service.Interfaces;

namespace WarbyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EyeglassesController : ControllerBase
    {
        private readonly IEyeglassesService _eyeglassesService;

        public EyeglassesController(IEyeglassesService eyeglassesService)
        {
            _eyeglassesService = eyeglassesService;
        }
        [HttpPost("")]
        public IActionResult Create([FromForm] EyeglassesCreateDto createDto)
        {
            return StatusCode(201, _eyeglassesService.Create(createDto));
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromForm] EyeglassesEditDto editDto)
        {
            _eyeglassesService.Edit(id, editDto);
            return NoContent();
        }
        [HttpGet("{id}")]
        public ActionResult<EyeglassesGetDto> Get(int id)
        {
            return Ok(_eyeglassesService.GetById(id));
        }
        [HttpGet("")]
        public ActionResult<List<EyeglassesGetAllDto>> GetAll()
        {
            return Ok(_eyeglassesService.GetAll());
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _eyeglassesService.Delete(id);
            return NoContent();
        }
    }
}
