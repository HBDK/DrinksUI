using DrinksUI.Dtos;

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
    }
}