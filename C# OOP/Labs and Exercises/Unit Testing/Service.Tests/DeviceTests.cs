using NUnit.Framework;
using Service.Models.Devices;
using Service.Models.Parts;
using System;

namespace Service.Tests
{
    public class DeviceTests
    {
        private Device laptop;
        private Device PC;
        private Device phone;

        [SetUp]
        public void Setup()
        {
            laptop = new Laptop("Lenovo");
            PC = new PC("Dell");
            phone = new Phone("iPhone");
        }

        [Test]
        public void TestConstructorInitialize()
        {
            Assert.IsNotNull(laptop);
            Assert.IsNotNull(PC);
            Assert.IsNotNull(phone);
        }

        [Test]
        public void Test_Constructor_Sets_Properly()
        {
            Assert.AreEqual("Lenovo", laptop.Make);
            Assert.AreEqual("Dell", PC.Make);
            Assert.AreEqual("iPhone", phone.Make);
        }

        [Test]
        public void Make_Property_Throws_Exception()
        {
            Assert.Throws<ArgumentException>(() => laptop = new Laptop(""));
            Assert.Throws<ArgumentException>(() => PC = new PC(""));
            Assert.Throws<ArgumentException>(() => phone = new Phone(""));
        }

        [Test]
        public void Parts_Property_Works_Properly()
        {
            Assert.AreEqual(0, laptop.Parts.Count);
            Assert.AreEqual(0, PC.Parts.Count);
            Assert.AreEqual(0, phone.Parts.Count);
        }

        [Test]
        public void Test_Add_Part_Method()
        {
            var laptopPart = new LaptopPart("Ssd",1m);
            laptop.AddPart(laptopPart);

            var pcPart = new PCPart("Ram", 1m);
            PC.AddPart(pcPart);

            var phonePart = new PhonePart("Mic", 1m);
            phone.AddPart(phonePart);

            Assert.AreEqual(1, laptop.Parts.Count);
            Assert.AreEqual(1, PC.Parts.Count);
            Assert.AreEqual(1, phone.Parts.Count);
            var parts = laptop.Parts;
            Assert.That(parts, Has.Member(laptopPart));

        }

        [Test]
        public void Add_Part_Throws_Exception()
        {
            var laptopPart = new LaptopPart("Ssd", 1m);
            laptop.AddPart(laptopPart);

            var pcPart = new PCPart("Ram", 1m);
            PC.AddPart(pcPart);

            var phonePart = new PhonePart("Mic", 1m);
            phone.AddPart(phonePart);

            Assert.Throws<InvalidOperationException>(() => laptop.AddPart(phonePart));
            Assert.Throws<InvalidOperationException>(() => PC.AddPart(phonePart));
            Assert.Throws<InvalidOperationException>(() => phone.AddPart(laptopPart));
        }

        [Test]
        public void Remove_Part_Method_Works_Properly()
        {
            var laptopPart = new LaptopPart("Ssd", 1m);
            laptop.AddPart(laptopPart);

            var pcPart = new PCPart("Ram", 1m);
            PC.AddPart(pcPart);

            var phonePart = new PhonePart("Mic", 1m);
            phone.AddPart(phonePart);

            laptop.RemovePart(laptopPart.Name);
            PC.RemovePart(pcPart.Name);
            phone.RemovePart(phonePart.Name);

            Assert.AreEqual(0, laptop.Parts.Count);
            Assert.AreEqual(0, PC.Parts.Count);
            Assert.AreEqual(0, phone.Parts.Count);
        }

        [Test]
        public void Remove_Part_Throws_Argument_Exception()
        {
            Assert.Throws<ArgumentException>(() => laptop.RemovePart(""));
            Assert.Throws<ArgumentException>(() => PC.RemovePart(""));
            Assert.Throws<ArgumentException>(() => phone.RemovePart(""));
        }

        [Test]
        public void Remove_Part_Throws_Invalid_Operation_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => laptop.RemovePart("Gosho"));
            Assert.Throws<InvalidOperationException>(() => PC.RemovePart("Gosho"));
            Assert.Throws<InvalidOperationException>(() => phone.RemovePart("Gosho"));
        }

        [Test]
        public void Repair_Parts_Works_Correctly()
        {
            var laptopPart = new LaptopPart("Ssd", 1m,true);
            laptop.AddPart(laptopPart);

            var pcPart = new PCPart("Ram", 1m,true);
            PC.AddPart(pcPart);

            var phonePart = new PhonePart("Mic", 1m,true);
            phone.AddPart(phonePart);

            laptop.RepairPart(laptopPart.Name);
            PC.RepairPart(pcPart.Name);
            phone.RepairPart(phonePart.Name);

            Assert.IsFalse(laptopPart.IsBroken);
            Assert.IsFalse(pcPart.IsBroken);
            Assert.IsFalse(phonePart.IsBroken);
        }

        [Test]
        public void Repair_Parts_Throws_Argument_Exception()
        {
            Assert.Throws<ArgumentException>(() => laptop.RepairPart(""));
            Assert.Throws<ArgumentException>(() => PC.RepairPart(""));
            Assert.Throws<ArgumentException>(() => phone.RepairPart(""));
        }

        [Test]
        public void Repair_Parts_Throws_Invalid_Operation_Exception_For_Null_Part()
        {
            Assert.Throws<InvalidOperationException>(() => laptop.RepairPart("Gosho"));
            Assert.Throws<InvalidOperationException>(() => PC.RepairPart("Gosho"));
            Assert.Throws<InvalidOperationException>(() => phone.RepairPart("Gosho"));
        }

        [Test]
        public void Repair_Parts_Throws_Invalid_Operation_Exception_For_Not_Broken_Part()
        {
            var laptopPart = new LaptopPart("Ssd", 1m, false);
            laptop.AddPart(laptopPart);

            var pcPart = new PCPart("Ram", 1m, false);
            PC.AddPart(pcPart);

            var phonePart = new PhonePart("Mic", 1m, false);
            phone.AddPart(phonePart);

            Assert.Throws<InvalidOperationException>(() => laptop.RepairPart(laptopPart.Name));
            Assert.Throws<InvalidOperationException>(() => PC.RepairPart(pcPart.Name));
            Assert.Throws<InvalidOperationException>(() => phone.RepairPart(phonePart.Name));
        }
    }
}
