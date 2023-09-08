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
        /// <summary>
        /// Creates a new eyeglasses product.
        /// </summary>
        /// <remarks>
        /// This API method is used to create a new eyeglasses product. Follow the steps below to make a successful request:
        /// 
        /// 1. Create an HTTP POST request and send it to the api/brands endpoint.
        /// 
        /// 2. Ensure that the request is configured as "multipart/form-data."
        /// 
        /// 3. Add the following form parameters to the request body:
        ///    - Name (string): Eyeglasses name
        ///    - Material (string): Eyeglasses material
        ///    - CostPrice (decimal): Cost price of the eyeglasses
        ///    - SalePrice (decimal): Selling price of the eyeglasses
        ///    - DiscountPercent (decimal): Discount percentage
        ///    - Image (file): Eyeglasses image (File upload)
        /// 
        /// 4. After sending the request, you will receive a response containing the created eyeglasses product.
        /// 
        /// Sample Request:
        /// 
        /// POST api/brands
        /// 
        /// Form Parameters:
        /// - Name: "Stylish Sunglasses"
        /// - Material: "Acrylic"
        /// - CostPrice: 30.99
        /// - SalePrice: 59.99
        /// - DiscountPercent: 20.0
        /// - Image: [Eyeglasses image file]
        /// 
        /// Response:
        /// HTTP 201 Created
        /// Eyeglasses product successfully created.
        /// </remarks>
        /// <param name="createDto"></param>
        /// <returns></returns>
        /// <response code="201">The eyewear product has been successfully created.</response>
        /// <response code="400">Invalid request data.</response>
        /// <response code="404">No source found.</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpPost("")]
        public IActionResult Create([FromForm] EyeglassesCreateDto createDto)
        {
            return StatusCode(201, _eyeglassesService.Create(createDto));
        }
        /// <summary>
        /// Organizes a specific eyewear product.
        /// </summary>
        /// <remarks>
        /// This API method is used to edit a specific eyewear product. Follow the steps below to make a successful request:
        /// 
        /// 1. Create an HTTP POST request and send it to api/eyeglasses/{id} (id is the ID of the eyewear product you want to edit).
        /// 
        /// 2. Ensure that the request is configured as "multipart/form-data."
        /// 
        /// 3. Add the following form parameters to the request body:
        ///    - Name (string): Eyeglasses name
        ///    - Material (string): Eyeglasses material
        ///    - CostPrice (decimal): Cost price of the eyeglasses
        ///    - SalePrice (decimal): Selling price of the eyeglasses
        ///    - DiscountPercent (decimal): Discount percentage
        ///    - Image (file): Eyeglasses image (File upload)
        /// 
        /// 4. After sending the request, you will receive a response containing the created eyeglasses product.
        /// 
        /// Sample Request:
        /// 
        /// POST api/eyeglasses/{id}
        /// 
        /// Form Parameters:
        /// - Name: "Stylish Sunglasses"
        /// - Material: "Acrylic"
        /// - CostPrice: 30.99
        /// - SalePrice: 59.99
        /// - DiscountPercent: 20.0
        /// - Image: [Eyeglasses image file]
        /// 
        /// Response:
        /// HTTP 200 OK
        /// The eyeglasses product was successfully edited..
        /// </remarks>
        /// <param name="id">Identity of the eyewear product to be issued</param>
        /// <param name="editDto">Eyeglasses regulation data</param>
        /// <returns></returns>
        /// <response code="200">The eyeglasses product was successfully edited.</response>
        /// <response code="400">Invalid request data.</response>
        /// <response code="404">No source found.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
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
        [HttpGet("all")]
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
