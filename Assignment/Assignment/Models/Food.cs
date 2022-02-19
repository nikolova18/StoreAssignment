namespace Assignment.Model
{
    using System;

    public class Food : Product
    {
        public Food(string name,string brand,decimal price,DateTime expDate): base(name, brand, price)
        {
            this.ExpirationDate = expDate;
            //prevent errors
        }
        public DateTime ExpirationDate { get; set; }
    }
}
