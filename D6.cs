using System.Collections.Generic;
using System.Linq;

namespace Xyaneon.Games.Dice
{
    /// <summary>
    /// A standard D6 (six-sided cubic) die.
    /// </summary>
    public sealed class D6 : Die<int>
    {
        private static readonly IEnumerable<int> StandardFaces = Enumerable.Range(1, 6);

        /// <summary>
        /// Initializes a new instance of the <see cref="D6"/> class.
        /// </summary>
        public D6() : base(StandardFaces) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="D6"/> class
        /// using the provided seed value.
        /// </summary>
        /// <param name="seed">The seed to use for this die's random number generator. This is the same value you would pass to the constructor of the <see cref="System.Random"/> class.</param>
        public D6(int seed) : base(StandardFaces, seed) { }
    }
}
