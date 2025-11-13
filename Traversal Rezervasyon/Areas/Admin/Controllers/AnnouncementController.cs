using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Traversal_Rezervasyon.Areas.Admin.Models;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers;
[Area("Admin")]
public class AnnouncementController : Controller
{
    private readonly IAnnouncementService _announcementService;
    private readonly IMapper _mapper;
    public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
    {
        _mapper = mapper;
        _announcementService = announcementService;
    }
    
    public IActionResult Index()
    {
        var values = _mapper.Map<List<AnnouncementAddListDto>>(_announcementService.GetAll());
        return View(values);
    }
    
    [HttpGet]
    public IActionResult AddAnnouncement()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddAnnouncement(AnnouncementAddDto model)
    {
        if (ModelState.IsValid)
        {
            _announcementService.Add(new Announcement()
            {
                Content = model.Content,
                Title = model.Title,
                Date = Convert.ToDateTime(DateTime.Now.ToString("dd.MM.yyyy"))
            });
            return RedirectToAction("Index");
        }
        return View(model);
    }

    public IActionResult DeleteAnnouncement(int id)
    {
        var value = _announcementService.GetById(id);
        _announcementService.Delete(value);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult UpdateAnnouncement(int id)
    {
        var value = _mapper.Map<AnnouncementUpdateDto>(_announcementService.GetById(id));
        return View(value);
    }
    
    [HttpPost]
    public IActionResult UpdateAnnouncement(AnnouncementUpdateDto model)
    {
        if (ModelState.IsValid)
        {
            _announcementService.Edit(new Announcement()
            {
                AnnouncementId = model.AnnouncementId,
                Content = model.Content,
                Title = model.Title,
                Date = Convert.ToDateTime(DateTime.Now.ToString("dd.MM.yyyy"))
            });
        }
        
        return View(model);
    }
}