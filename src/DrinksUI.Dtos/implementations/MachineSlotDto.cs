using DrinksUI.Dtos.Interfaces;

namespace DrinksUI.Dtos.implementations
{
    public class MachineSlotDto : IMachineSlot
    {
        public int Id { get; }
        public IIngredient Ingredient { get; set; }
        public int Proof { get; set; }
        public AddieType DispensingType { get; set; }

        public MachineSlotDto(int id, IIngredient ingredient, int proof, AddieType dispensingType)
        {
            Id = id;
            Ingredient = ingredient;
            Proof = proof;
            DispensingType = dispensingType;
        }

        public MachineSlotDto(IMachineSlot slot)
        {
            Id = slot.Id;
            Ingredient = slot.Ingredient;
            Proof = slot.Proof;
            DispensingType = slot.DispensingType;
        }
    }
}