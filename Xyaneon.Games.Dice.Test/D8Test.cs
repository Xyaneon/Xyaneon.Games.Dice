using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Xyaneon.Games.Dice.Test
{
    [TestClass]
    public class D8Test
    {
        [TestMethod]
        public void Constructor_Default_ShouldInitializeFaceCountTo8()
        {
            var die = new D8();

            Assert.AreEqual(8, die.FaceCount);
        }

        [TestMethod]
        public void Constructor_Seed_ShouldInitializeFaceCountTo8()
        {
            var die = new D8(123);

            Assert.AreEqual(8, die.FaceCount);
        }
    }
}
