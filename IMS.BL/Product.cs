using System;

namespace IMS.BL
{
    public class Product
    {
        public Product()
        {
            ProductId = Guid.NewGuid();
        }
        
        public Guid ProductId { get; private set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
    }
}