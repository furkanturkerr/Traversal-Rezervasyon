using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SıgnalRApi.Dal;
using SıgnalRApi.Hubs;

namespace SıgnalRApi.Model;

public class VisitorService
{
    private readonly Context _context;
    
    private readonly IHubContext<VisitorHub> _visitorHub;
    
    public VisitorService(IHubContext<VisitorHub> visitorHub, Context context)
        {
        _context = context;
        _visitorHub = visitorHub;
        }

    public IQueryable<Visitor> GetList()
    {
        return _context.Visitors.AsQueryable();
    }

    public async Task SaveVisitor(Visitor visitor)
    {
        await _context.Visitors.AddAsync(visitor);
        await _context.SaveChangesAsync();
        await _visitorHub.Clients.All.SendAsync("VisitorList", GetVisitorChartList());
    }

// ... existing code ...
    public List<VisitorChart> GetVisitorChartList()
    {
        List<VisitorChart> visitorCharts = new List<VisitorChart>();
        using (var comand = _context.Database.GetDbConnection().CreateCommand())
        {
            // PostgreSQL Uyumlu Sorgu (Case When yapısı)
            // Not: Tablo ve kolon isimleri PostgreSQL'de genellikle tırnak işareti " " ile belirtilir.
            // Eğer veritabanınızda tablo adı "Visitors" değil "visitors" ise tırnakları kaldırabilirsiniz.
            comand.CommandText = @"
                SELECT 
                    TO_CHAR(""VisitDate"", 'YYYY-MM-DD') as tarih, 
                    SUM(CASE WHEN ""City"" = 1 THEN ""CityVisitCount"" ELSE 0 END) as City1,
                    SUM(CASE WHEN ""City"" = 2 THEN ""CityVisitCount"" ELSE 0 END) as City2,
                    SUM(CASE WHEN ""City"" = 3 THEN ""CityVisitCount"" ELSE 0 END) as City3,
                    SUM(CASE WHEN ""City"" = 4 THEN ""CityVisitCount"" ELSE 0 END) as City4,
                    SUM(CASE WHEN ""City"" = 5 THEN ""CityVisitCount"" ELSE 0 END) as City5
                FROM ""Visitors""
                GROUP BY ""VisitDate""
                ORDER BY ""VisitDate"" ASC";
            
            comand.CommandType = System.Data.CommandType.Text;
            _context.Database.OpenConnection();
            
            using (var reader = comand.ExecuteReader())
            {
                while (reader.Read())
                {
                    VisitorChart visitorChart = new VisitorChart();
                    // 0. index tarih
                    visitorChart.VisitDate = reader.GetString(0); 
                    
                    // 1'den 5'e kadar olan sütunları (Şehir sayılarını) oku
                    // Enumerable.Range(1, 5) -> 1, 2, 3, 4, 5 indexlerini okur.
                    Enumerable.Range(1, 5).ToList().ForEach(x =>
                    {
                        // PostgreSQL sayısal verileri bazen Long(Int64) dönebilir, güvenli dönüşüm yapıyoruz.
                        visitorChart.Counts.Add(Convert.ToInt32(reader[x]));
                    });
                    
                    visitorCharts.Add(visitorChart);
                }
            }
            _context.Database.CloseConnection();
            return visitorCharts;
        }
    }
}