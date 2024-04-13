using System;

namespace L5Task3
{
    
    /*
    Задание 4
    Создайте проект по шаблону Console Application.
    Требуется:
    - Создать класс Article, содержащий следующие закрытые поля:
        - название товара;
        - название магазина, в котором продается товар;
        - стоимость товара в рублях.
    - Создать класс Store, содержащий закрытый массив элементов типа Article.
    - Обеспечить следующие возможности:
        - вывод информации о товаре по номеру с помощью индекса;
        - вывод на экран информации о товаре, название которого введено с клавиатуры, если таких товаров нет, выдать соответствующее сообщение;
    - Написать программу, вывода на экран информацию о товаре.
    */
    internal class Program
    {
        public static void Main(string[] args)
        {

            Article[] articles =
            {
                new Article(
                    productName: "Процессор",
                    storeName: "Комплектующие для ПК",
                    price: 40000f
                ),
                new Article(
                    productName: "Материнская плата",
                    storeName: "Комплектующие для ПК",
                    price: 25000f
                ),
                new Article(
                    productName: "Видеокарта",
                    storeName: "Комплектующие для ПК",
                    price: 30000f
                )
            };
            Store store = new Store(articles: articles);

            var shouldContinue = true;
            while (shouldContinue)
            {
                Console.WriteLine("\n");
                Console.WriteLine(new string('-', 20));
                Console.WriteLine("\n");

                try
                {
                    Console.WriteLine("Вы можете найти товар в магазине по его названию либо по его номеру.");
                    Console.WriteLine("Для поиска по названию введите '1', для поиска по номеру - '2', для выхода - '0'.");
                    var userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "1":
                            FindProductByName(store: store);
                            break; 
                        
                        case "2":
                            FindProductById(store: store);
                            break; 
                        
                        case "0":
                            shouldContinue = false;
                            break;
                        
                        default: 
                            throw new Exception("");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Введено неверное значение. Попробуйте снова.");
                }
            }

        }
        
        
        private static void FindProductByName(Store store)
        {
            Console.WriteLine("Введите наименование искомого товара.");
            var userInput = Console.ReadLine();
            var article = store[userInput];
            ShowProductFoundMessage();
            PrintArticle(article);
        }
        
        private static void FindProductById(Store store)
        {
            Console.WriteLine("Введите номер искомого товара.");
            var userInput = Console.ReadLine();
            var articleNumber = Convert.ToInt32(userInput);
            var article = store[articleNumber];
            ShowProductFoundMessage();
            PrintArticle(article);
        }
        
        private static void PrintArticle(Article article)
        {
            if (article != null)
            {
                article.Print();
            }
            else
            {
                ShowProductIsAbsentMessage();
            }
        }
        
        private static void ShowProductFoundMessage()
        {
            Console.WriteLine("\nНайден товар:");
        }
        private static void ShowProductIsAbsentMessage()
        {
            Console.WriteLine("\nИскомого товара нет в наличии.");
        }
    }
    
   

    internal class Article
    {
        private string _productName;
        private string _storeName;
        private float _price;


        public string ProductName
        {
            get => _productName;
            private set => _productName = value;
        }
        
        public string StoreName
        {
            get => _storeName;
            set => _storeName = value;
        }
        
        public float Price
        {
            get => _price;
            set => _price = value;
        }

        public Article(string productName, string storeName, float price)
        {
            _productName = productName;
            _storeName = storeName;
            _price = price;
        }

        internal void Print()
        {
            Console.WriteLine($"Наименование: {_productName}, цена: {_price}.");
        }
    }
    
    internal class Store
    {

        private Article[] _articles;

        private Article[] Articles
        {
            get => _articles;
            set => _articles = value;
        }


        internal Store(Article[] articles)
        {
            _articles = articles;
        }


        internal Article this[int index]
        {
            get
            {
                if (index >= 0 && index < _articles.Length)
                {
                    return _articles [index];
                }
                return null;
            }
            set => _articles[index] = value;
        }

        internal Article this[string articleName]
        {
            get
            {
                Article result = null;
                
                foreach (var article in _articles)
                {
                    if (article.ProductName == articleName) result = article;
                }

                return result;
            }
        }
    }
}