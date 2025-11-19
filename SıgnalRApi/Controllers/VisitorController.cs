using Microsoft.AspNetCore.Mvc;
using SıgnalRApi.Dal;
using SıgnalRApi.Model;

namespace SıgnalRApi.Controller;
[Route("api/[controller]")]
[ApiController]
public class VisitorController : ControllerBase
{
    private readonly VisitorService _visitorService;
    public VisitorController(VisitorService visitorService)
    {
        _visitorService = visitorService;
    }
    [HttpGet]
    public IActionResult Index()
    {
        Random rnd = new Random();
        Enumerable.Range(1,10).ToList().ForEach(x =>
        {
            foreach (ECity  item in Enum.GetValues(typeof(ECity)))
            {
                var newVisitor = new Visitor
                {
                    ECity = item,
                    CityVisitCount = rnd.Next(100, 200),
                    VisitDate = DateTime.Now.AddDays(x)
                };
                _visitorService.SaveVisitor(newVisitor).Wait();
                System.Threading.Thread.Sleep(1000);
            }
        });
        return Ok("Ziyaretçi başarılı bir şekilde eklendi");
    }
}