using System;

namespace Kata
{
    public class Product
    {
        public string Name { get; set; }
        public int UPC { get; set; }
        public double Price { get; set; }
        public double FinalPrice { get; set; }
        public double TaxAmount { get; set; }
        public double DiscountAmount { get; set; }
        public Product(string Name, int UPC, double Price)
        {
            this.Name = Name;
            this.UPC = UPC;
            this.Price = Math.Round(Validator.ValidatePrice(Price), 2);
        }

        public override string ToString() => $"Book with name ='{Name}', UPC = {UPC}, price =${Price}.";
    }
}
