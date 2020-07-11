using System.Collections.Generic;

namespace DrinksUI.Data.Models
{
    public class DrinkModel
    {
        public int Id { get; set; }
        public List<AddiModel> Addis { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
        public string ImageUrl {get; set;}
    }
}