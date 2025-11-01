using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Components.Default;

public class _Testimonial : ViewComponent
{
    private TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());
    public virtual IViewComponentResult Invoke()
    {
        var values = testimonialManager.GetAll();
        return View(values);
    }
}