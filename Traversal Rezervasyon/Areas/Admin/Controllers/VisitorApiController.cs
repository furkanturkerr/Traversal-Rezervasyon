using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Traversal_Rezervasyon.Areas.Admin.Models;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers;
[Area("Admin")]
public class VisitorApiController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public VisitorApiController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responsemessage = await client.GetAsync("https://localhost:7001/api/Visitor");
        if (responsemessage.IsSuccessStatusCode)
        {
            var jsonData  = await responsemessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<VisitorViewModel>>(jsonData);
            return View(values);
        }
         return View();
    }

    [HttpGet]
    public IActionResult AddVisitor()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddVisitor(VisitorViewModel p)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(p);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responsemessage = await client.PostAsync("https://localhost:7001/api/Visitor", content);
        if (responsemessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> DeleteVisitor(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var ResponseMessage = await client.DeleteAsync("https://localhost:7001/api/Visitor/"+id);
        if (ResponseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateVisitor(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var ResponseMessage = await client.GetAsync("https://localhost:7001/api/Visitor/"+id);
        if (ResponseMessage.IsSuccessStatusCode)
        {
            var jsonData  = await ResponseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<VisitorViewModel>(jsonData);
            return View(values);
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateVisitor(VisitorViewModel p)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(p);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responsemessage = await client.PutAsync("https://localhost:7001/api/Visitor", content);
        if (responsemessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}