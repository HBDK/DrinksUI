using System.Collections.Generic;
using System.Linq;
using DrinksUI.Data;
using DrinksUI.Data.Services;
using DrinksUI.Dtos.implementations;
using DrinksUI.Dtos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DrinkUI.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrinkController : ControllerBase
    {
        private readonly DrinkService _drinkService;
        private readonly ILogger<DrinkController> _logger;

        public DrinkController(ILogger<DrinkController> logger, DrinkService drinkService)
        {
            _logger = logger;
            _drinkService = drinkService;
        }

        [HttpGet]
        public (IDrink, bool) Get(int id)
        {
            var task =_drinkService.GetDrink(id);
            return task.Result;
        }
    }
}