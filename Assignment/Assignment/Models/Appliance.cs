namespace Assignment.Model
{
    using System;

    public class Appliance : Product
    {
        public Appliance(string name, string brand, decimal price,string model, DateTime productionDate, double weight) : base(name, brand, price)
        {
            Model = model;
            ProductionDate = productionDate;
            Weight = weight;
        }

        public string Model  { get; set; }
        public DateTime ProductionDate { get; set; }
        public double Weight { get; set; }
    }
}
