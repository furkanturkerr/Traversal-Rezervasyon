using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Traversal_Rezervasyon.Models;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers;
[Area("Admin")]
public class CityController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult CitiList()
    {
        var jsonCİty = JsonConvert.SerializeObject(cities);
        return Json(jsonCİty);
    }

    public static List<CityClass> cities = new List<CityClass>
    {
        new CityClass
        {
            CityId = 1,
            CityName = "Üsküp",
            CityContry = "Makedonya"
        },
        new CityClass
        {
            CityId = 2,
            CityName = "Roma",
            CityContry = "İtalya"
        },
        new CityClass
        {
            CityId = 3,
            CityName = "Londra",
            CityContry = "İngiltere"
        }
    };
}