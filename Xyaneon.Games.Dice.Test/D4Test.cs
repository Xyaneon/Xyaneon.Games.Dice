using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Xyaneon.Games.Dice.Test
{
    [TestClass]
    public class D4Test
    {
        [TestMethod]
        public void Constructor_Default_ShouldInitializeFaceCountTo4()
        {
            var die = new D4();

            Assert.AreEqual(4, die.FaceCount);
        }

        [TestMethod]
        public void Constructor_Seed_ShouldInitializeFaceCountTo4()
        {
            var die = new D4(123);

            Assert.AreEqual(4, die.FaceCount);
        }
    }
}
