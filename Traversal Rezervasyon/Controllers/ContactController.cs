using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Controllers;
[AllowAnonymous]
public class ContactController : Controller
{
    private readonly IContactUsService _contactUsService;
    private readonly IMapper _mapper;
    public ContactController(IContactUsService contactUsService,  IMapper mapper)
    {
        _mapper = mapper;
        _contactUsService = contactUsService;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(SendMessageDTO model)
    {
        if (ModelState.IsValid)
        {
            _contactUsService.Add(new ContactUs()
            {
                Name = model.Name,
                Mail = model.Mail,
                MessageBody =  model.MessageBody,
                Status = true,
                Subject = model.Subject,
                MessageDate = DateTime.UtcNow
            });
            return RedirectToAction("Index", "ContactUs");
        }
        return View(model);
    }

}