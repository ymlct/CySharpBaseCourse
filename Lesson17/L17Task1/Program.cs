using System;
using System.Linq;

namespace L17Task1
{
    /*
    Задание 2
    Создайте проект по шаблону Console Application
    Представьте, что вы пишите приложение для Автостанции и вам необходимо создать простую
    коллекцию автомобилей со следующими данными: Марка автомобиля, модель, год выпуска, цвет. А
    также вторую коллекцию с моделью автомобиля, именем покупателя и его номером телефона.
    Используя простейший LINQ запрос, выведите на экран информацию о покупателе одного из
    автомобилей и полную характеристику приобретенной ними модели.
    */
    internal class Program
    {
        public static void Main(string[] args)
        {

            Car[] cars =
            {
                new Car(manufacturer: "Производитель 1", model: "Модель 1", year: 2019, color: "Цвет 1"),
                new Car(manufacturer: "Производитель 2", model: "Модель 2", year: 2020, color: "Цвет 2"),
                new Car(manufacturer: "Производитель 3", model: "Модель 3", year: 2021, color: "Цвет 3")
            
            };

            CarOwner[] owners =
            {
                new CarOwner("Собственник 1", "123", "Модель 1"),
                new CarOwner("Собственник 2", "456", "Модель 2"),
                new CarOwner("Собственник 3", "789", "Модель 3")
            };

            var query =
                from owner in owners
                join car in cars
                    on owner.CarModel equals car.Model
                where owner.PhoneNumber == "123" || owner.PhoneNumber == "456"
                select new
                {
                    OwnerName = owner.Name,
                    OwnerPhoneNumber = owner.PhoneNumber,
                    Manufacturer = car.Manufacturer,
                    Model = car.Model,
                    Year = car.Year,
                    Color = car.Color
                };
            
            foreach (var o in query)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", 
                    o.OwnerName,
                    o.OwnerPhoneNumber,
                    o.Manufacturer,
                    o.Model,
                    o.Year,
                    o.Color
                    );
            }
        }
    }

    internal class Car
    {
        public readonly string Manufacturer;
    
        public readonly string Model;
    
        public readonly int Year;
    
        public readonly string Color;

        public Car(string manufacturer, string model, int year, string color)
        {
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
            Color = color;
        }
    }

    internal class CarOwner
    {
        public readonly string Name;
        public string PhoneNumber { get; set; }
        public string CarModel { get; set; }

        public CarOwner(string name, string phoneNumber, string carModel)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            CarModel = carModel;
        }
    }
}