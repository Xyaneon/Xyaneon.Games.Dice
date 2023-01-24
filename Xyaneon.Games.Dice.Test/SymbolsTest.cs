using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Xyaneon.Games.Dice.Test
{
    [TestClass]
    public class SymbolsTest
    {
        [TestMethod]
        public void GetD6ValueForSymbol_ShouldThrowForInvalidSymbol()
        {
            var actualException = Assert.ThrowsException<ArgumentOutOfRangeException>(() => {
                Symbols.getD6ValueForSymbol('X');
            });

            Assert.IsTrue(actualException.Message.Contains("The provided symbol is not a valid standard D6 symbol."));
        }

        [TestMethod]
        [DataRow('⚀', 1)]
        [DataRow('⚁', 2)]
        [DataRow('⚂', 3)]
        [DataRow('⚃', 4)]
        [DataRow('⚄', 5)]
        [DataRow('⚅', 6)]
        public void GetD6ValueForSymbol_ShouldReturnCorrectValueForSymbol(char symbol, int expected)
        {
            int actual = Symbols.getD6ValueForSymbol(symbol);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(7)]
        public void GetSymbolForD6Value_ShouldThrowForInvalidValue(int value)
        {
            var actualException = Assert.ThrowsException<ArgumentOutOfRangeException>(() => {
                Symbols.getSymbolForD6Value(value);
            });

            Assert.IsTrue(actualException.Message.Contains("The provided value is not a valid standard D6 value."));
        }

        [TestMethod]
        [DataRow('⚀', 1)]
        [DataRow('⚁', 2)]
        [DataRow('⚂', 3)]
        [DataRow('⚃', 4)]
        [DataRow('⚄', 5)]
        [DataRow('⚅', 6)]
        public void GetSymbolForD6Value_ShouldReturnCorrectSymbolForValue(char expected, int value)
        {
            char actual = Symbols.getSymbolForD6Value(value);

            Assert.AreEqual(expected, actual);
        }
    }
}
