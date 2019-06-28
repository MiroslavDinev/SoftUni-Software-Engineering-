namespace SoftUniParking
{
    using System.Collections.Generic;
    using System.Linq;

    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.cars = new List<Car>();
            this.capacity = capacity;
        }

        public int Count
        {
            get
            {
                return this.cars.Count;
            }
        }

        public string AddCar(Car car)
        {
            if(this.cars.Any(x=>x.RegistrationNumber==car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            else if(this.cars.Count>=this.capacity)
            {
                return "Parking is full!";
            }

            else
            {
                this.cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            if(this.cars.Any(x=>x.RegistrationNumber == registrationNumber))
            {
                Car carToRemove = this.cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
                this.cars.Remove(carToRemove);
                return $"Successfully removed {registrationNumber}";
            }

            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            
            Car car = this.cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
            return car;
            
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var regNum in registrationNumbers)
            {
                if(this.cars.Any(x=>x.RegistrationNumber==regNum))
                {
                    Car car = this.cars.FirstOrDefault(x => x.RegistrationNumber == regNum);
                    this.cars.Remove(car);
                }
            }
        }
    }
}
