using CookingService.Application;
using Microsoft.AspNetCore.Mvc;

namespace CookingService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CookingController : ControllerBase
{
    private readonly ISetup _setup;
    private readonly IPublishMessageService _publishMessageService;

    public CookingController(
        ISetup setup, 
        IPublishMessageService publishMessageService)
    {
        _setup = setup;
        _publishMessageService = publishMessageService;
    }

    [HttpGet]
    [Route("Cook")]
    public void PrepareCooking()
    {
        _publishMessageService.PublishMessage();
    }
}
