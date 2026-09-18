using NUnit.Framework;
using Library;
using System;

namespace LibraryTests
{
    [TestFixture]
    public class GateTests
    {
        [Test]
        public void TestsLogicValues()
        {
            // Arrange 
            ILogicValue trueVal = new TrueValue();
            ILogicValue falseVal = new FalseValue();

            // Act
            bool actualTrue = trueVal.Value;
            bool actualFalse = falseVal.Value;

            // Assert 
            Assert.That(actualTrue, Is.True);
            Assert.That(actualFalse, Is.False);
        }
        [Test]
        public void TestAndGate()
        {
            // Arrange
            ILogicValue t = new TrueValue();
            ILogicValue f = new FalseValue();

            // Act & Assert 
            Assert.That(new AndGate(t, t).Output().Value, Is.True);
            Assert.That(new AndGate(t, f).Output().Value, Is.False);
            Assert.That(new AndGate(f, t).Output().Value, Is.False);
            Assert.That(new AndGate(f, f).Output().Value, Is.False);
        }
        [Test]
        public void TestNotGate()
        {
            // Arrange
            ILogicValue t = new TrueValue();
            ILogicValue f = new FalseValue();

            // Act & Assert (Evaluación de la tabla de verdad para NOT)
            Assert.That(new NotGate(t).Output().Value, Is.False);
            Assert.That(new NotGate(f).Output().Value, Is.True);
        }

        [Test]
        public void TestConnectedGatesWithGateOutput()
        {
            // Arrange (Preparación: armar el circuito con compuertas conectadas)
            // Circuito: NOT (True AND False)
            ILogicValue t = new TrueValue();
            ILogicValue f = new FalseValue();

            IGate andGate = new AndGate(t, f);
            ILogicValue andOutput = new GateOutput(andGate);
            IGate notGate = new NotGate(andOutput);

            // Act 
            bool result = notGate.Output().Value;

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestGarageGate()
        {
            // Arrange
            ILogicValue t = new TrueValue();
            ILogicValue f = new FalseValue();

            // Act y Assert
            Assert.That(new GarageGate(f, f, f).Output().Value, Is.False);
            Assert.That(new GarageGate(f, f, t).Output().Value, Is.True);
            Assert.That(new GarageGate(f, t, f).Output().Value, Is.False);
            Assert.That(new GarageGate(f, t, t).Output().Value, Is.False);
            Assert.That(new GarageGate(t, f, f).Output().Value, Is.False);
            Assert.That(new GarageGate(t, f, t).Output().Value, Is.False);
            Assert.That(new GarageGate(t, t, f).Output().Value, Is.False);
            Assert.That(new GarageGate(t, t, t).Output().Value, Is.True);
        }


    }
}
    