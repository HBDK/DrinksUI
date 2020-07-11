using DrinksUI.Dtos;
using DrinksUI.Data.Models;

namespace DrinksUI.Data.Types
{
    public class Ingredient
    {
        public string Type;
        public AddiType AddiType;
        public Unit Unit;

        public static Ingredient Create(IngredientModel model) => new Ingredient(){Type = model.Type, AddiType = model.AddiType, Unit = model.Unit};
    }
}