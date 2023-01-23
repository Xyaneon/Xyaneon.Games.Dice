using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Xyaneon.Games.Dice.Test
{
    [TestClass]
    public class DieTest
    {
        [TestMethod]
        public void Constructor_Faces_ShouldNotCreateDieFromNullCollection()
        {
            var actualException = Assert.ThrowsException<ArgumentNullException>(() => {
                _ = new Die<int>(null);
            });

            Assert.IsTrue(actualException.Message.Contains("The collection of faces for the die cannot be null."));
        }

        [TestMethod]
        public void Constructor_Faces_ShouldNotCreateDieFromEmptyCollection()
        {
            var actualException = Assert.ThrowsException<ArgumentException>(() => {
                _ = new Die<int>(new int[] { });
            });

            Assert.IsTrue(actualException.Message.Contains("A die must have at least one face."));
        }

        [TestMethod]
        public void Constructor_Faces_ShouldInitializeFaceCountToCorrectNumberOfFaces()
        {
            Die<int> die = new Die<int>(new int[] { 1, 2, 3 });

            Assert.AreEqual(3, die.FaceCount);
        }

        [TestMethod]
        public void Constructor_FacesAndSeed_ShouldNotCreateDieFromNullCollection()
        {
            var actualException = Assert.ThrowsException<ArgumentNullException>(() => {
                _ = new Die<int>(null, 123);
            });

            Assert.IsTrue(actualException.Message.Contains("The collection of faces for the die cannot be null."));
        }

        [TestMethod]
        public void Constructor_FacesAndSeed_ShouldNotCreateDieFromEmptyCollection()
        {
            var actualException = Assert.ThrowsException<ArgumentException>(() => {
                _ = new Die<int>(new int[] { }, 123);
            });

            Assert.IsTrue(actualException.Message.Contains("A die must have at least one face."));
        }

        [TestMethod]
        public void Constructor_FacesAndSeed_ShouldInitializeFaceCountToCorrectNumberOfFaces()
        {
            Die<int> die = new Die<int>(new int[] { 1, 2, 3 }, 123);

            Assert.AreEqual(3, die.FaceCount);
        }
    }
}
