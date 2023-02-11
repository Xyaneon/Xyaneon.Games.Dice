using System.Collections.Generic;
using System.Linq;

namespace Xyaneon.Games.Dice
{
    /// <summary>
    /// A standard D12 (twelve-sided dodecahedron) die.
    /// </summary>
    public sealed class D12 : Die<int>
    {
        private static readonly IEnumerable<int> StandardFaces = Enumerable.Range(1, 12);

        /// <summary>
        /// Initializes a new instance of the <see cref="D12"/> class.
        /// </summary>
        public D12() : base(StandardFaces) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="D12"/> class
        /// using the provided seed value.
        /// </summary>
        /// <param name="seed">The seed to use for this die's random number generator. This is the same value you would pass to the constructor of the <see cref="System.Random"/> class.</param>
        public D12(int seed) : base(StandardFaces, seed) { }
    }
}
