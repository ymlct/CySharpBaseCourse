using System;

namespace L16Task2
{
    /*
    Задание 3
    Создайте класс House c двумя полями и свойствами.
    Создайте два метода Clone() и DeepClone(), которые выполняют поверхностное и глубокое
    копирование соответственно. Реализуйте простой способ проверки.           
    */
    internal class Program
    {
        public static void Main(string[] args)
        {

            House house1 = new House(
                new Address("Россия", "Кемерово", "Притомский проспект", "11"),
                15
                );

            House house2 = house1.Clone();
            
            House house3 = house1.DeepClone();

            Console.WriteLine("house1: houseHash={0}, addressHash={1}", house1.GetHashCode(), house1.Address.GetHashCode());
            Console.WriteLine("house2: houseHash={0}, addressHash={1}", house2.GetHashCode(), house2.Address.GetHashCode());
            Console.WriteLine("house3: houseHash={0}, addressHash={1}", house3.GetHashCode(), house3.Address.GetHashCode());
        }
    }

    internal class House
    {
        public Address Address { get; set; }
        
        public int AmountOfFloors { get; set; }
        

        public House(Address address, int amountOfFloors)
        {
            Address = address;
            AmountOfFloors = amountOfFloors;
        }

        // Поверхностное копирование - создание новой ссылки на имеющийся экземпляр.
        public House Clone()
        {
            return this;
        }
        
        // Глубокое копирование - создание нового экземпляра данного класса и новых экземпляров для всех его полей,
        // представленных ссылочным типом.
        public House DeepClone()
        {
            return new House(Address.Clone() as Address, AmountOfFloors);
        }

    }
    
    internal class Address : ICloneable
    {
        public string Country;
        
        public string City;
        
        public string Street;
        
        public string Number;

        public Address(string country, string city, string street, string number)
        {
            Country = country;
            City = city;
            Street = street;
            Number = number;
        }
        
        public object Clone()
        {
            return new Address(country: Country, city: City, street: Street, number: Number);
        }
    }
}