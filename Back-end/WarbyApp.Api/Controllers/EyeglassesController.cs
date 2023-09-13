using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarbyApp.Service.Dtos.Common;
using WarbyApp.Service.Dtos.EyeglassesDtos;
using WarbyApp.Service.Interfaces;

namespace WarbyApp.Api.Controllers
{
    //[Authorize(Roles = "SuperAdmin, Admin")]
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
        /// 1. Create an HTTP POST request and send it to the api/eyeglasses endpoint.
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
        /// - Name: "Stylish Eyeglasses"
        /// - Material: "Acrylic"
        /// - CostPrice: 30.99
        /// - SalePrice: 59.99
        /// - DiscountPercent: 20.0
        /// - Image: [Eyeglasses image file]
        /// - ColorId: 1
        /// 
        /// Response:
        /// HTTP 201 Created
        /// Eyeglasses product successfully created.
        /// </remarks>
        /// <param name="createDto"></param>
        /// <returns></returns>
        /// <response code="201">The eyeglasses product has been successfully created.</response>
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
        /// Organizes a specific eyeglasses product.
        /// </summary>
        /// <remarks>
        /// This API method is used to edit a specific eyeglasses product. Follow the steps below to make a successful request:
        /// 
        /// 1. Create an HTTP POST request and send it to api/eyeglasses/{id} (id is the ID of the eyeglasses product you want to edit).
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
        /// - "Name": "Stylish Eyeglasses"
        /// - "Material": "Acrylic"
        /// - "CostPrice": 30.99
        /// - "SalePrice": 59.99
        /// - "DiscountPercent: 20.0
        /// - "Image": [Eyeglasses image file]
        /// - "ColorIdsToAdd": 1
        /// - "ColorIdsToRemove": 2
        /// 
        /// Response:
        /// HTTP 200 OK
        /// The eyeglasses product was successfully edited..
        /// </remarks>
        /// <param name="id">Identity of the eyeglasses product to be issued</param>
        /// <param name="editDto">Eyeglasses regulation data</param>
        /// <returns></returns>
        /// <response code="204">The eyeglasses product was successfully edited.</response>
        /// <response code="400">Invalid request data.</response>
        /// <response code="404">No source found.</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromForm] EyeglassesEditDto editDto)
        {
            _eyeglassesService.Edit(id, editDto);
            return NoContent();
        }
        /// <summary>
        /// Retrieves information about a specific eyeglasses product.
        /// </summary>
        /// <remarks>
        /// This API method is used to retrieve details about a specific eyeglasses product by its ID.
        /// 
        /// 1. Create an HTTP GET request and send it to api/eyeglasses/{id} (id is the ID of the eyeglasses product you want to retrieve).
        /// 
        /// 2.  After sending the request, you will receive a response containing the details of the eyeglasses product.
        /// 
        /// Sample Request:
        /// 
        /// GET api/eyeglasses/{id}
        /// 
        /// Form Parameters:
        /// - "Id": 1,
        /// - "Name": "Stylish Eyeglasses",
        /// - "Material": "Acrylic",
        /// - "CostPrice": 30.99,
        /// - "SalePrice": 59.99,
        /// - "DiscountPercent": 20.0,
        /// - "ImageUrl": "https://example.com/images/eyeglasses1.jpg",
        /// - "Colors":
        ///   - "ColorId": 1,
        ///   - "Color": 
        ///     - "ColorName": "Black",
        ///     - "ColorImage": "https://example.com/images/black_color.jpg"
        /// Response:
        /// HTTP 200 OK
        /// 
        /// The eyeglasses product was successfully edited..
        /// </remarks>
        /// <param name="id">Identity of the eyeglasses product to retrieve</param>
        /// <returns>The details of the eyeglasses product</returns>
        /// <response code="200">The eyeglasses product details were successfully retrieved.</response>
        /// <response code="404">No eyeglasses product found with the specified ID.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public ActionResult<EyeglassesGetDto> Get(int id)
        {
            return Ok(_eyeglassesService.GetById(id));
        }
        /// <summary>
        /// Retrieves a list of all eyeglasses products.
        /// </summary>
        /// <remarks>
        /// This API method is used to retrieve a list of all available eyeglasses products.
        /// 
        /// 1.  Create an HTTP GET request and send it to api/eyeglasses/all.
        /// 
        /// 2.  After sending the request, you will receive a response containing a list of eyeglasses products.
        /// 
        /// Sample Request:
        /// 
        /// GET api/eyeglasses/all
        /// 
        /// Form Parameters:
        /// - "Id": 1,
        /// - "Name": "Stylish Eyeglasses1",
        /// - "Material": "Acrylic1",
        /// - "CostPrice": 30.99,
        /// - "SalePrice": 59.99,
        /// - "DiscountPercent": 20.0,
        /// - "ImageUrl": "https://example.com/images/eyeglasses1.jpg",
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
        /// - "Name": "Stylish Eyeglasses2",
        /// - "Material": "Acrylic2",
        /// - "CostPrice": 30.99,
        /// - "SalePrice": 59.99,
        /// - "DiscountPercent": 20.0,
        /// - "ImageUrl": "https://example.com/images/eyeglasses1.jpg",
        /// - "Colors": 
        ///   - "ColorId": 3,
        ///   - "Color": 
        ///     - "ColorName": "White",
        ///     - "ColorImage": "https://example.com/images/black_color1.jpg"
        /// 
        /// Response:
        /// HTTP 200 OK
        /// The list of Eyeglasses products was successfully retrieved.
        /// </remarks>
        /// <returns>A list of eyeglasses products</returns>
        /// <response code="200">The list of eyeglasses products was successfully retrieved.</response>
        /// <response code="404">No eyeglasses products found.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("all")]
        public ActionResult<List<EyeglassesGetAllDto>> GetAll()
        {
            return Ok(_eyeglassesService.GetAll());
        }
        /// <summary>
        /// Deletes an eyeglasses product by its ID.
        /// </summary>
        /// <remarks>
        /// This API method is used to delete a specific eyeglasses product by providing its unique ID.
        /// 
        /// 1. Create an HTTP DELETE request and send it to api/eyeglasses/{id} (id is the ID of the eyeglasses product to be deleted).
        /// 
        /// 2. After sending the request, the specified eyeglasses product will be deleted from the system.
        /// 
        /// Sample Request:
        /// 
        /// DELETE api/eyeglasses/id
        /// 
        /// Response:
        /// HTTP 204 No Content
        /// The eyeglasses product was successfully deleted.
        /// </remarks>
        /// <param name="id">Identity of the eyeglasses product to be deleted</param>
        /// <returns></returns>
        /// <response code="204">The eyeglasses product was successfully deleted.</response>
        /// <response code="404">No eyeglasses product found for the provided ID.</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _eyeglassesService.Delete(id);
            return NoContent();
        }
        /// <summary>
        /// Fetches all items by paging.
        /// </summary>
        /// <param name="page">Page number (default: 1).</param>
        /// <returns>List of items on the specified page number.</returns>
        [HttpGet("")]
        public ActionResult<PaginatedListDto<EyeglassesGetPaginatedListItemDto>> GetAll(int page = 1)
        {
            if (page < 1)
            {
                return BadRequest("Page number must be greater than or equal to 1.");
            }
            return Ok(_eyeglassesService.GetAllPaginated(page));
        }
    }
}
