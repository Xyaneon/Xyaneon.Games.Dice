using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Xyaneon.Games.Dice.Test
{
    [TestClass]
    public class D6Test
    {
        [TestMethod]
        public void Constructor_Default_ShouldInitializeFaceCountTo6()
        {
            var die = new D6();

            Assert.AreEqual(6, die.FaceCount);
        }

        [TestMethod]
        public void Constructor_Seed_ShouldInitializeFaceCountTo6()
        {
            var die = new D6(123);

            Assert.AreEqual(6, die.FaceCount);
        }
    }
}
