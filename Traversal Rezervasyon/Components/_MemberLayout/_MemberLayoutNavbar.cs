using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Traversal_Rezervasyon.Models;

namespace TraversalCoreProject.ViewComponents.MemberLayout
{
    public class _MemberLayoutNavbar:ViewComponent
    {
        private readonly IAppUserService _appUserService;
        public _MemberLayoutNavbar(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        public IViewComponentResult Invoke()
        {
            var name = User.Identity.Name;
            ViewBag.Name = name;
            return View();
        }
    }
}