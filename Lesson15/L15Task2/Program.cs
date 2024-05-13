using System;

namespace L15Task2
{
    /*
    Задание 3
    Используя Visual Studio, создайте проект по шаблону Console Application.
    Требуется: 
    - Описать структуру с именем Price, содержащую следующие поля:
        • название товара;
        • название магазина, в котором продается товар;
        • стоимость товара в рублях.
    - Написать программу, выполняющую следующие действия:
        • ввод с клавиатуры данных в массив, состоящий из двух элементов типа Price (записи должны
          быть упорядочены в алфавитном порядке по названиям магазинов);
        • вывод на экран информации о товарах, продающихся в магазине, название которого введено с
          клавиатуры (если такого магазина нет, вывести исключение).                         
    */
    internal class Program
    {
        public static void Main(string[] args)
        {

            Catalog catalog = new Catalog(4);
            
            catalog.AddProduct("P1", "S1", 100);
            catalog.AddProduct("P2", "S1", 200);
            catalog.AddProduct("P3", "S1", 300);
            catalog.AddProduct("P4", "S2", 400);

            var prices = catalog.GetProductsByStoreName("S1");
            // var prices = catalog.GetProductsByStoreName("S2");
            // var prices = catalog.GetProductsByStoreName("S3");
            
            foreach (var price in prices)
            {
                Console.WriteLine(price.ToString());
            }
        }
    }
}