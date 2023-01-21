using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Xyaneon.Games.Dice.Test
{
    [TestClass]
    public class DieTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_Faces_ShouldNotCreateDieFromNullCollection()
        {
            Die<int> die = new Die<int>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Faces_ShouldNotCreateDieFromEmptyCollection()
        {
            Die<int> die = new Die<int>(new int[] { });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_FacesAndSeed_ShouldNotCreateDieFromNullCollection()
        {
            Die<int> die = new Die<int>(null, 123);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_FacesAndSeed_ShouldNotCreateDieFromEmptyCollection()
        {
            Die<int> die = new Die<int>(new int[] { }, 123);
        }

        [TestMethod]
        public void FaceCount_ShouldReturnCorrectNumberOfFaces()
        {
            Die<int> die = new Die<int>(new int[] { 1, 2, 3 });

            Assert.AreEqual(3, die.FaceCount);
        }
    }
}
