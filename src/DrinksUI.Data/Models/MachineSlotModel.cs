using DrinksUI.Dtos;
using DrinksUI.Dtos.implementations;
using DrinksUI.Dtos.Interfaces;

namespace DrinksUI.Data.Models
{
    public class MachineSlotModel
    {
        public int Id { get; set; }
        public IngredientModel Ingredient { get; set; }
        public int Proof { get; set; }
        public AddieType DispensingType { get; set; }

        public IMachineSlot GetDto => new MachineSlotDto(Id, Ingredient.GetDto, Proof, DispensingType);
    }
}