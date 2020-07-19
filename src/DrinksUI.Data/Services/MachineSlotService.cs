using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}