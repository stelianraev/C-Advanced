using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private Car car;
        private int capacity;
        private List<Car> cars;
        private int count;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new List<Car>();
        }

        public Car Car
        {
            get
            {
                return this.car;
            }
            set
            {
                this.car = value;
            }
        }
        public List<Car> Cars
        {
            get
            {
                return this.cars;
            }
        }
        public int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public int Count
        {
            get
            {
                return this.Cars.Count;
            }
        }

        public string AddCar(Car Car)
        {
            Car existingCar = Cars.Where(c => c.RegistrationNumber == Car.RegistrationNumber).FirstOrDefault();

            if (existingCar != null)
            {
                return $"Car with that registration number, already exists!";
            }
            else if (cars.Count == capacity)
            {
                return "Parking is full!";
            }
            else
            {
                Cars.Add(Car);
                return $"Successfully added new car {Car.Make} {Car.RegistrationNumber}";
            }
        }
        public string RemoveCar(string RegistrationNumber)
        {
            var res = Cars.Where(c => c.RegistrationNumber == RegistrationNumber).FirstOrDefault();

            if (this.Cars.Contains(res))
            {
                this.Cars.Remove(res);

                return $"Successfully removed {RegistrationNumber}";
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }
        public Car GetCar(string RegistrationNumbere)
        {
            return this.Cars.Where(c => c.RegistrationNumber == RegistrationNumbere).FirstOrDefault();
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            for (int i = 0; i < RegistrationNumbers.Count; i++)
            {
                Car car = this.Cars.Where(c => c.RegistrationNumber == RegistrationNumbers[i]).FirstOrDefault();

                if (car != null)
                {
                    this.Cars.Remove(car);
                }
            }
        }
    }
}
