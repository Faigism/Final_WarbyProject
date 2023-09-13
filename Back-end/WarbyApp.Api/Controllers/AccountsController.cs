using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WarbyApp.Api.Services;
using WarbyApp.Core.Entities;
using WarbyApp.Service.Dtos.AccountDtos;

namespace WarbyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly JwtService _jwtService;

        public AccountsController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, JwtService jwtService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _jwtService = jwtService;
        }
        /*[HttpGet("createrole")]
        public async Task<IActionResult> CreateRole()
        {
            await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
            await _roleManager.CreateAsync(new IdentityRole("Member"));
            return Ok();
        }*/
        /*[HttpGet("createadmin")]
        public async Task<IActionResult> CreateAdmin()
        {
            AppUser admin = new AppUser
            {
                Email = "aydin.nuruyev7@gmail.com",
                FullName = "Aydin Nuruyev",
                UserName = "Aydin"
            };
            var result = await _userManager.CreateAsync(admin, "Admin123");
            if (result.Succeeded)
            {
                var addToRoleResult = await _userManager.AddToRoleAsync(admin, "Admin");

                if (addToRoleResult.Succeeded)
                {
                    return Ok("Admin user created and assigned the 'Admin' role successfully.");
                }
                else
                {
                    return BadRequest("Failed to assign 'Admin' role to the user.");
                }
            }
            else
            {
                return BadRequest("Failed to create the admin user.");
            }
        }*/
        /*[HttpGet("createSuperAdmin")]
        public async Task<IActionResult> CreateAdmin()
        {
            AppUser admin = new AppUser
            {
                Email = "faiqismayilov46@gmail.com",
                FullName = "Faiq Ismayilov",
                UserName = "Faiqlee"
            };
            var result = await _userManager.CreateAsync(admin, "Admin123");
            if (result.Succeeded)
            {
                var addToRoleResult = await _userManager.AddToRoleAsync(admin, "SuperAdmin");

                if (addToRoleResult.Succeeded)
                {
                    return Ok("Admin user created and assigned the 'Admin' role successfully.");
                }
                else
                {
                    return BadRequest("Failed to assign 'Admin' role to the user.");
                }
            }
            else
            {
                return BadRequest("Failed to create the admin user.");
            }
        }*/
        [HttpPost("login")]
        public async Task<IActionResult> Login(AdminLoginDto loginDto)
        {
            AppUser admin = await _userManager.FindByNameAsync(loginDto.UserName);

            if (admin == null)
                return BadRequest();

            if (!await _userManager.CheckPasswordAsync(admin, loginDto.Password))
                return BadRequest();


            return Ok(new { token = await _jwtService.GenerateToken(admin) });
        }
        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> Profile()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            return Ok(new
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                FullName = user.FullName
            });
        }
    }
}
