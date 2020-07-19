using System.Collections.Generic;
using DrinksUI.Data.Services;
using DrinksUI.Dtos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DrinkUI.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShortDrinkListController : ControllerBase
    {
        private readonly DrinkService _drinkService;
        private readonly ILogger<ShortDrinkListController> _logger;

        public ShortDrinkListController(ILogger<ShortDrinkListController> logger, DrinkService drinkService)
        {
            _logger = logger;
            _drinkService = drinkService;
        }

        [HttpGet]
        public IEnumerable<IDrinkShortDescription> Get()
        {
            var task =_drinkService.GetShortDescriptions();
            return task.Result;
        }
    }
}