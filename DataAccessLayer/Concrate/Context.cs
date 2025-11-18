using System.Runtime.InteropServices;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrate;

public class Context : IdentityDbContext<AppUser, AppRole, int>
{
    // DI (AddDbContext) için
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    // Eski kodlarda new Context() varsa kırmızı olmasın diye
    public Context()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Eğer Program.cs tarafı zaten provider’ı ayarladıysa, dokunma
        if (optionsBuilder.IsConfigured)
            return;

        // Buraya sadece Fallback mantığı koyuyoruz
        var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        if (isWindows)
        {
            // WINDOWS: SQL Server
            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-2R...\\MSSQLSERVER01;Database=TravelRezervasyon;Trusted_Connection=True;TrustServerCertificate=True");
        }
        else
        {
            // MAC / LINUX: PostgreSQL
            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Database=TraversalDb;Username=postgres;Password=Gfurkan12");
        }
    }

    public DbSet<About> Abouts { get; set; }
    public DbSet<About2> About2s { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Destination> Destinations { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Feature2> Feature2s { get; set; }
    public DbSet<Guide> Guides { get; set; }
    public DbSet<Newsletter> Newsletters { get; set; }
    public DbSet<SubAbout> SubAbouts { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<Commend> Commends { get; set; }
    public DbSet<Rezervation> Rezervations { get; set; }
    public DbSet<ContactUs> ContactUses { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
}
