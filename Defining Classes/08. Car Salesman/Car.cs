
using System;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int? Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            string weightStr = this.Weight.HasValue ? this.Weight.ToString() : "n/a";
            string colorStr = String.IsNullOrEmpty(this.Color) ? "n/a" : this.Color;

            return $" {this.Model}:\n{this.Engine}\n  Weight: {weightStr}" +
                $"\n  Color: {colorStr}";
        }
    }
}
