using NUnit.Framework;
using Service.Models.Parts;
using System;

namespace Tests
{
    public class PartTests
    {
        private Part laptopPart;
        private Part PCPart;
        private Part phonePart;

        [SetUp]
        public void Setup()
        {
            laptopPart = new LaptopPart("Ram", 1,true);
            PCPart = new PCPart("Hdd", 1, true);
            phonePart = new PhonePart("Mic", 1, true);
        }

        [Test]
        public void Constructor_Initialize_Correctly()
        {
            Assert.IsNotNull(laptopPart);
            Assert.IsNotNull(PCPart);
            Assert.IsNotNull(phonePart);
        }

        [Test]
        public void Test_Properties_Are_Set_Correctly()
        {
            Assert.AreEqual("Ram", laptopPart.Name);
            Assert.AreEqual(1.5m, laptopPart.Cost);
            Assert.IsTrue(laptopPart.IsBroken);

            Assert.AreEqual("Hdd", PCPart.Name);
            Assert.AreEqual(1.2m, PCPart.Cost);
            Assert.IsTrue(PCPart.IsBroken);

            Assert.AreEqual("Mic", phonePart.Name);
            Assert.AreEqual(1.3m, phonePart.Cost);
            Assert.IsTrue(phonePart.IsBroken);
        }

        [Test]
        public void Name_Property_Throws_Exception()
        {
            Assert.Throws<ArgumentException>(() => laptopPart = new LaptopPart("", 1));
            Assert.Throws<ArgumentException>(() => PCPart = new PCPart("", 1));
            Assert.Throws<ArgumentException>(() => phonePart = new PhonePart("", 1));
        }

        [Test]
        public void Cost_Property_Throws_Exception()
        {
            Assert.Throws<ArgumentException>(() => laptopPart = new LaptopPart("Ram", 0));
            Assert.Throws<ArgumentException>(() => PCPart = new PCPart("Hdd", -1));
            Assert.Throws<ArgumentException>(() => phonePart = new PhonePart("Mic", -100));
        }

        [Test]
        public void Test_Repair_Methood()
        {
            laptopPart.Repair();
            PCPart.Repair();
            phonePart.Repair();

            Assert.IsFalse(laptopPart.IsBroken);
            Assert.IsFalse(PCPart.IsBroken);
            Assert.IsFalse(phonePart.IsBroken);
        }

        [Test]
        public void Test_Report_Method()
        {
            string expectedLaptop = $"{laptopPart.Name} - {laptopPart.Cost:f2}$" + Environment.NewLine +
                $"Broken: {laptopPart.IsBroken}";

            string laptopActual = laptopPart.Report();

            string expectedPc = $"{PCPart.Name} - {PCPart.Cost:f2}$" + Environment.NewLine +
                $"Broken: {PCPart.IsBroken}";

            string PCActual = PCPart.Report();

            string expectedPhone = $"{phonePart.Name} - {phonePart.Cost:f2}$" + Environment.NewLine +
                $"Broken: {phonePart.IsBroken}";

            string phoneActual = phonePart.Report();

            Assert.AreEqual(expectedLaptop, laptopActual);
            Assert.AreEqual(expectedPc, PCActual);
            Assert.AreEqual(expectedPhone, phoneActual);
        }
    }
}