using CookingService.Application;
using CookingService.Domain;
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

    [HttpPost]
    [Route("Cook")]
    public void PrepareCooking(Ingredients ingredients)
    {
        _publishMessageService.PublishMessage(ingredients);
    }
}
