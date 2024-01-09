namespace DND.BL.Services.Dice;

public class DiceService : IDiceService
{
    /// <inheritdoc />
    public int GetRandomNumber(int maxValue)
        => Random.Shared.Next(1, maxValue + 1); 
}