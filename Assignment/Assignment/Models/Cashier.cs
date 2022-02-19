namespace Assignment.Model
{
    using System;
    using System.Linq;
    using System.Text;

    public static class Cashier
    {
        public static string Print(Cart cart)
        {
            var sb = new StringBuilder();
            decimal sum = 0;
            decimal discount = 0;

            sb.AppendLine("Date:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.AppendLine("---Products---");
            foreach (var product in cart.Products)
            {
                var type = product.GetType().Name;
                sb.Append("\n" + product.Name + " " + product.Brand);
                var amount = cart.AmountOfProducts[product.Name];
                var price = product.Price.ToString("F2");
                var amountPrice = product.Price * (decimal)amount;
                var infoPrint = ($"\n{amount} x ${price} = ${amountPrice.ToString("F")}");


                switch (type)
                {
                    case "Appliance":
                        var model = product.GetType().GetProperty("Model").GetValue(product, null);
                        sb.Append($" {model}");
                        sb.AppendLine(infoPrint);

                        if (product.Price > decimal.Parse("999.99"))
                        {
                            discount += GetNonPerishableDiscount(DateTime.Now, amountPrice, sb, type);
                        }
                        break;

                    case "Clothes":
                        {
                            var size = product.GetType().GetProperty("Size").GetValue(product, null);
                            var color = product.GetType().GetProperty("Color").GetValue(product, null);
                            sb.Append($" {size} {color}");
                            sb.AppendLine(infoPrint);
                            discount += GetNonPerishableDiscount(DateTime.Now, amountPrice, sb, type);
                        }
                        break;

                    case "Beverage":
                        sb.AppendLine(infoPrint);
                        discount += GetPerishableDiscount(DateTime.Now, GetExpDate(product), amountPrice, sb);
                        break;

                    case "Food":
                        sb.AppendLine(infoPrint);
                        discount += GetPerishableDiscount(DateTime.Now, GetExpDate(product), amountPrice, sb);
                        break;
                }


                sum += amountPrice;
            }
            sb.AppendLine("\n" + "-----------------------------------------------------------------------------------");
            sb.AppendLine("\n" + "SUBTOTAL: $" + sum.ToString("F"));
            if (discount > 0) sb.AppendLine("DISCOUNT: -$" + (discount.ToString("F2")));
            sb.AppendLine("\n" + "Total: $" + (sum - discount).ToString("F2"));
            return sb.ToString().TrimEnd();

        }
        private static DateTime GetExpDate(Product product)
        {
            var expDate = product.GetType().GetProperty("ExpirationDate").GetValue(product, null);
            return Convert.ToDateTime(expDate);
        }

        private static decimal GetPerishableDiscount(DateTime now,DateTime exp,decimal price,StringBuilder sb)
        {
            decimal discount = 0;
            if (now.Month == exp.Month)
            {
                if (now.Day < exp.Day && exp.Day - now.Day <= 5)
                {
                    discount += (decimal)((double)price * 0.3);
                    sb.AppendLine($"#discount 30% - $" + ((double)price * 0.30).ToString("F"));
                }
                else if (now.Day == exp.Day)
                {
                    discount += (decimal)((double)price * 0.7);
                    sb.AppendLine($"#discount 70% - $" + ((double)price * 0.70).ToString("F"));
                }
            }

            return discount;
        }
        private static decimal GetNonPerishableDiscount(DateTime now, decimal price, StringBuilder sb,string type)
        {
            decimal discount = 0;
            if(type== "Appliance")
            {
                if ((int)now.DayOfWeek == 6 || (int)now.DayOfWeek == 0)
                {
                    discount += (decimal)((double)price * 0.07);
                    sb.AppendLine($"#discount 7% - $" + ((double)price * 0.07).ToString("F"));
                }
            }
            else if(type== "Clothes")
            {
                if (new[] { 2, 3, 4, 5, 6 }.Contains((int)DateTime.Now.DayOfWeek))
                {
                    discount += (decimal)((double)price * 0.10);
                    sb.AppendLine($"#discount 10% - $" + ((double)price * 0.10).ToString("F2"));
                }
            }
            return discount;
        }

    }
}
