using System;

namespace L11Task1
{
    /*
    Задание 2
    Создайте проект по шаблону Console Application.
     - Создайте класс CarCollection<T>. Реализуйте в простейшем приближении возможность
       использования его экземпляра для создания парка машин. 
     - Минимально требуемый интерфейс взаимодействия с экземпляром, должен включать
        - метод добавления машин с названием машины и года ее выпуска, 
        - индексатор для получения значения элемента по указанному индексу и 
        - свойство только для чтения для получения общего количества элементов.
    Создайте метод удаления всех машин автопарка.
     */
    internal class Program
    {
        public static void Main(string[] args)
        {
            var corolla = new Toyota("Corolla", 2019);
            var avensis = new Toyota("Avensis", 2020);
            var camry = new Toyota("Camry", 2021);
            var avalon = new Toyota("Avalon", 2022);
            var crown = new Toyota("Crown", 2023);

            var toyotaCollection = new CarCollection<Toyota>();
            
            toyotaCollection.AddCar(corolla);
            toyotaCollection.AddCar(avensis);
            toyotaCollection.AddCar(camry);
            
            Console.WriteLine(toyotaCollection[0].GetInfo());
            Console.WriteLine(toyotaCollection.Count);
            toyotaCollection.DeleteAllCars();
            
            toyotaCollection.AddCar(avalon);
            toyotaCollection.AddCar(crown);
            Console.WriteLine(toyotaCollection[0].GetInfo());
            Console.WriteLine(toyotaCollection.Count);
        }
    }
    
    internal abstract class Car
    {
        internal string ModelName { get; private set; }

        internal int ProductionYear { get; private set; }
        
        internal Car(string modelName, int productionYear)
        {
            ModelName = modelName;
            ProductionYear = productionYear;
        }

        internal string GetInfo()
        {
            return $"Модель: {ModelName}, год выпуска: {ProductionYear}";
        }
    }

    internal class Toyota : Car
    {
        public Toyota(
            string modelName, 
            int productionYear
            ) : base(modelName, productionYear)
        { }
    }

    internal class CarCollection<T> where T : Car
    {

        private T[] _cars;
        
        internal int Count { get; private set; }
        

        private const int InitialCapacity = 5;

        internal CarCollection()
        {
            _cars = new T[InitialCapacity];
        }

        internal void AddCar(T car)
        {
            if (Count == _cars.Length)
            {
                var newArr = IncreaseCapacity(source: _cars, newCapacity: _cars.Length * 2);
                _cars = newArr;
            }
            _cars[Count] = car;
            Count++;
        }
        
        internal T this[int index] {
            get
            {
                if (index >= 0 && index <= Count) return _cars[index];
                else return null;
            }
        }
        
        internal void DeleteAllCars()
        {
            for (var i = 0; i < _cars.Length; i++)
            {
                _cars[i] = null;
            }
            Count = 0;
        }

        private T[] IncreaseCapacity(T[] source, int newCapacity)
        {
            T[] destination = new T[newCapacity];
            Array.Copy(source, destination, newCapacity);
            return destination;
        }
    }
}