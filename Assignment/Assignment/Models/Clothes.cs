namespace Assignment.Model
{
    using System.Linq;

    public class Clothes : Product
    {
        public Clothes(string name, string brand, decimal price,string color, string inputsize) : base(name, brand, price)
        {
            this.Color = color;
            if (Sizes.Contains(inputsize)) this.Size = inputsize;
        }

        private string[] Sizes { get; set; } = { "XS", "S", "M", "L", "XL" };
        public string Size { get; set; }
        public string Color { get; set; }
    }
}
