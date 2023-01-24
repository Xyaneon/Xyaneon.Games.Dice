using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Xyaneon.Games.Dice.Test
{
    [TestClass]
    public class D10Test
    {
        [TestMethod]
        public void Constructor_Default_ShouldInitializeFaceCountTo10()
        {
            var die = new D10();

            Assert.AreEqual(10, die.FaceCount);
        }

        [TestMethod]
        public void Constructor_Seed_ShouldInitializeFaceCountTo10()
        {
            var die = new D10(123);

            Assert.AreEqual(10, die.FaceCount);
        }
    }
}
