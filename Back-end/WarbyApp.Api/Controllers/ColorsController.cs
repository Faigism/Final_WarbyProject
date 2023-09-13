using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WarbyApp.Service.Dtos.ColorDtos;
using WarbyApp.Service.Dtos.Common;
using WarbyApp.Service.Dtos.SunglassesDtos;
using WarbyApp.Service.Implementations;
using WarbyApp.Service.Interfaces;

namespace WarbyApp.Api.Controllers
{
    //[Authorize(Roles = "SuperAdmin, Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }
        /// <summary>
        /// Creates a new color.
        /// </summary>
        /// <remarks>
        /// This API method is used to create a new color with the specified name and image.
        /// 
        /// 1. Create an HTTP POST request and send it to api/colors.
        /// 
        /// 2. Ensure that the request is configured as "multipart/form-data."
        /// 
        /// 3. In the request body, provide the following parameters:
        ///    - ColorName (string): Name of the color.
        ///    - ColorImage (file): Color image (File upload)
        ///    
        /// 4. After sending the request, you will receive a response indicating that the color was successfully created.
        /// 
        /// Sample Request:
        /// 
        /// POST api/colors
        /// 
        /// Form Parameters:
        /// - "ColorName": "Red",
        /// - "ColorImage": [Color image file]
        /// 
        /// Response:
        /// HTTP 201 Created
        /// The color was successfully created.
        /// </remarks>
        /// <param name="createDto"></param>
        /// <returns></returns>
        /// <response code="201">The Color has been successfully created.</response>
        /// <response code="400">Invalid request data.</response>
        /// <response code="404">No source found.</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpPost("")]
        public IActionResult Create([FromForm] ColorCreateDto createDto)
        {
            return StatusCode(201, _colorService.Create(createDto));
        }
        /// <summary>
        /// Organizes a specific color.
        /// </summary>
        /// <remarks>
        /// This API method is used to edit a specific color. Follow the steps below to make a successful request:
        /// 
        /// 1. Create an HTTP POST request and send it to api/colors/{id} (id is the ID of the color you want to edit).
        /// 
        /// 2. Ensure that the request is configured as "multipart/form-data."
        /// 
        /// 3. In the request body, provide the following parameters:
        ///    - ColorName (string): Name of the color.
        ///    - ColorImage (file): Color image (File upload)
        ///    
        /// 4. After sending the request, you will receive a response containing the created color.
        /// 
        /// Sample Request:
        /// 
        /// POST api/colors/id
        /// 
        /// Form Parameters:
        /// - "ColorName": "Red",
        /// - "ColorImage": [Color image file]
        /// 
        /// Response:
        /// HTTP 201 Created
        /// The color was successfully edited..
        /// </remarks>
        /// <param name="id">Identity of the color to be issued</param>
        /// <param name="editDto">Color regulation data</param>
        /// <returns></returns>
        /// <response code="204">The color was successfully edited.</response>
        /// <response code="400">Invalid request data.</response>
        /// <response code="404">No source found.</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromForm] ColorEditDto editDto)
        {
            _colorService.Edit(id, editDto);
            return NoContent();
        }
        /// <summary>
        /// Retrieves information about a specific color.
        /// </summary>
        /// <remarks>
        /// This API method is used to retrieve details about a specific color by its ID.
        /// 
        /// 1. Create an HTTP GET request and send it to api/colors/{id} (id is the ID of the color you want to retrieve).
        /// 
        /// 2.  After sending the request, you will receive a response containing the details of the color.
        /// 
        /// Sample Request:
        /// 
        /// GET api/sunglasses/{id}
        /// 
        /// Form Parameters:
        /// - "ColorName": Red,
        /// - "ColorImage": "https://example.com/images/color1.jpg",
        /// 
        /// Response:
        /// HTTP 200 OK
        /// 
        /// The color was successfully edited..
        /// </remarks>
        /// <param name="id">Identity of the color to retrieve</param>
        /// <returns>The details of the color</returns>
        /// <response code="200">The color details were successfully retrieved.</response>
        /// <response code="404">No color found with the specified ID.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_colorService.GetById(id));
        }
        /// <summary>
        /// Retrieves a list of all colors.
        /// </summary>
        /// <remarks>
        /// This API method is used to retrieve a list of all available colors.
        /// 
        /// 1.  Create an HTTP GET request and send it to api/colors/all.
        /// 
        /// 2.  After sending the request, you will receive a response containing a list of colors.
        /// 
        /// Sample Request:
        /// 
        /// GET api/colors/all
        /// 
        /// Form Parameters:
        /// - "Id": 1,
        /// - "ColorName": Red,
        /// - "ColorImage": "https://example.com/images/color1.jpg"
        /// 
        /// - "Id": 2,
        /// - "ColorName": Black,
        /// - "ColorImage": "https://example.com/images/color2.jpg"
        /// 
        /// - "Id": 3,
        /// - "ColorName": White,
        /// - "ColorImage": "https://example.com/images/color3.jpg"
        /// 
        /// Response:
        /// HTTP 200 OK
        /// The list of Colors was successfully retrieved.
        /// </remarks>
        /// <returns>A list of colors</returns>
        /// <response code="200">The list of colors was successfully retrieved.</response>
        /// <response code="404">No colors found.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("all")]
        public ActionResult<List<ColorGetAllDto>> GetAll()
        {
            return Ok(_colorService.GetAll());
        }
        /// <summary>
        /// Deletes an color by its ID.
        /// </summary>
        /// <remarks>
        /// This API method is used to delete a specific color by providing its unique ID.
        /// 
        /// 1. Create an HTTP DELETE request and send it to api/colors/{id} (id is the ID of the color to be deleted).
        /// 
        /// 2. After sending the request, the specified color will be deleted from the system.
        /// 
        /// Sample Request:
        /// 
        /// DELETE api/colors/id
        /// 
        /// Response:
        /// HTTP 204 No Content
        /// The color was successfully deleted.
        /// </remarks>
        /// <param name="id">Identity of the color to be deleted</param>
        /// <returns></returns>
        /// <response code="204">The color was successfully deleted.</response>
        /// <response code="404">No color found for the provided ID.</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _colorService.Delete(id);
            return NoContent();
        }
        /// <summary>
        /// Fetches all items by paging.
        /// </summary>
        /// <param name="page">Page number (default: 1).</param>
        /// <returns>List of items on the specified page number.</returns>
        [HttpGet("")]
        public ActionResult<PaginatedListDto<ColorGetPaginatedListItemDto>> GetAll(int page = 1)
        {
            if (page < 1)
            {
                return BadRequest("Page number must be greater than or equal to 1.");
            }
            return Ok(_colorService.GetAllPaginated(page));
        }
    }
}
