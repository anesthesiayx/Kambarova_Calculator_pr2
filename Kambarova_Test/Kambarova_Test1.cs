using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kambarova_libb;
using System;

namespace Kambarova_Test
{
    [TestClass]
    public sealed class Kambarova_Test1
    {
        [TestClass]
        public class KambarovaTests
        {
            [TestMethod]
            public void Add_WithValidNumbers_ReturnsSum()
            {
                // Arrange
                double a = 2;
                double b = 3;
                double expected = 5;

                // Act
                double actual = Kambarova.Add(a, b);

                // Assert
                Assert.AreEqual(expected, actual, 0.001, "Addition not performed correctly");
            }

            [TestMethod]
            public void Subtract_WithValidNumbers_ReturnsDifference()
            {
                // Arrange
                double a = 10;
                double b = 4;
                double expected = 6;

                // Act
                double actual = Kambarova.Subtract(a, b);

                // Assert
                Assert.AreEqual(expected, actual, 0.001, "Subtraction not performed correctly");
            }

            [TestMethod]
            public void Multiply_WithValidNumbers_ReturnsProduct()
            {
                // Arrange
                double a = 6;
                double b = 7;
                double expected = 42;

                // Act
                double actual = Kambarova.Multiply(a, b);

                // Assert
                Assert.AreEqual(expected, actual, 0.001, "Multiplication not performed correctly");
            }

            [TestMethod]
            public void Divide_WithValidNumbers_ReturnsQuotient()
            {
                // Arrange
                double a = 15;
                double b = 3;
                double expected = 5;

                // Act
                double actual = Kambarova.Divide(a, b);

                // Assert
                Assert.AreEqual(expected, actual, 0.001, "Division not performed correctly");
            }

            [TestMethod]
            public void Power_WithValidNumbers_ReturnsPower()
            {
                // Arrange
                double a = 2;
                double b = 3;
                double expected = 8;

                // Act
                double actual = Kambarova.Power(a, b);

                // Assert
                Assert.AreEqual(expected, actual, 0.001, "Power operation not performed correctly");
            }

            [TestMethod]
            public void Execute_WhenOperatorIsUnknown_ShouldThrowArgumentException()
            {
                // Arrange
                double x = 5;
                char op = '%';
                double y = 2;

                // Act and assert
                Assert.ThrowsException<ArgumentException>(() => Kambarova.Execute(x, op, y));
            }
        }
    }
}




