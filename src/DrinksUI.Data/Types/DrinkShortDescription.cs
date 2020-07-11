using DrinksUI.Dtos;

namespace DrinksUI.Data.Types
{
    public class DrinkShortDescription : IDrinkShortDescription
    {
        public int id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }
    }
}