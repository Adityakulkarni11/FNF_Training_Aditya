namespace UnitTestingComponenet
{
    [TestClass]
    public sealed class MathTest
    {
        [TestMethod]
        public void AddPositiveNumbersTest()
        {
            //Arrange
            var component = new UnitTestingLib.MathClass();
            var a = 10;
            var b = 10;
            var expected = 20;

            //Act
            var result = component.AddFunc(a, b);

            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void SubtractPositiveNumberTest()
        {
            // Arrange
            var math = new UnitTestingLib.MathClass();
            double a = 10;
            double b = 5;
            double expected = 5;
            // Act
            double result = math.SubtractFunc(a, b);
            // Assert
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void MultiplyPositiveNumberTest()
        {
            // Arrange
            var math = new UnitTestingLib.MathClass();
            double a = 10;
            double b = 5;
            double expected = 50;
            // Act
            double result = math.MultiplyFunc(a, b);
            // Assert
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void DividePositiveNumberTest()

        {
            // Arrange
            var math = new UnitTestingLib.MathClass();
            double a = 10;
            double b = 5;
            double expected = 2;
            // Act
            double result = math.DivideFunc(a, b);
            // Assert
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void SquarePositiveNumberTest()
        {
            // Arrange
            var math = new UnitTestingLib.MathClass();
            double a = 5;
            double expected = 25;
            // Act
            double result = math.SquareFunc(a);
            // Assert
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void SquareRootPositiveNumberTest()
        {
            // Arrange
            var math = new UnitTestingLib.MathClass();
            double a = 25;
            double expected = 5;
            // Act
            double result = math.SquareRootFunc(a);
            // Assert
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void DivideRootPositiveNumberTest()
        {
            // Arrange
            var math = new UnitTestingLib.MathClass();
            double a = 25;
            double b = 5;
            double expected = 1;
            // Act
            double result1 = math.SquareRootFunc(a);
            double result2 = math.DivideFunc(result1, b);
            // Assert
            Assert.AreEqual(expected, result2);

        }

        [TestMethod]
        public void MultiplySubtractPositiveNumberTest()
        {
            // Arrange
            var math = new UnitTestingLib.MathClass();
            double a = 10;
            double b = 5;
            double c = 20;
            double expected = -30;
            // Act
            double result1 = math.MultiplyFunc(a, b);
            double result2 = math.SubtractFunc(c, result1);
            // Assert
            Assert.AreEqual(expected, result2);

        }

        [TestMethod]
        public void MultiplyMultiplyPositiveNumberTest()
        {
            // Arrange
            var math = new UnitTestingLib.MathClass();
            double a = 10;
            double b = 5;
            double c = 2;
            double expected = 100;
            // Act
            double result1 = math.MultiplyFunc(a, b);
            double result2 = math.MultiplyFunc(result1, c);
            // Assert
            Assert.AreEqual(expected, result2);

        }
    }
}
