using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitRider rider;
        private UnitMotorcycle motorcycle;

        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
            motorcycle = new UnitMotorcycle("BMW", 100, 2000);
            rider = new UnitRider("Pesho", motorcycle);
        }

        [Test]
        public void ConstructorInitializeProperly()
        {
            Assert.IsNotNull(raceEntry);
        }

        [Test]
        public void CounterPropertyWorksCorrectly()
        {
            var expected = 0;
            var actual = this.raceEntry.Counter;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestAddRiderThrowsExceptionForNullRider()
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddRider(null));
        }

        [Test]
        public void TestAddRiderThrowsExceptionForNoRiderWithThisName()
        {
            this.raceEntry.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddRider(rider));
        }

        [Test]
        public void TestAddRiderChangesCount()
        {
            this.raceEntry.AddRider(rider);

            var expected = 1;
            var actual = this.raceEntry.Counter;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestAddRiderRetursCorrectMessage()
        {

            var expected = $"Rider {rider.Name} added in race.";
            var actual = this.raceEntry.AddRider(rider);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalculateAverageHorsePowerThrowsException()
        {
            this.raceEntry.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void TestCalculateAverageHorseReturnsCorrectValue()
        {
            var otherMotorcycle = new UnitMotorcycle("Honda", 60, 1600);
            var otherRider = new UnitRider("Gosho", otherMotorcycle);

            this.raceEntry.AddRider(rider);
            this.raceEntry.AddRider(otherRider);

            var expected = 80;
            var actual = this.raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(expected, actual);
        }
    }
}