using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Traversal_Rezervasyon.Areas.Admin.Models;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers;
[Area("Admin")]
[AllowAnonymous]
public class ApiExchenceController : Controller
{
    public async Task<IActionResult> Index()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/meta/getExchangeRates?base_currency=TRY"),
            Headers =
            {
                { "x-rapidapi-key", "228321f524msh2f2cbcfabd83e56p1d01fbjsn7b1af1c27a41" },
                { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
            },
        };

        using var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadAsStringAsync();

        var apiResult = JsonConvert.DeserializeObject<BookingExchenceViewModel2>(body);

        var model = apiResult?.data?.exchange_rates ?? new List<Exchange_Rate>();

        return View(model);
    }
}