using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class TestimonialManager : ITestimonialService
{
    private readonly ITestimonialDal _testimonialDal;

    public TestimonialManager(ITestimonialDal testimonialDal)
    {
        _testimonialDal =  testimonialDal;
    }
    public void Add(Testimonial t)
    {
        _testimonialDal.Insert(t);
    }

    public void Delete(Testimonial t)
    {
        _testimonialDal.Delete(t);
    }

    public void Edit(Testimonial t)
    {
        _testimonialDal.Update(t);
    }

    public List<Testimonial> GetAll()
    {
        return _testimonialDal.GetList();
    }

    public Testimonial GetById(int id)
    {
        throw new NotImplementedException();
    }
}