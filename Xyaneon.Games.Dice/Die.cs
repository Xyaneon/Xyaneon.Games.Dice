using System;
using System.Collections.Generic;
using System.Linq;

namespace Xyaneon.Games.Dice
{
    /// <summary>
    /// A generic die class.
    /// </summary>
    /// <typeparam name="TFace">The type of faces the die will have.</typeparam>
    /// <remarks>
    /// Each <see cref="Die{TFace}"/> instance gets its own internal random
    /// number generator used for determining roll results.
    /// </remarks>
    public class Die<TFace>
    {
        private const string ArgumentException_LessThanOneFace = "A die must have at least one face.";
        private const string ArgumentNullException_Faces = "The collection of faces for the die cannot be null.";
        private const string ArgumentOutOfRangeException_LessThanOneRoll = "The number of times to roll the die must be at least one.";

        /// <summary>
        /// Initializes a new instance of the <see cref="Die{TFace}"/> class
        /// using the provided collection of faces.
        /// </summary>
        /// <param name="faces">The faces the die will have.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faces"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="faces"/> does not contain at least one element.
        /// </exception>
        /// <seealso cref="Die{TFace}.Die(IEnumerable{TFace}, int)"/>
        public Die(IEnumerable<TFace> faces)
        {
            if (faces == null)
            {
                throw new ArgumentNullException(nameof(faces), ArgumentNullException_Faces);
            }

            if (faces.Count() < 1)
            {
                throw new ArgumentException(ArgumentException_LessThanOneFace, nameof(faces));
            }

            FaceList = new List<TFace>(faces).AsReadOnly();
            Random = new Random();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Die{TFace}"/> class
        /// using the provided collection of faces and seed value.
        /// </summary>
        /// <param name="faces">The faces the die will have.</param>
        /// <param name="seed">The seed to use for this die's random number generator. This is the same value you would pass to the constructor of the <see cref="System.Random"/> class.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faces"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="faces"/> does not contain at least one element.
        /// </exception>
        /// <remarks>
        /// If a seed is provided to the constructor, then the result of each
        /// <see cref="Roll"/> call made in sequence will be predetermined by
        /// the seed value provided.
        /// </remarks>
        /// <seealso cref="Die{TFace}.Die(IEnumerable{TFace})"/>
        /// <seealso cref="Random.Random(int)"/>
        public Die(IEnumerable<TFace> faces, int seed)
        {
            if (faces == null)
            {
                throw new ArgumentNullException(nameof(faces), ArgumentNullException_Faces);
            }

            if (faces.Count() < 1)
            {
                throw new ArgumentException(ArgumentException_LessThanOneFace, nameof(faces));
            }

            FaceList = new List<TFace>(faces).AsReadOnly();
            Random = new Random(seed);
        }

        /// <summary>
        /// Gets the number of faces this die has.
        /// </summary>
        public int FaceCount { get => Faces.Count(); }

        /// <summary>
        /// Gets the read-only collection of faces this die has.
        /// </summary>
        public IEnumerable<TFace> Faces { get => FaceList; }

        private IReadOnlyList<TFace> FaceList { get; }

        private Random Random { get; }

        /// <summary>
        /// Rolls this die and returns the result.
        /// </summary>
        /// <returns>The result of the die roll as a <typeparamref name="TFace"/> value.</returns>
        /// <remarks>
        /// If a seed was provided to the constructor, then the result of each
        /// <see cref="Roll"/> call made in sequence will be predetermined by
        /// the seed value provided.
        /// </remarks>
        /// <seealso cref="Roll(int)"/>
        public TFace Roll()
        {
            return FaceList.ElementAt(Random.Next(0, FaceList.Count()));
        }

        /// <summary>
        /// Rolls this die the requested number of times, and returns an
        /// enumerable collection of the roll results.
        /// </summary>
        /// <param name="times">How many times to roll this die.</param>
        /// <returns>A collection of the roll results, in order of each roll performed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="times"/> is less than one.
        /// </exception>
        /// <seealso cref="Roll"/>
        public IEnumerable<TFace> Roll(int times)
        {
            if (times < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(times), times, ArgumentOutOfRangeException_LessThanOneRoll);
            }

            for (int i = 0; i < times; i++)
            {
                yield return Roll();
            }
        }
    }
}
