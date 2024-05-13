using System;

namespace L15Task2
{
    internal class Catalog
    {

        private Price[] _catalog;
        
        private int _count;


        public Catalog(int capacity)
        {
            _catalog = new Price[capacity];
            _count = 0;
        }

        public void AddProduct(
            string productName, 
            string storeName, 
            double productPrice
        )
        {
            _catalog[_count] = new Price(productName, storeName, productPrice);
            _count++;
        }

        public Price[] GetProductsByStoreName(string storeName)
        {
            Price[] intermediateResult = new Price[_count];
            int count = 0;
            
            foreach (var productPrice in _catalog)
            {
                if (storeName == productPrice.StoreName)
                {
                    intermediateResult[count] = productPrice;
                    count++;
                }
            }
        
            if (count == 0) { throw new Exception("Магазина с указанным именем не найдено."); }

            Price[] result = new Price[count];
            
            Array.Copy(intermediateResult, result, count);
            
            return result;
        }
    }
}