using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Traversal_Rezervasyon.Areas.Admin.Models;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers;
[Area("Admin")]
[AllowAnonymous]
public class ApiMovieController : Controller
{
    // GET
    public async  Task<IActionResult> Index()
    {
        List<ApiMovieViewModel> apiMovie = new List<ApiMovieViewModel>();
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
            Headers =
            {
                { "x-rapidapi-key", "228321f524msh2f2cbcfabd83e56p1d01fbjsn7b1af1c27a41" },
                { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            apiMovie = JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);
            return View(apiMovie);
        }
    }
}