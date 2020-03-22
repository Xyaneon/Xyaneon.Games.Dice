using System;
using System.Collections.Generic;

namespace Xyaneon.Games.Dice
{
    /// <summary>
    /// A standard, fair coin with heads and tails sides.
    /// </summary>
    /// <remarks>
    /// This library considers a coin to be a two-sided die.
    /// </remarks>
    /// <seealso cref="CoinFlipResult"/>
    public sealed class Coin : Die<CoinFlipResult>
    {
        private static readonly IEnumerable<CoinFlipResult> Sides = (IEnumerable<CoinFlipResult>)Enum.GetValues(typeof(CoinFlipResult));

        /// <summary>
        /// Initializes a new instance of the <see cref="Coin"/> class.
        /// </summary>
        public Coin() : base(Sides) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Coin"/> class
        /// using the provided seed value.
        /// </summary>
        /// <param name="seed">The seed to use for this die's random number generator. This is the same value you would pass to the constructor of the <see cref="System.Random"/> class.</param>
        public Coin(int seed) : base(Sides, seed) { }

        /// <summary>
        /// An alias for the inherited <see cref="Die{TFace}.Roll"/> method
        /// specific to coins.
        /// </summary>
        /// <returns>A new <see cref="CoinFlipResult"/> value.</returns>
        /// <seealso cref="Flip(int)"/>
        public CoinFlipResult Flip() => Roll();

        /// <summary>
        /// An alias of the <see cref="Die{TFace}.Roll(int)"/> method
        /// specific to coins.
        /// </summary>
        /// <param name="times">How many times to flip this coin.</param>
        /// <returns>A collection of the flip results, in order of each flip performed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="times"/> is less than one.
        /// </exception>
        /// <seealso cref="Flip"/>
        public IEnumerable<CoinFlipResult> Flip(int times) => Roll(times);
    }
}
