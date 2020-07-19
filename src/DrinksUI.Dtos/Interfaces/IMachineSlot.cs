namespace DrinksUI.Dtos.Interfaces
{
    public interface IMachineSlot
    {
        int Id { get; }
        IIngredient Ingredient { get; set; }
        int Proof { get; set; }
        AddieType DispensingType { get; set; }
    }
}