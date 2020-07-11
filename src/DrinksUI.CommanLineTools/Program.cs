using System;
using DrinksUI.Data;
using DrinksUI.Data.Types;
using DrinksUI.Data.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DrinksUI.Dtos;
using System.Linq;

namespace DrinksUI.CommanLineTools
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<DrinkContext>().Options;
            var _drinkContext = new DrinkContext(options);
            _drinkContext.Database.EnsureCreated();

            var _ingredients = new List<IngredientModel>(){
                new IngredientModel(){Type = "Vodka", AddiType = AddiType.PushDosed, Unit = Unit.CL}, //1
                new IngredientModel(){Type = "Gin", AddiType = AddiType.PushDosed, Unit = Unit.CL}, // 2
                new IngredientModel(){Type = "Rum", AddiType = AddiType.PushDosed, Unit = Unit.CL}, // 3
                new IngredientModel(){Type = "Tequila", AddiType = AddiType.PushDosed, Unit = Unit.CL}, // 4
                new IngredientModel(){Type = "Cola", AddiType = AddiType.Poured, Unit = Unit.CL}, // 5
                new IngredientModel(){Type = "Club soda", AddiType = AddiType.Poured, Unit = Unit.CL},  //6
                new IngredientModel(){Type = "Apple juice", AddiType = AddiType.Poured, Unit = Unit.CL}, // 7
                new IngredientModel(){Type = "Orange juice", AddiType = AddiType.Poured, Unit = Unit.CL}, // 8 
                new IngredientModel(){Type = "Salt", AddiType = AddiType.Extra, Unit = Unit.Pinches}, // 9
                new IngredientModel(){Type = "Lemon Slice", AddiType = AddiType.Extra, Unit = Unit.Pcs} // 10
            };

            _drinkContext.AddRange(_ingredients);
            _drinkContext.SaveChanges();

            var _drinks = new List<DrinkModel>();
            
            _drinks.Add(
                new DrinkModel(){Name = "screwDriver", description = "dsaf", Addis = new List<AddiModel>(){
                    new AddiModel(){Ingredient = _ingredients[0], Amount = 2}, 
                    new AddiModel(){Ingredient = _ingredients[7], Amount = 14}} }
            );

            _drinks.Add(
                new DrinkModel(){Name = "Rum n coke", description = "dsaf", Addis = new List<AddiModel>(){
                    new AddiModel(){Ingredient = _ingredients[2], Amount = 2}, 
                    new AddiModel(){Ingredient = _ingredients[4], Amount = 14}} }
            );

            _drinks.Add(
                new DrinkModel(){Name = "Død", description = "dsaf", Addis = new List<AddiModel>(){
                    new AddiModel(){Ingredient = _ingredients[3], Amount = 2}, 
                    new AddiModel(){Ingredient = _ingredients[8], Amount = 1},
                    new AddiModel(){Ingredient = _ingredients[9], Amount = 1},} }
            );

            _drinkContext.AddRange(_drinks);
            _drinkContext.SaveChanges();
 
            var test = _drinkContext.Drinks.Include(x => x.Addis).ThenInclude(Addi => Addi.Ingredient).Where(i => i.Id == 1).FirstOrDefault();
            var test2 = Drink.Create(test);
        }
    }
}
