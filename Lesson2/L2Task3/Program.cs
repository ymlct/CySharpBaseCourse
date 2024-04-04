using System;
using System.Collections.Generic;

namespace L2Task3
{
     /*
    Урок 2, Задание 4
    Создайте проект по шаблону Console Application.
    Требуется:
    - Создать класс Invoice.
    - В теле класса создать три поля int account, string customer, string provider которые должны
      быть проинициализированы один раз (при создании экземпляра данного класса) без возможности их
      дальнейшего изменения.
    - В теле класса создать два закрытых поля string article, int quantity
    - Создать метод расчета стоимости заказа с НДС и без НДС.
    - Написать программу, которая выводит на экран сумму оплаты заказанного товара с НДС или без НДС.
     */
    
    internal class Program
    {
        public static void Main(string[] args)
        {

            var catalog = new Catalog();
            var gasoline = new Product(name: "АИ-95", article: "100");

            catalog.AddProduct(productToAdd: gasoline, price: 52.6);

            var invoice = new Invoice(account: 1, customer: "Ярослав", provider: "ПАО Газпром");
            
            invoice.AddProductToBasket(gasoline.Article, 25);
            
            invoice.Calculate(catalog);
        }
        
        internal class Invoice
        {

            private readonly int _account;
            private readonly string _customer;
            private readonly string _provider;
            
            public int Account => _account;
            public string Customer => _customer;
            public string Provider => _provider;
            
            private string _article;
            private int _quantity;


            public Invoice(int account, string customer, string provider)
            {
                _account = account;
                _customer = customer;
                _provider = provider;
            }

            public void AddProductToBasket(string article, int quantity)
            {
                _article = article;
                _quantity = quantity;
            }
            
            public void Calculate(Catalog catalog)
            {
                var product = catalog.GetProductByArticle(_article);
                var price = catalog.GetPriceForProduct(product);
                var totalAmount = price * _quantity;
                
                Console.WriteLine($"Чек № {Account} \nПоставщик: {Provider}\nПокупатель: {Customer}\nТовар: {product.Name} (арт. {product.Article}) x {_quantity} = {totalAmount} руб.");

            }

        }

        internal class Catalog
        {

            private readonly Dictionary<string, Product> _productsByArticle = new Dictionary<string, Product>();
            private readonly Dictionary<string, double> _pricesByArticle = new Dictionary<string, double>();

            public void AddProduct(Product productToAdd, double price)
            {
                if (price < 0)
                {
                    Console.WriteLine("Цена товара не может быть отрицательной!");
                    return;
                }
                if (!_productsByArticle.ContainsKey(productToAdd.Article))
                {
                    var article = productToAdd.Article;
                    _productsByArticle.Add(article, productToAdd);
                    _pricesByArticle.Add(article, price);
                }
                else
                {
                    Console.WriteLine("Товар уже добавлен в каталог!");
                }
            }
            
            public Product GetProductByArticle(string article)
            {
                Product result = null;
                if (_productsByArticle.TryGetValue(article, out Product product))
                {
                    result =  product;
                }
                else
                {
                    Console.WriteLine("Товара с указанным артикулом нет в каталоге!");
                }

                return result;
            }
            
            public double GetPriceForProduct(Product product)
            {
                if (_pricesByArticle.TryGetValue(product.Article, out double price))
                {
                    return price;
                }
                else
                {
                    Console.WriteLine("Товара с указанным артикулом нет в каталоге!");
                }

                return -1;
            }
        }
        
        internal class Product
        {
            public string Article { get; private set;  }
            public string Name { get; private set;  }

            public Product(string article, string name)
            {
                Article = article;
                Name = name;
            }
        }
        
    }
}