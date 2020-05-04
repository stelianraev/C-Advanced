namespace Problem_7._Raw_Data
{
   public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public string Model { get; set; }
        public Engine Engine { get; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; }

        public override string ToString()
        {
            return $"{this.Model}";
        }
    }
}
