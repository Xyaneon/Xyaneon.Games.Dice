using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Xyaneon.Games.Dice.Test
{
    [TestClass]
    public class D12Test
    {
        [TestMethod]
        public void Constructor_Default_ShouldInitializeFaceCountTo12()
        {
            var die = new D12();

            Assert.AreEqual(12, die.FaceCount);
        }

        [TestMethod]
        public void Constructor_Seed_ShouldInitializeFaceCountTo12()
        {
            var die = new D12(123);

            Assert.AreEqual(12, die.FaceCount);
        }
    }
}
