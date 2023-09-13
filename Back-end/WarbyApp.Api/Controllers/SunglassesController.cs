using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WarbyApp.Service.Dtos.Common;
using WarbyApp.Service.Dtos.EyeglassesDtos;
using WarbyApp.Service.Dtos.SunglassesDtos;
using WarbyApp.Service.Implementations;
using WarbyApp.Service.Interfaces;

namespace WarbyApp.Api.Controllers
{
    //[Authorize(Roles = "SuperAdmin, Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SunglassesController : ControllerBase
    {
        private readonly ISunglassesService _sunglassesService;

        public SunglassesController(ISunglassesService sunglassesService)
        {
            _sunglassesService = sunglassesService;
        }
        /// <summary>
        /// Creates a new sunglasses product.
        /// </summary>
        /// <remarks>
        /// This API method is used to create a new sunglasses product. Follow the steps below to make a successful request:
        /// 
        /// 1. Create an HTTP POST request and send it to the api/sunglasses endpoint.
        /// 
        /// 2. Ensure that the request is configured as "multipart/form-data."
        /// 
        /// 3. Add the following form parameters to the request body:
        ///    - Name (string): Sunglasses name
        ///    - Material (string): Sunglasses material
        ///    - CostPrice (decimal): Cost price of the sunglasses
        ///    - SalePrice (decimal): Selling price of the sunglasses
        ///    - DiscountPercent (decimal): Discount percentage
        ///    - Image (file): Sunglasses image (File upload)
        /// 
        /// 4. After sending the request, you will receive a response containing the created sunglasses product.
        /// 
        /// Sample Request:
        /// 
        /// POST api/sunglasses
        /// 
        /// Form Parameters:
        /// - Name: "Stylish Sunglasses"
        /// - Material: "Acrylic"
        /// - CostPrice: 30.99
        /// - SalePrice: 59.99
        /// - DiscountPercent: 20.0
        /// - Image: [Sunglasses image file]
        /// - ColorId: 1
        /// 
        /// Response:
        /// HTTP 201 Created
        /// Sunglasses product successfully created.
        /// </remarks>
        /// <param name="createDto"></param>
        /// <returns></returns>
        /// <response code="201">The sunglasses product has been successfully created.</response>
        /// <response code="400">Invalid request data.</response>
        /// <response code="404">No source found.</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpPost("")]
        public IActionResult Create([FromForm] SunglassesCreateDto createDto)
        {
            return StatusCode(201, _sunglassesService.Create(createDto));
        }
        /// <summary>
        /// Organizes a specific sunglasses product.
        /// </summary>
        /// <remarks>
        /// This API method is used to edit a specific sunglasses product. Follow the steps below to make a successful request:
        /// 
        /// 1. Create an HTTP POST request and send it to api/sunglasses/{id} (id is the ID of the sunglasses product you want to edit).
        /// 
        /// 2. Ensure that the request is configured as "multipart/form-data."
        /// 
        /// 3. Add the following form parameters to the request body:
        ///    - Name (string): Sunglasses name
        ///    - Material (string): Sunglasses material
        ///    - CostPrice (decimal): Cost price of the sunglasses
        ///    - SalePrice (decimal): Selling price of the sunglasses
        ///    - DiscountPercent (decimal): Discount percentage
        ///    - Image (file): Sunglasses image (File upload)
        /// 
        /// 4. After sending the request, you will receive a response containing the created sunglasses product.
        /// 
        /// Sample Request:
        /// 
        /// POST api/sunglasses/{id}
        /// 
        /// Form Parameters:
        /// - "Name": "Stylish sunglasses"
        /// - "Material": "Acrylic"
        /// - "CostPrice": 30.99
        /// - "SalePrice": 59.99
        /// - "DiscountPercent: 20.0
        /// - "Image": [Sunglasses image file]
        /// - "ColorIdsToAdd": 1
        /// - "ColorIdsToRemove": 2
        /// 
        /// Response:
        /// HTTP 200 OK
        /// The sunglasses product was successfully edited..
        /// </remarks>
        /// <param name="id">Identity of the sunglasses product to be issued</param>
        /// <param name="editDto">Sunglasses regulation data</param>
        /// <returns></returns>
        /// <response code="204">The sunglasses product was successfully edited.</response>
        /// <response code="400">Invalid request data.</response>
        /// <response code="404">No source found.</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromForm] SunglassesEditDto editDto)
        {
            _sunglassesService.Edit(id, editDto);
            return NoContent();
        }
        /// <summary>
        /// Retrieves information about a specific sunglasses product.
        /// </summary>
        /// <remarks>
        /// This API method is used to retrieve details about a specific sunglasses product by its ID.
        /// 
        /// 1. Create an HTTP GET request and send it to api/sunglasses/{id} (id is the ID of the sunglasses product you want to retrieve).
        /// 
        /// 2.  After sending the request, you will receive a response containing the details of the sunglasses product.
        /// 
        /// Sample Request:
        /// 
        /// GET api/sunglasses/{id}
        /// 
        /// Form Parameters:
        /// - "Id": 1,
        /// - "Name": "Stylish sunglasses",
        /// - "Material": "Acrylic",
        /// - "CostPrice": 30.99,
        /// - "SalePrice": 59.99,
        /// - "DiscountPercent": 20.0,
        /// - "ImageUrl": "https://example.com/images/sunglasses1.jpg",
        /// - "Colors":
        ///   - "ColorId": 1,
        ///   - "Color": 
        ///     - "ColorName": "Black",
        ///     - "ColorImage": "https://example.com/images/black_color.jpg"
        /// Response:
        /// HTTP 200 OK
        /// 
        /// The sunglasses product was successfully edited..
        /// </remarks>
        /// <param name="id">Identity of the sunglasses product to retrieve</param>
        /// <returns>The details of the sunglasses product</returns>
        /// <response code="200">The sunglasses product details were successfully retrieved.</response>
        /// <response code="404">No sunglasses product found with the specified ID.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public ActionResult<SunglassesGetDto> Get(int id)
        {
            return Ok(_sunglassesService.GetById(id));
        }
        /// <summary>
        /// Retrieves a list of all sunglasses products.
        /// </summary>
        /// <remarks>
        /// This API method is used to retrieve a list of all available sunglasses products.
        /// 
        /// 1.  Create an HTTP GET request and send it to api/sunglasses/all.
        /// 
        /// 2.  After sending the request, you will receive a response containing a list of sunglasses products.
        /// 
        /// Sample Request:
        /// 
        /// GET api/sunglasses/all
        /// 
        /// Form Parameters:
        /// - "Id": 1,
        /// - "Name": "Stylish sunglasses1",
        /// - "Material": "Acrylic1",
        /// - "CostPrice": 30.99,
        /// - "SalePrice": 59.99,
        /// - "DiscountPercent": 20.0,
        /// - "ImageUrl": "https://example.com/images/sunglasses1.jpg",
        /// - "Colors": 
        ///   - "ColorId": 1,
        ///   - "Color": 
        ///     - "ColorName": "Black",
        ///     - "ColorImage": "https://example.com/images/black_color1.jpg"
        ///   - "ColorId": 2,
        ///   - "Color": 
        ///     - "ColorName": "Red",
        ///     - "ColorImage": "https://example.com/images/black_color2.jpg"
        /// - "Id": 2,
        /// - "Name": "Stylish sunglasses2",
        /// - "Material": "Acrylic2",
        /// - "CostPrice": 30.99,
        /// - "SalePrice": 59.99,
        /// - "DiscountPercent": 20.0,
        /// - "ImageUrl": "https://example.com/images/sunglasses1.jpg",
        /// - "Colors": 
        ///   - "ColorId": 3,
        ///   - "Color": 
        ///     - "ColorName": "White",
        ///     - "ColorImage": "https://example.com/images/black_color1.jpg"
        /// 
        /// Response:
        /// HTTP 200 OK
        /// The list of Sunglasses products was successfully retrieved.
        /// </remarks>
        /// <returns>A list of sunglasses products</returns>
        /// <response code="200">The list of sunglasses products was successfully retrieved.</response>
        /// <response code="404">No sunglasses products found.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("all")]
        public ActionResult<List<SunglassesGetAllDto>> GetAll()
        {
            return Ok(_sunglassesService.GetAll());
        }
        /// <summary>
        /// Deletes an sunglasses product by its ID.
        /// </summary>
        /// <remarks>
        /// This API method is used to delete a specific sunglasses product by providing its unique ID.
        /// 
        /// 1. Create an HTTP DELETE request and send it to api/sunglasses/{id} (id is the ID of the sunglasses product to be deleted).
        /// 
        /// 2. After sending the request, the specified sunglasses product will be deleted from the system.
        /// 
        /// Sample Request:
        /// 
        /// DELETE api/sunglasses/id
        /// 
        /// Response:
        /// HTTP 204 No Content
        /// The sunglasses product was successfully deleted.
        /// </remarks>
        /// <param name="id">Identity of the sunglasses product to be deleted</param>
        /// <returns></returns>
        /// <response code="204">The sunglasses product was successfully deleted.</response>
        /// <response code="404">No sunglasses product found for the provided ID.</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _sunglassesService.Delete(id);
            return NoContent();
        }
        /// <summary>
        /// Fetches all items by paging.
        /// </summary>
        /// <param name="page">Page number (default: 1).</param>
        /// <returns>List of items on the specified page number.</returns>
        [HttpGet("")]
        public ActionResult<PaginatedListDto<SunglassesGetPaginatedListItemDto>> GetAll(int page = 1)
        {
            if (page < 1)
            {
                return BadRequest("Page number must be greater than or equal to 1.");
            }
            return Ok(_sunglassesService.GetAllPaginated(page));
        }
    }
}
