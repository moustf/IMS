namespace IMS.BL
{
    public class Product
    {
        public Product()
        {
            _lastProductId = GenerateNewProductId();
        }

        private static int _lastProductId = 0;
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }

        private static int GenerateNewProductId() => ++_lastProductId;
    }
}