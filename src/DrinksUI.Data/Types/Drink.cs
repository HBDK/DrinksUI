using DrinksUI.Dtos;
using System.Collections.Generic;

namespace DrinksUI.Data.Types
{
    public class Drink
    {
        public IList<Addi> Addis { get; set; }
        public string Name { get; set; }
        public string description { get; set; }

        public Drink(params Ingredient[] ingredients)
        {
            Addis = new List<Addi>();

            foreach (var ingredient in ingredients)
            {
                Addis.Add(new Addi(){Ingredient = ingredient, Amount = new Amount(){Unit = Unit.CL, value = 1}});
            }
        }

        public Drink()
        {
            
        }
    }
}