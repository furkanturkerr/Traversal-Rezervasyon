using AutoMapper;
using DocumentFormat.OpenXml.Bibliography;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.CityDTOs;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Traversal_Rezervasyon.Controllers;

namespace Traversal_Rezervasyon.Mapping.AutoMapper;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<AppUserLoginDTOs, AppUser>().ReverseMap();
        CreateMap<AnnouncementAddDto, Announcement>().ReverseMap();
        CreateMap<AnnouncementUpdateDto, Announcement>().ReverseMap();
        CreateMap<AnnouncementAddListDto, Announcement>().ReverseMap();
        CreateMap<AppUserRegisterDTOs, AppUser>().ReverseMap();
        CreateMap<SendMessageDTO, ContactUs>().ReverseMap();
    }
    
}