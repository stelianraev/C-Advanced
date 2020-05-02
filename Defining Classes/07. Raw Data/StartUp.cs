using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_7._Raw_Data
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string carModel = input[0];

                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);

                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                double tire1Pressure = double.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);

                double tire2Pressure = double.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);

                double tire3Pressure = double.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);

                double tire4Pressure = double.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Tire tire1 = new Tire(tire1Pressure, tire1Age);
                Tire tire2 = new Tire(tire2Pressure, tire2Age);
                Tire tire3 = new Tire(tire3Pressure, tire3Age);
                Tire tire4 = new Tire(tire4Pressure, tire4Age);

                Tire[] tires = new Tire[]
                {
                    tire1,
                    tire2,
                    tire3,
                    tire4
                };

                Car car = new Car(carModel, engine, cargo, tires);

                cars.Add(car);
            }

            var command = Console.ReadLine();

            if (command == "fragile")
            {
                List<Car> extractedCarsFragile = cars
                     .Where(c => c.Cargo.Type == command
                     && c.Tires.Any(p => p.Pressure < 1))
                     .ToList();

                Console.WriteLine(String.Join(Environment.NewLine, extractedCarsFragile));                 
            }
            else if (command == "flamable")
            {
                var extractedCarsFlamable = cars
                .Where(c => c.Cargo.Type == command)
                .Where(c => c.Engine.Power > 250)
                .ToList();

                Console.WriteLine(String.Join(Environment.NewLine, extractedCarsFlamable));

            }
        }
    }
}
