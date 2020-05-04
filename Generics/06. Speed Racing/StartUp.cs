using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace DefiningClasses
{
   public class StartUp
    {
       public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var carArrg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Car car = new Car()
                {
                    Model = carArrg[0],
                    FuelAmount = double.Parse(carArrg[1]),
                    FuelConsumptionPerKilometer = double.Parse(carArrg[2])
                };

               if(cars.Where(c => c.Model == carArrg[0]).FirstOrDefault() == null)
                {
                    cars.Add(car);
                }
            }

            string command;
            while((command = Console.ReadLine()) != "End")
            {
                var carSpec = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var carModel = carSpec[1];
                var amoutOfKm = carSpec[2];

                var selected = cars.Where(c => c.Model == carModel).FirstOrDefault();

                var isPossible = selected.Move(selected, int.Parse(amoutOfKm));

                if (!isPossible)
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }

            }
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }            
        }
    }
}
