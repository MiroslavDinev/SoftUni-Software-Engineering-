namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private Phone phone;

        [SetUp]
        public void SetUp()
        {
            this.phone = new Phone("iPhone", "X");
        }

        [Test]
        public void TestConstructorInitialize()
        {
            Assert.IsNotNull(phone);
        }

        [Test]
        public void TestPropertiesAreSetCorrectly()
        {
            var expectedMake = "iPhone";
            var expectedModel = "X";

            Assert.AreEqual(expectedMake, phone.Make);
            Assert.AreEqual(expectedModel, phone.Model);
        }

        [Test]
        public void MakePropertyThrowsException()
        {
            Assert.Throws<ArgumentException>(() => phone = new Phone("", "X"));
        }

        [Test]
        public void ModelPropertyThrowsException()
        {
            Assert.Throws<ArgumentException>(() => phone = new Phone("iPhone", ""));
        }

        [Test]
        public void CountReturnCorrectResult()
        {
            var expected = 0;
            Assert.AreEqual(expected, this.phone.Count);
        }

        [Test]
        public void AddContactWorksProperly()
        {
            this.phone.AddContact("Pesho", "123");

            var expected = 1;

            Assert.AreEqual(expected, this.phone.Count);
        }

        [Test]
        public void AddContactThrowsException()
        {
            this.phone.AddContact("Pesho", "123");

            Assert.Throws<InvalidOperationException>(() => this.phone.AddContact("Pesho", "123"));
        }

        [Test]
        public void CallWorksProperly()
        {
            this.phone.AddContact("Pesho", "123");

            var expected = $"Calling Pesho - 123...";
            var actual = this.phone.Call("Pesho");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CallMethodThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => this.phone.Call("Gosho"));
        }
    }
}