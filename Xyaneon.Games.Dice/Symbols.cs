using System;
using System.Collections.Generic;
using System.Linq;

namespace Xyaneon.Games.Dice
{
    /// <summary>
    /// Provides common Unicode symbols for dice.
    /// </summary>
    /// <remarks>
    /// See https://en.wikipedia.org/wiki/Miscellaneous_Symbols for where
    /// these symbols came from.
    /// </remarks>
    public static class Symbols
    {
        /// <summary>
        /// The Unicode symbol for the 1-pip face of a standard D6 die.
        /// </summary>
        public const char D6Face1 = '⚀';

        /// <summary>
        /// The Unicode symbol for the 2-pip face of a standard D6 die.
        /// </summary>
        public const char D6Face2 = '⚁';

        /// <summary>
        /// The Unicode symbol for the 3-pip face of a standard D6 die.
        /// </summary>
        public const char D6Face3 = '⚂';

        /// <summary>
        /// The Unicode symbol for the 4-pip face of a standard D6 die.
        /// </summary>
        public const char D6Face4 = '⚃';

        /// <summary>
        /// The Unicode symbol for the 5-pip face of a standard D6 die.
        /// </summary>
        public const char D6Face5 = '⚄';

        /// <summary>
        /// The Unicode symbol for the 6-pip face of a standard D6 die.
        /// </summary>
        public const char D6Face6 = '⚅';

        private static readonly IReadOnlyDictionary<int, char> valuesToD6Faces;

        private static readonly IReadOnlyDictionary<char, int> d6FacesToValues;

        /// <summary>
        /// Initializes static members of the <see cref="Symbols"/> class.
        /// </summary>
        static Symbols()
        {
            valuesToD6Faces = new Dictionary<int, char>()
            {
                { 1, D6Face1 },
                { 2, D6Face2 },
                { 3, D6Face3 },
                { 4, D6Face4 },
                { 5, D6Face5 },
                { 6, D6Face6 }
            };

            d6FacesToValues = valuesToD6Faces.ToDictionary((keyValuePair) => keyValuePair.Value, (keyValuePair) => keyValuePair.Key);
        }

        /// <summary>
        /// Gets the corresponding integer value of the provided Unicode D6
        /// symbol.
        /// </summary>
        /// <param name="symbol">The Unicode D6 symbol for the die value.</param>
        /// <returns>The corresponding integer value of the provided Unicode D6 symbol.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="symbol"/> is not a valid standard D6 symbol.
        /// </exception>
        /// <seealso cref="getSymbolForD6Value(int)"/>
        public static int getD6ValueForSymbol(char symbol)
        {
            try
            {
                return d6FacesToValues[symbol];
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentOutOfRangeException(nameof(symbol), symbol, "The provided symbol is not a valid standard D6 symbol.");
            }
        }

        /// <summary>
        /// Gets the corresponding Unicode D6 symbol for the provided integer
        /// value.
        /// </summary>
        /// <param name="value">The die value as an <see cref="Int32"/> value.</param>
        /// <returns>The corresponding Unicode D6 symbol.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="value"/> is not a valid standard D6 value.
        /// </exception>
        /// <seealso cref="getD6ValueForSymbol(char)"/>
        public static char getSymbolForD6Value(int value)
        {
            try
            {
                return valuesToD6Faces[value];
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, "The provided value is not a valid standard D6 value.");
            }
        }
    }
}
