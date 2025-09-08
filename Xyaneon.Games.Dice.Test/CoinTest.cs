using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Xyaneon.Games.Dice.Test
{
    [TestClass]
    public class CoinTest
    {
        [TestMethod]
        public void Constructor_Default_ShouldInitializeFaceCountTo2()
        {
            var coin = new Coin();

            Assert.AreEqual(2, coin.FaceCount);
        }

        [TestMethod]
        public void Constructor_Seed_ShouldInitializeFaceCountTo2()
        {
            var coin = new Coin(123);

            Assert.AreEqual(2, coin.FaceCount);
        }

        [TestMethod]
        [Timeout(1000)]
        public void Flip_Void_ShouldReturnHeadsOrTails()
        {
            IList<CoinFlipResult> sides = new CoinFlipResult[]
            {
                CoinFlipResult.Heads,
                CoinFlipResult.Tails
            };
            var coin = new Coin();

            for (int i = 0; i < 1000; i++)
            {
                var actual = coin.Flip();
                CollectionAssert.Contains(sides.ToList(), actual);
            }
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void Flip_Times_ShouldThrowForNonPositiveArguments(int times)
        {
            var coin = new Coin();

            var actualException = Assert.ThrowsExactly<ArgumentOutOfRangeException>(() =>
            {
                _ = coin.Flip(times).ToList();
            });

            Assert.IsTrue(actualException.Message.Contains("The number of times to roll the die must be at least one."));
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [Timeout(1000)]
        public void Flip_Times_ShouldReturnExpectedNumberOfElementsInFaceList(int times)
        {
            IList<CoinFlipResult> sides = new CoinFlipResult[]
            {
                CoinFlipResult.Heads,
                CoinFlipResult.Tails
            };
            var coin = new Coin();

            for (int i = 0; i < 1000; i++)
            {
                IEnumerable<CoinFlipResult> actual = coin.Flip(times);

                Assert.IsNotNull(actual);
                Assert.AreEqual(times, actual.Count());
                foreach (CoinFlipResult element in actual)
                {
                    CollectionAssert.Contains(sides.ToList(), element);
                }
            }
        }
    }
}
