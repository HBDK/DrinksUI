using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DrinksUI.Data.Models;
using DrinksUI.Dtos;
using DrinksUI.Dtos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DrinksUI.Data.Services
{
    public class MachineSlotService
    {
        private readonly DrinkContext _drinkContext;

        public MachineSlotService(DrinkContext drinkContext)
        {
            _drinkContext = drinkContext;
            _drinkContext.Database.EnsureCreated();
        }

        public async Task<IEnumerable<IMachineSlot>> GetSlots()
        {
            return await _drinkContext.MachinesSlots.Include(slot => slot.Ingredient).Select(slot => slot.GetDto).ToArrayAsync();
        }

        public async Task AddExtra(IIngredient ingredient)
        {
            if (ingredient.AddieType != AddieType.Extra) return;

            var ingredientModel = _drinkContext.Ingredients.FindAsync(ingredient.Id);

            await _drinkContext.MachinesSlots.AddAsync(new MachineSlotModel() { DispensingType = AddieType.Extra, Ingredient = await ingredientModel, Proof = 0 });

            await _drinkContext.SaveChangesAsync();
        }

        public void UpdateIngredient(IMachineSlot slot, string ingredientName)
        {
            var slotModel = _drinkContext.MachinesSlots.Find(slot.Id);

            if (slotModel.Ingredient.Type == ingredientName) return;

            var ingredient = _drinkContext.Ingredients.First( x => x.Type == ingredientName);
            slotModel.Ingredient = ingredient;
            slot.Ingredient = ingredient.GetDto;

            _drinkContext.Update(slotModel);
            _drinkContext.SaveChanges();
        }

        public void UpdateProof(IMachineSlot slot)
        {
            var slotModel = _drinkContext.MachinesSlots.Find(slot.Id);

            slotModel.Proof = slot.Proof;

            _drinkContext.Update(slotModel);

            _drinkContext.SaveChanges();
        }
    }
}