using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Traversal_Rezervasyon.Areas.Admin.Models;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers;
[Area("Admin")]
public class AnnouncementController : Controller
{
    private readonly IAnnouncementService _announcementService;
    public AnnouncementController(IAnnouncementService announcementService)
    {
        _announcementService = announcementService;
    }
    
    public IActionResult Index()
    {
        List<Announcement> announcements = _announcementService.GetAll();
        List<AnnouncementAddListViewModel> model = new List<AnnouncementAddListViewModel>();
        foreach (var item in announcements)
        {
            AnnouncementAddListViewModel announcementAddListViewModel = new AnnouncementAddListViewModel();
            announcementAddListViewModel.Id = item.AnnouncementId;
            announcementAddListViewModel.Title = item.Title;
            announcementAddListViewModel.Cotent = item.Content;
            model.Add(announcementAddListViewModel);
        }
        return View(model);
    }
    
    [HttpGet]
    public IActionResult AddAnnouncement()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddAnnouncement(int id)
    {
        return View();
    }
}