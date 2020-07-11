using DrinksUI.Dtos;
using DrinksUI.Data.Models;

namespace DrinksUI.Data.Types
{
    public class Addi
    {
        public Ingredient Ingredient;
        public int Amount;
        public string Name => Ingredient.ToString();

        public string Display { get => $"{Amount} {Ingredient.Unit} - {Ingredient.Type}";}
        public string UnitAndName { get => $"{Ingredient.Unit} - {Ingredient.Type}";}
        public bool IsLiquid {get => Ingredient.AddiType != AddiType.Extra;}

        public static Addi Create(AddiModel model) => new Addi(){Ingredient = Ingredient.Create(model.Ingredient), Amount = model.Amount};
    }
}