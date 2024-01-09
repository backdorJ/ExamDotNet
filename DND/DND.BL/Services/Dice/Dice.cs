namespace DND.BL.Services.Dice;

public class Dice : IDice
{
    /// <inheritdoc />
    public int GetRandomNumber(int maxValue)
        => Random.Shared.Next(1, maxValue + 1); 
}