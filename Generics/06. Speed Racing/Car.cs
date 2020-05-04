using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
   public class Car
    {      
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double Travelleddistance { get; set; }

        public bool Move(Car car, int distance)
        {
            if(car.FuelAmount / car.FuelConsumptionPerKilometer >= distance)
            {
                var leftFuelinKm = (car.FuelAmount / car.FuelConsumptionPerKilometer) - distance;

                car.Travelleddistance += distance;
                car.FuelAmount = leftFuelinKm * car.FuelConsumptionPerKilometer;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:F2} {this.Travelleddistance}";
        }
    }
}
