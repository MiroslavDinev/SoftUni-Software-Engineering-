namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        [SetUp]
        public void Setup()
        {
            var softPark = new SoftPark();
        }

        [Test]
        public void Parking_Count_Works_Correctly()
        {
            var softPark = new SoftPark();
            var expected = 12;
            var actual = softPark.Parking.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Park_Car_Throw_Exception_For_Invalid_Parking_Spot()
        {
            Car car = new Car("Audi", "A8");
            var softPark = new SoftPark();

            Assert.Throws<ArgumentException>(() => softPark.ParkCar("C5", car));
        }

        [Test]
        public void Test_Park_Car_Throw_Exception_For_Taken_Parking_Spot()
        {
            Car car = new Car("Audi", "A8");
            var softPark = new SoftPark();

            softPark.ParkCar("C4", car);

            Car anotherCar = new Car("BMW", "X6");

            Assert.Throws<ArgumentException>(() => softPark.ParkCar("C4", anotherCar));
        }

        [Test]
        public void Test_Park_Car_Throw_Exception_For_Parked_Car()
        {
            Car car = new Car("Audi", "A8");
            var softPark = new SoftPark();

            softPark.ParkCar("C4", car);

            Assert.Throws<InvalidOperationException>(() => softPark.ParkCar("C3", car));
        }

        [Test]
        public void Park_Car_Works_Properly()
        {
            Car car = new Car("Audi", "A8");
            var softPark = new SoftPark();            

            var expected = $"Car:{car.RegistrationNumber} parked successfully!";
            var actual = softPark.ParkCar("C4", car);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Remove_Car_Throws_Parking_Spot_Doesnt_Exist_Exception()
        {
            Car car = new Car("Audi", "A8");
            var softPark = new SoftPark();

            Assert.Throws<ArgumentException>(() => softPark.RemoveCar("C5", car));
        }

        [Test]
        public void Remove_Car_Throws_Parked_Car_Doesnt_Exist_Exception()
        {
            Car car = new Car("Audi", "A8");
            var softPark = new SoftPark();

            Assert.Throws<ArgumentException>(() => softPark.RemoveCar("C3", car));
        }

        [Test]
        public void Remove_Car_Works_Properly()
        {
            Car car = new Car("Audi", "A8");
            var softPark = new SoftPark();

            softPark.ParkCar("A3", car);

            var expected = $"Remove car:{car.RegistrationNumber} successfully!";
            var actual = softPark.RemoveCar("A3", car);

            Assert.AreEqual(expected, actual);
        }
    }
}