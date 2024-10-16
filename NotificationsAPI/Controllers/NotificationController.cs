using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

[Route("api/[controller]")]
[ApiController]
public class NotificationController : ControllerBase
{
    private readonly IHubContext<NotificationHub> _hubContext;

    public NotificationController(IHubContext<NotificationHub> hubContext)
    {
        _hubContext = hubContext;
    }

    [HttpPost]
    public async Task<IActionResult> SendNotification([FromBody] string message)
    {
        await _hubContext.Clients.All.SendAsync("ReceiveNotification", message);
        return Ok(new { Message = "Notification sent successfully!" });
    }
}
