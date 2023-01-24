using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Xyaneon.Games.Dice.Test
{
    [TestClass]
    public class D20Test
    {
        [TestMethod]
        public void Constructor_Default_ShouldInitializeFaceCountTo20()
        {
            var die = new D20();

            Assert.AreEqual(20, die.FaceCount);
        }

        [TestMethod]
        public void Constructor_Seed_ShouldInitializeFaceCountTo20()
        {
            var die = new D20(123);

            Assert.AreEqual(20, die.FaceCount);
        }
    }
}
