using System.Collections.Generic;
using System.Threading.Tasks;
using DrinksUI.Data.Types;
using DrinksUI.Dtos;
using System.Linq;

namespace DrinksUI.Data.Servies
{
    public class DrinkService
    {
        private List<Drink> _drinks;
        private List<Ingredient> _ingredients;

        public DrinkService()
        {
            _ingredients = new List<Ingredient>(){
                new Ingredient(){Type = "Vodka", AddiType = AddiType.PushDosed, Unit = Unit.CL}, //0
                new Ingredient(){Type = "Gin", AddiType = AddiType.PushDosed, Unit = Unit.CL}, // 1
                new Ingredient(){Type = "Rum", AddiType = AddiType.PushDosed, Unit = Unit.CL}, // 2
                new Ingredient(){Type = "Tequila", AddiType = AddiType.PushDosed, Unit = Unit.CL}, // 3
                new Ingredient(){Type = "Cola", AddiType = AddiType.Poured, Unit = Unit.CL}, // 4
                new Ingredient(){Type = "Club soda", AddiType = AddiType.Poured, Unit = Unit.CL}, // 5
                new Ingredient(){Type = "Apple juice", AddiType = AddiType.Poured, Unit = Unit.CL}, // 6
                new Ingredient(){Type = "Salt", AddiType = AddiType.Extra, Unit = Unit.Pinches}, // 7
                new Ingredient(){Type = "Lemon Slice", AddiType = AddiType.Extra, Unit = Unit.Pcs} // 8
            };


            _drinks = new List<Drink>(){
                new Drink(_ingredients[0], _ingredients[6]){Name = "screwDriver", description = "dsaf"},
                new Drink(_ingredients[2], _ingredients[4]){Name = "Rum n coke", description = "dsaf"},
            };
        }

        public Task<Drink> GetDrink(int id)
        {
            return Task.FromResult(_drinks[id]);
        }

        public Task<IEnumerable<IDrinkShortDescription>> GetShortDescriptions()
        {
            IEnumerable<IDrinkShortDescription> result = _drinks.Select(x => new DrinkShortDescription(){Name = x.Name, id = _drinks.IndexOf(x), ImageUrl = ""}).AsEnumerable();
            return Task.FromResult(result);
        }
    }
}