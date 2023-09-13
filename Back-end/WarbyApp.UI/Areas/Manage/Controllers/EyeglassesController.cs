using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using WarbyApp.Core.Entities;
using WarbyApp.Data;
using WarbyApp.UI.ViewModels;
using MediaTypeHeaderValue = System.Net.Http.Headers.MediaTypeHeaderValue;

namespace WarbyApp.UI.Areas.Manage.Controllers
{
    [Area("manage")]
    public class EyeglassesController : Controller
    {
        private HttpClient _client;

        public EyeglassesController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7125/api/");
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            using (var response = await _client.GetAsync($"eyeglasses/all?page={page}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<Eyeglasses_VMItem> eyeglasses = JsonConvert.DeserializeObject<List<Eyeglasses_VMItem>>(content);
                    int pageSize = 1;
                    var paginatedList = PaginatedList<Eyeglasses_VMItem>.Create(eyeglasses.AsQueryable(), page, pageSize);
                    return View(paginatedList);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    return RedirectToAction("login", "account");
            }
            return View("error");
        }
        public async Task<ActionResult> Create()
        {
            ViewBag.Colors = await _getColors();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EyeglassesCreate_VM create_VM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Colors = await _getColors();
                return View();
            }
            MultipartFormDataContent requestContent = new MultipartFormDataContent();
            requestContent.Add(new StringContent(create_VM.Name), "Name");
            requestContent.Add(new StringContent(create_VM.Material), "Material");
            requestContent.Add(new StringContent(create_VM.ColorId.ToString()), "ColorId");
            requestContent.Add(new StringContent(create_VM.SalePrice.ToString()), "SalePrice");
            requestContent.Add(new StringContent(create_VM.CostPrice.ToString()), "CostPrice");
            requestContent.Add(new StringContent(create_VM.DiscountPercent.ToString()), "DiscountPercent");
            var fileContent = new StreamContent(create_VM.ImageFile.OpenReadStream());
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(create_VM.ImageFile.ContentType);
            requestContent.Add(fileContent, "ImageFile", create_VM.ImageFile.FileName);
            using (var response = await _client.PostAsync("eyeglasses", requestContent))
            {
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("index");
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ViewBag.Colors = await _getColors();
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var errorVM = JsonConvert.DeserializeObject<Error_VM>(responseContent);

                    foreach (var item in errorVM.Errors)
                        ModelState.AddModelError(item.Key, item.ErrorMessage);

                    return View();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    return RedirectToAction("login", "account");
            }
            return View("error");
        }
        public async Task<IActionResult> Edit(int id)
        {
            using (var response = await _client.GetAsync($"eyeglasses/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var vm = JsonConvert.DeserializeObject<EyeglassesEdit_VM>(content);
                    var colorNames = vm.Colors.Select(x => x.Color).ToList();
                    ViewBag.Colors = colorNames;
                    return View(vm);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    return RedirectToAction("login", "account");
            }
            return View("Error");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EyeglassesEdit_VM edit_VM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Colors = _getColors();
                return View();
            }
            foreach (var color in edit_VM.Colors)
            {
                if (color.ColorId == edit_VM.Colors.FirstOrDefault().ColorId)
                {
                    color.Color.ColorName = edit_VM.Colors.FirstOrDefault().Color.ColorName;
                }
            }
            MultipartFormDataContent requestContent = new MultipartFormDataContent();
            requestContent.Add(new StringContent(edit_VM.Name), "Name");
            requestContent.Add(new StringContent(edit_VM.Material), "Material");
            requestContent.Add(new StringContent(edit_VM.Colors.ToString()), "Colors");
            requestContent.Add(new StringContent(edit_VM.SalePrice.ToString()), "SalePrice");
            requestContent.Add(new StringContent(edit_VM.CostPrice.ToString()), "CostPrice");
            requestContent.Add(new StringContent(edit_VM.DiscountPercent.ToString()), "DiscountPercent");
            var fileContent = new StreamContent(edit_VM.ImageFile.OpenReadStream());
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(edit_VM.ImageFile.ContentType);
            requestContent.Add(fileContent, "ImageFile", edit_VM.ImageFile.FileName);
            using (var response = await _client.PutAsync($"eyeglasses/{id}", requestContent))
            {
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("index");
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var errorVM = JsonConvert.DeserializeObject<Error_VM>(responseContent);

                    foreach (var item in errorVM.Errors)
                        ModelState.AddModelError(item.Key, item.ErrorMessage);

                    return View();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    return RedirectToAction("login", "account");
            }
            return View("Error");
        }
        public async Task<IActionResult> Delete(int id)
        {
            using (var response = await _client.DeleteAsync($"eyeglasses/{id}"))
            {
                if (response.IsSuccessStatusCode)
                    return Ok();
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    return Unauthorized();
            }
            return NotFound();
        }
        private async Task<List<Color_VMItem>> _getColors()
        {
            List<Color_VMItem> data = new List<Color_VMItem>();
            using (var response = await _client.GetAsync("colors/all"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<List<Color_VMItem>>(content);
                }
            }

            return data;
        }
    }
}
