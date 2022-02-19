namespace Assignment
{
    using System;
    using Assignment.Model;

    class Program
    {
        static void Main(string[] args)
        {
            var Milk = new Beverage("Milk", "HappyCows", decimal.Parse("0.99"), DateTime.Parse("2022-02-25"));
            var Apple = new Food("Apple", "SweetFruits", decimal.Parse("1.50"), DateTime.Parse("2022-02-22"));
            var Shirt = new Clothes("T-Shirt", "Dolce&Gabbana", decimal.Parse("49.9"), "Black", "M");
            var Laptop = new Appliance("Laptop", "Acer", decimal.Parse("1999"), "Predator", DateTime.Parse("2022-01-12"), 1.50);

            var cart = new Cart();

            cart.Products.Add(Milk);
            cart.AmountOfProducts.Add(Milk.Name, 1);
            cart.Products.Add(Apple);
            cart.AmountOfProducts.Add(Apple.Name,2.45);
            cart.Products.Add(Shirt);
            cart.AmountOfProducts.Add(Shirt.Name, 2);
            cart.Products.Add(Laptop);
            cart.AmountOfProducts.Add(Laptop.Name,1);


            Console.WriteLine(Cashier.Print(cart));
        }
    }
}

