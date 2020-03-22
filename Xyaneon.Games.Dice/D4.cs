using System.Collections.Generic;
using System.Linq;

namespace Xyaneon.Games.Dice
{
    /// <summary>
    /// A standard D4 (four-sided tetrahedron) die.
    /// </summary>
    public sealed class D4 : Die<int>
    {
        private static readonly IEnumerable<int> StandardFaces = Enumerable.Range(1, 4);

        /// <summary>
        /// Initializes a new instance of the <see cref="D4"/> class.
        /// </summary>
        public D4() : base(StandardFaces) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="D4"/> class
        /// using the provided seed value.
        /// </summary>
        /// <param name="seed">The seed to use for this die's random number generator. This is the same value you would pass to the constructor of the <see cref="System.Random"/> class.</param>
        public D4(int seed) : base(StandardFaces, seed) { }
    }
}
