using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace DefiningClasses
{
   public class StartUp
    {
       public static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int engineLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineLines; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string engineModel = input[0];
                int enginePower = int.Parse(input[1]);
                int? engineDisplacement = null;
                string engineEfficiency = null;

                if(input.Length == 3)
                {
                    if (Char.IsLetter(input[2][0]))
                    {
                        engineEfficiency = input[2];
                    }
                    else
                    {
                        engineDisplacement = int.Parse(input[2]);
                    }
                }
                else if(input.Length > 3 && input.Length <= 4)
                {
                    engineDisplacement = int.Parse(input[2]);
                    engineEfficiency = input[3];
                }

                Engine engine = new Engine()
                {
                    Model = engineModel,
                    Power = enginePower,
                    Displacement = engineDisplacement,
                    Efficiency = engineEfficiency
                };

                engines.Add(engine);
            }           

            int carLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < carLines; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string carModel = input[0];
                Engine carEngine = engines.Where(e => e.Model == input[1]).FirstOrDefault();
                int? carWeight = null;
                string carColor = null;

                if(input.Length == 3)
                {
                    if (Char.IsLetter(input[2][0]))
                    {
                        carColor = input[2];
                    }
                    else
                    {
                        carWeight = int.Parse(input[2]);
                    }
                }
                else if(input.Length > 3 && input.Length <= 4)
                {
                    carWeight = int.Parse(input[2]);
                    carColor = input[3];
                }              

                Car car = new Car()
                {
                    Model = carModel,
                    Engine = carEngine,
                    Weight = carWeight,
                    Color = carColor
                };

                cars.Add(car);
            }
            
            Console.WriteLine(String.Join(Environment.NewLine, cars));
        }
    }
}
