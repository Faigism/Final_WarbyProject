using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using WarbyApp.UI.ViewModels;

namespace WarbyApp.UI.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ColorController : Controller
    {
        private HttpClient _client;
        public ColorController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7125/api/");
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            using (var response = await _client.GetAsync($"colors/all?page={page}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    List<Color_VMItem> colors = JsonConvert.DeserializeObject<List<Color_VMItem>>(content);
                    int pageSize = 1;
                    var paginatedList = PaginatedList<Color_VMItem>.Create(colors.AsQueryable(), page, pageSize);
                    return View(paginatedList);
                }
            }
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ColorCreate_VM create_VM)
        {
            if (!ModelState.IsValid) return View();
            MultipartFormDataContent requestContent = new MultipartFormDataContent();
            requestContent.Add(new StringContent(create_VM.ColorName), "ColorName");
            var fileContent = new StreamContent(create_VM.ColorImage.OpenReadStream());
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(create_VM.ColorImage.ContentType);
            requestContent.Add(fileContent, "ColorImage", create_VM.ColorImage.FileName);
            using (var response = await _client.PostAsync("colors", requestContent))
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
            }
            return View("Error");
        }
        public async Task<IActionResult> Edit(int id)
        {
            using (var response = await _client.GetAsync($"colors/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var vm = JsonConvert.DeserializeObject<ColorEdit_VM>(content);
                    return View(vm);
                }
            }
            return View("Error");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ColorEdit_VM edit_VM)
        {
            if (!ModelState.IsValid) return View();
            MultipartFormDataContent requestContent = new MultipartFormDataContent();
            requestContent.Add(new StringContent(edit_VM.ColorName), "ColorName");
            var fileContent = new StreamContent(edit_VM.ColorImage.OpenReadStream());
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(edit_VM.ColorImage.ContentType);
            requestContent.Add(fileContent, "ColorImage", edit_VM.ColorImage.FileName);
            using (var response = await _client.PutAsync($"colors/{id}", requestContent))
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
            }
            return View("Error");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            using (var response = await _client.DeleteAsync($"colors/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var errorVM = JsonConvert.DeserializeObject<Error_VM>(responseContent);

                    foreach (var item in errorVM.Errors)
                    {
                        ModelState.AddModelError(item.Key, item.ErrorMessage);
                    }
                }
            }

            return View("Error");
        }
    }
}
