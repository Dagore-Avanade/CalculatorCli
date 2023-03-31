using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CalculatorCli;

namespace CalculatorCliTest
{
    [TestClass]
    public class OperatorTest
    {
        [TestMethod]
        public void ReturnsTrueOnCreationSucceded()
        {
            bool creation = Operator.TryParse("+", out Operator operation);
            Assert.IsTrue(creation);
            Assert.IsNotNull(operation);
        }
        [TestMethod]
        public void ReturnsFalseOnCreationFailed()
        {
            bool creation = Operator.TryParse("Patata", out Operator operation);
            Assert.IsFalse(creation);
            Assert.IsNull(operation);
        }
        [TestMethod]
        public void PerformsAdditionProperly()
        {
            if (Operator.TryParse("+", out Operator operation))
            {
                string expected = "La suma de 2 y 3 es 5.";
                string actual = operation.PerformOperation(2, 3);
                Assert.AreEqual(expected, actual);
            }
        }
        [TestMethod]
        public void PerformsSubtractionProperly()
        {
            if (Operator.TryParse("-", out Operator operation))
            {
                string expected = "La resta de 2 y 3 es -1.";
                string actual = operation.PerformOperation(2, 3);
                Assert.AreEqual(expected, actual);
            }
        }
        [TestMethod]
        public void PerformsMultiplicationProperly()
        {
            if (Operator.TryParse("*", out Operator operation))
            {
                string expected = "La multiplicación de 2 y 3 es 6.";
                string actual = operation.PerformOperation(2, 3);
                Assert.AreEqual(expected, actual);
            }
        }
        [TestMethod]
        public void PerformsDivisionProperly()
        {
            if (Operator.TryParse("/", out Operator operation))
            {
                string expected = "La división de 2 y 3 es 0,67.";
                string actual = operation.PerformOperation(2, 3);
                Assert.AreEqual(expected, actual);
            }
        }
        [TestMethod]
        public void CannotDivideByZero()
        {
            if (Operator.TryParse("/", out Operator operation))
            {
                string expected = "Lo siento, no puedo dividir entre cero.";
                string actual = operation.PerformOperation(2, 0);
                Assert.AreEqual(expected, actual);
            }
        }
        [TestMethod]
        public void PerformsPowProperly()
        {
            if (Operator.TryParse("^", out Operator operation))
            {
                string expected = "2 elevado a 3 es 8.";
                string actual = operation.PerformOperation(2, 3);
                Assert.AreEqual(expected, actual);
            }
        }
        [TestMethod]
        public void IndexInReturnsMinusOneOnNotFoundOperator()
        {
            string s = "Un string cualquiera. A random string.";
            int expected = -1;
            int actual = Operator.IndexIn(s);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IndexInFoundFirstOperator()
        {
            string s = "+-*/";
            int expected = 0;
            int actual = Operator.IndexIn(s);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IndexInFoundOperatorAtEndOfString()
        {
            string s = "BlaBlaBla.   Bla!!. /";
            int expected = s.Length - 1;
            int actual = Operator.IndexIn(s);
            Assert.AreEqual(expected, actual);
        }
    }
}
