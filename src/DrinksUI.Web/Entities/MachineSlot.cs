using DrinksUI.Data.Services;
using DrinksUI.Dtos;
using DrinksUI.Dtos.Interfaces;

namespace DrinksUI.Web.Entities
{
    public class MachineSlot : IMachineSlot
    {
        public int Id { get; }
        public IIngredient Ingredient { get; set; }

        public int Proof
        {
            get => _proof;
            set
            {
                _proof = value;
                _machineSlotService.UpdateProof(this);
            }
        }

        public AddieType DispensingType { get; set; }

        private readonly MachineSlotService _machineSlotService;

        public string IngredientPicker
        {
            get => Ingredient.Type;
            set => _machineSlotService.UpdateIngredient(this, value);
        }

        private int _proof;

        public MachineSlot(IMachineSlot slot, MachineSlotService machineSlotService)
        {
            Id = slot.Id;
            Ingredient = slot.Ingredient;
            _proof = slot.Proof;
            DispensingType = slot.DispensingType;

            _machineSlotService = machineSlotService;
        }
    }
}