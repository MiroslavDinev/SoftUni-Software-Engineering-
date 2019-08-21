namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private Spaceship spaceship;

        [SetUp]
        public void SetUp()
        {
            this.spaceship = new Spaceship("NASA", 1);
        }

        [Test]
        public void TestConstructorInitializeProperly()
        {
            Assert.IsNotNull(spaceship);
        }

        [Test]
        public void AssertCountWorksProperly()
        {
            var expected = 0;

            Assert.AreEqual(expected, this.spaceship.Count);
        }

        [Test]
        public void TestNameProperly()
        {
            var expectedName = "NASA";
            var actualName = this.spaceship.Name;

            Assert.AreEqual(expectedName, actualName);

            
        }

        [Test]
        public void TestNameAndCapacitySetProperly()
        {
            var expectedCapacity = 1;
            var actualCapacity = this.spaceship.Capacity;

            Assert.AreEqual(expectedCapacity, actualCapacity);

        }

        [Test]
        public void NamePropertyThrowsEmptyException()
        {
            Assert.Throws<ArgumentNullException>(() => this.spaceship = new Spaceship("", 1));
        }

        [Test]
        public void NamePropertyThrowsNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this.spaceship = new Spaceship(null, 1));
        }

        [Test]
        public void CapacityPropertyThrowsException()
        {
            Assert.Throws<ArgumentException>(() => this.spaceship = new Spaceship("NASA", -1));
        }

        [Test]
        public void AddMethodWorksProperly()
        {
            this.spaceship.Add(new Astronaut("Pesho", 21));

            var expectedCount = 1;
            var actualCount = this.spaceship.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddMethodThrowsFullCapacityException()
        {
            this.spaceship = new Spaceship("NASA", 0);

            Assert.Throws<InvalidOperationException>(() => this.spaceship.Add(new Astronaut("Ivan", 18)));
        }

        [Test]
        public void AddMethodThrowsAstronautExistException()
        {
            this.spaceship = new Spaceship("Nasa", 10);

            this.spaceship.Add(new Astronaut("Pesho", 21));

            Assert.Throws<InvalidOperationException>(() => this.spaceship.Add(new Astronaut("Pesho", 21)));
        }

        [Test]
        public void TestRemoveAstronautMethodReturnTrue()
        {
            this.spaceship.Add(new Astronaut("Pesho", 21));

            bool actual = this.spaceship.Remove("Pesho");

            Assert.IsTrue(actual);
        }

        [Test]
        public void TestAstronautMethodReturnsFalse()
        {
            bool actual = this.spaceship.Remove("Pesho");

            Assert.IsFalse(actual);
        }
    }
}