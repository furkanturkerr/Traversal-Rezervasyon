using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Traversal_Rezervasyon.Areas.Admin.Models;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers;
[Area("Admin")]
[AllowAnonymous]
public class BookingOtelSearchController : Controller
{
    public async Task<IActionResult> Index()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?checkout_date=2026-02-01&filter_by_currency=TRY&order_by=popularity&dest_id=-553173&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&locale=tr&dest_type=city&units=metric&include_adjacency=true&children_number=2&room_number=1&adults_number=2&page_number=0&checkin_date=2026-01-18"),
            Headers =
            {
                { "x-rapidapi-key", "228321f524msh2f2cbcfabd83e56p1d01fbjsn7b1af1c27a41" },
                { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<BookingOtelSearchViewModel>(body);
            return View(values.results);
        }
    }

    [HttpGet]
    public IActionResult GetCityId()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult>  GetCityId(string p)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={p}&locale=tr"),
            Headers =
            {
                { "x-rapidapi-key", "228321f524msh2f2cbcfabd83e56p1d01fbjsn7b1af1c27a41" },
                { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            Console.WriteLine(body);
            return View();
        }
    }
}