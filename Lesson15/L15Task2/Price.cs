namespace L15Task2
{
    internal struct Price
    {
        public string ProductName;
        public string StoreName;
        public double ProductPrice;


        public Price(
            string productName, 
            string storeName, 
            double productPrice
        )
        {
            ProductName = productName;
            StoreName = storeName;
            ProductPrice = productPrice;
        }

        public override string ToString()
        {
            return $"Название магазина: {StoreName}, название товара: {ProductName}, цена: {ProductPrice}";
        }
    }
}