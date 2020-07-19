using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinksUI.Data.Models;
using DrinksUI.Dtos.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace DrinksUI.Data.Services
{
    public class DrinkService
    {
        private readonly DrinkContext _drinkContext;
        private readonly IQueryable<IngredientModel> _availableIngredients;
        private readonly IQueryable<DrinkModel> _availableDrinks;

        public DrinkService(DrinkContext drinkContext)
        {
            _drinkContext = drinkContext;
            _drinkContext.Database.EnsureCreated();

            _availableIngredients = _drinkContext.MachinesSlots.Select(slot => slot.Ingredient);
            _availableDrinks = _drinkContext.Drinks.Where(drink => drink.Addies.All(addie => _availableIngredients.Contains(addie.Ingredient)));
        }

        public async Task<(IDrink, bool)> GetDrink(int id)
        {
            var result = await _drinkContext.Drinks
                                    .Include(drink => drink.Addies)
                                    .ThenInclude(addie => addie.Ingredient)
                                    .Where(y => y.Id == id)
                                    .FirstOrDefaultAsync();
            var available = _availableDrinks.Select(drink => drink.Id).Contains(id);

            return (result.GetDto, available);
        }

        public Task<IEnumerable<IDrinkShortDescription>> GetShortDescriptions()
        {
            return Task.FromResult(_availableDrinks.Select(drink => drink.GetShortDto).AsEnumerable());
        }

        public Task<IEnumerable<IIngredient>> GetAllIngredients()
        {
            return Task.FromResult(_drinkContext.Ingredients.Select(ingredient => ingredient.GetDto).AsEnumerable());
        }

        public Task<IEnumerable<IIngredient>> GetAvailableIngredients()
        {
            return Task.FromResult(_availableIngredients.Select(ingredient => ingredient.GetDto).AsEnumerable());
        }

        public async Task<string> AddMockData()
        {

            return await _drinkContext.AddMockData();
        }

        public async Task<string> DeleteMockData()
        { 
            return await _drinkContext.DeleteMockData();
        }
    }
}