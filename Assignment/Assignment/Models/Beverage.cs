namespace Assignment.Model
{
    using System;

    public class Beverage : Product
    {
        public Beverage(string name,string brand,decimal price,DateTime expDate) : base(name,brand,price)
        {
            this.ExpirationDate = expDate;
        }
        public  DateTime ExpirationDate { get; set; }

    }
}
