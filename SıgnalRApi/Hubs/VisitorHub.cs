using Microsoft.AspNetCore.SignalR;
using SıgnalRApi.Model;

namespace SıgnalRApi.Hubs;

public class VisitorHub : Hub
{
    private readonly VisitorService _visitorService;

    public VisitorHub(VisitorService visitorService)
    {
        _visitorService = visitorService;
    }

    public async Task GetVisitorList()
    {
        await Clients.All.SendAsync("CallVisitorList", "_visitorService.GetVisitorChartList()");
    }
}