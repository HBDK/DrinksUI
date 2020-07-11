using DrinksUI.Dtos;
using System.Collections.Generic;
using DrinksUI.Data.Models;
using System.Linq;

namespace DrinksUI.Data.Types
{
    public class Drink
    {
        public List<Addi> Addis { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
        public string ImageUrl {get; set;}

        public static Drink Create(DrinkModel Model) => new Drink(){Addis = Model.Addis.Select(x => Addi.Create(x)).ToList(), Name = Model.Name, description = Model.description, ImageUrl = Model.ImageUrl ?? ""};
    }
}