using System.Collections.Generic;
using System.Linq;

namespace Xyaneon.Games.Dice
{
    /// <summary>
    /// A standard D10 (ten-sided pentagonal trapezohedron) die.
    /// </summary>
    public sealed class D10 : Die<int>
    {
        private static readonly IEnumerable<int> StandardFaces = Enumerable.Range(1, 10);

        /// <summary>
        /// Initializes a new instance of the <see cref="D10"/> class.
        /// </summary>
        public D10() : base(StandardFaces) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="D10"/> class
        /// using the provided seed value.
        /// </summary>
        /// <param name="seed">The seed to use for this die's random number generator. This is the same value you would pass to the constructor of the <see cref="System.Random"/> class.</param>
        public D10(int seed) : base(StandardFaces, seed) { }
    }
}
