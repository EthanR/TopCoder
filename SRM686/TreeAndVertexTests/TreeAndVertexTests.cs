using System;
using SRM686;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SRM686Tests
{
    [TestClass]
    public class TreeAndVertexTests
    {
        [TestMethod]
        public void GetTestCaseOne()
        {
            // Arrange
            int[] tree = {0, 0, 0};
            int expected = 3;

            // Act
            int result = TreeAndVertex.get(tree);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetTestCaseTwo()
        {
            // Arrange
            int[] tree = {0, 1, 2, 3};
            int expected = 2;

            // Act
            int result = TreeAndVertex.get(tree);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetTestCaseThree()
        {
            // Arrange
            int[] tree = {0, 0, 2, 2};
            int expected = 3;

            // Act
            int result = TreeAndVertex.get(tree);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetTestCaseFour()
        {
            // Arrange
            int[] tree = {0, 0, 0, 1, 1, 1};
            int expected = 4;

            // Act
            int result = TreeAndVertex.get(tree);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetTestCaseFive()
        {
            // Arrange
            int[] tree = {0, 1, 2, 0, 1, 5, 6, 1, 7, 4, 2, 5, 5, 8, 6, 2, 14, 12, 18, 10, 0, 6, 18, 2, 20, 11, 0, 11, 7, 12, 17, 3, 18, 31, 14, 34, 30, 11, 9};
            int expected = 5;

            // Act
            int result = TreeAndVertex.get(tree);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
