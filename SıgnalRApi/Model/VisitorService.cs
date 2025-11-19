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
    
    public IQueryable<Visitor> GetList=> _context.Visitors.AsQueryable();

    public async Task SaveVisitor(Visitor visitor)
    {
        await _context.Visitors.AddAsync(visitor);
        await _context.SaveChangesAsync();
        await _visitorHub.Clients.All.SendAsync("VisitorList", "GetVisitorChartList()");
    }

    public List<VisitorChart> GetVisitorChartList()
    {
        List<VisitorChart> visitorCharts = new List<VisitorChart>();
        using (var comand = _context.Database.GetDbConnection().CreateCommand())
        {
            comand.CommandText = "query sorgu";
            comand.CommandType = System.Data.CommandType.Text;
            _context.Database.OpenConnection();
            using (var reader = comand.ExecuteReader())
            {
                while (reader.Read())
                {
                    VisitorChart visitorChart = new VisitorChart();
                    visitorChart.VisitDate = reader.GetString(0);
                    Enumerable.Range(1,4).ToList().ForEach(x =>
                    {
                        visitorChart.Counts.Add(reader.GetInt32(x));
                    });
                    visitorCharts.Add(visitorChart);
                }
            }
            _context.Database.CloseConnection();
            return visitorCharts;
        }
    }
}