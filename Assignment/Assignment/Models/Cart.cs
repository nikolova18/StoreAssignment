namespace Assignment.Model
{
    using System.Collections.Generic;

    public class Cart
    {
        public Cart()
        {
            this.Products = new List<Product>();
            this.AmountOfProducts = new Dictionary<string, double>();
        }
        public List<Product> Products { get; set; }

        public Dictionary<string, double> AmountOfProducts { get; set; }
    }
}
