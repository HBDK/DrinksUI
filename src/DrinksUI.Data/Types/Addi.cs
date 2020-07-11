using DrinksUI.Dtos;

namespace DrinksUI.Data.Types
{
    public class Addi
    {
        public Ingredient Ingredient;
        public Amount Amount;
        public string Name => Ingredient.ToString();
        public AddiType type;

        public string Display { get => $"{Amount.value} {Amount.Unit} - {Ingredient.Type}";}
    }
}