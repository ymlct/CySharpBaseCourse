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
    }
    
    internal class Store
    {

        private Article[] _articles;

        private Article[] Articles
        {
            get => _articles;
            set => _articles = value;
        }


        public Store(Article[] articles)
        {
            _articles = articles;
        }


        private Article this[int index]
        {
            get => _articles[index];
            set => _articles[index] = value;
        }
        
        private Article this[string articleName]
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