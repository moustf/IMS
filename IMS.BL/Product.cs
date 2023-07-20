namespace IMS.BL
{
    public class Product
    {
        public Product()
        {
            ProductId = _lastProductId = GenerateNewProductId();
        }

        private static int _lastProductId = 0;
        public int ProductId { get; private set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }

        private static int GenerateNewProductId() => ++_lastProductId;
    }
}