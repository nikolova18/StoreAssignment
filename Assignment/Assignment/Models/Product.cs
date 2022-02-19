namespace Assignment.Model
{
    public abstract class Product
    {
        protected Product(string name, string brand, decimal price)
        {
            Name = name;
            Brand = brand;
            Price = price;
        }

        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
    }
}
