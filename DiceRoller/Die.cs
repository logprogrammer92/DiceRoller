using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller;

/// <summary>
/// This represents a die used in games or simulations,
/// with a configurable number of sides.
/// </summary>
/// <remarks> 
/// The <see cref="Die"/> class models a standard die, allowing the number of sides that
/// can be used for games, random number generation, or other scenarios requiring dice rolls.
/// </remarks>

public class Die
{
    private const byte MAX_SIDES = 20;
    private static readonly Random rand = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="Die"/> class 
    /// with a specified number of sides.
    /// </summary>
    /// <param name="numSides">
    /// The number of sides for the die. Must be greater than zero.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when invalid number of sides is provided</exception>
    public Die(byte numSides)
    {
        if (numSides <= 0 || numSides > MAX_SIDES)
        {
            throw new ArgumentOutOfRangeException(nameof(numSides)
                , $"{nameof(numSides)} must be greater than 0 and less than 21");
        }
        NumberOfSides = numSides;

        // Forces the die to start as a random number
        Roll();
    }
    /// <summary>
    /// Gets the number of sides of the die.
    /// </summary>
    public byte NumberOfSides { get; init; }

    /// <summary>
    /// The current face up value for the die.
    /// </summary>
    public byte FaceUpValue { get; private set; }

    /// <summary>
    /// Simulates rolling the die and returns the resulting face-up value.
    /// </summary>
    /// <remarks>The face-up value is randomly determined based on the number of sides of the die. The value
    /// is updated internally and can be retrieved using the <see cref="FaceUpValue"/> property.</remarks>
    /// <returns>A byte representing the face-up value of the die after the roll. the value will be between 1 and the number
    /// of sides of the die, inclusive.</returns>
    public byte Roll()
    {
        FaceUpValue = Convert.ToByte(rand.Next(1, NumberOfSides + 1));

        return FaceUpValue;
    }
}