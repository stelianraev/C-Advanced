using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
   public class Engine
    {
        public string Model { get; set; }
        public int Power { get; set; }
        public int? Displacement { get; set; }
        public string Efficiency { get; set; }        

        public override string ToString()
        {
            string displacementStr = this.Displacement.HasValue ? this.Displacement.ToString() : "n/a";
            string efficiencyStr = String.IsNullOrEmpty(this.Efficiency) ? "n/a" : this.Efficiency;

            return $"  {this.Model}:\n    Power: {this.Power}\n" +
                $"    Displacement: {displacementStr}\n    Efficiency: {efficiencyStr}";
        }
    }
}
