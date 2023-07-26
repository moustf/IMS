namespace IMS.BL
{
    public class Product
    {
        public Product()
        {
            // is this safe ? what happens if 2 or 3 object of product were created ?
            ProductId = _lastProductId = GenerateNewProductId();
        }

        // single responsibility violation, last product id management is not part of the product concerns
        private static int _lastProductId = 0;

        public int ProductId { get; private set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }

        //you can replace the int with guid to avoid having to manage the last id 
        private static int GenerateNewProductId() => ++_lastProductId;

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}