using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

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

        [TestMethod]
        [Timeout(1000)]
        public void Roll_Void_ShouldReturnElementInFaceList()
        {
            IList<int> faces = new int[] { 1, 2, 3 };
            var die = new Die<int>(faces);

            for (int i = 0; i < 1000; i++)
            {
                var actual = die.Roll();
                CollectionAssert.Contains(faces.ToList(), actual);
            }
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void Roll_Times_ShouldThrowForNonPositiveArguments(int times)
        {
            IList<int> faces = new int[] { 1, 2, 3 };
            var die = new Die<int>(faces);

            var actualException = Assert.ThrowsException<ArgumentOutOfRangeException>(() => {
                _ = die.Roll(times).ToList();
            });

            Assert.IsTrue(actualException.Message.Contains("The number of times to roll the die must be at least one."));
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [Timeout(1000)]
        public void Roll_Times_ShouldReturnExpectedNumberOfElementsInFaceList(int times)
        {
            IList<int> faces = new int[] { 1, 2, 3 };
            var die = new Die<int>(faces);

            for (int i = 0; i < 1000; i++)
            {
                IEnumerable<int> actual = die.Roll(times);

                Assert.IsNotNull(actual);
                Assert.AreEqual(times, actual.Count());
                foreach (int element in actual)
                {
                    CollectionAssert.Contains(faces.ToList(), element);
                }
            }
        }
    }
}
