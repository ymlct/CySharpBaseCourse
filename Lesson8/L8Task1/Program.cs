using System;

namespace L8Task1
{
    /*
    Задание 2
    Создайте проект по шаблону Console Application.
    - Создайте статический класс с методом void Print (string stroka, int color), который выводит на
      экран строку заданным цветом. Используя перечисление, создайте набор цветов, доступных
      пользователю. 
    - Ввод строки и выбор цвета предоставьте пользователю.
     */
    internal class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Цвета, доступные для выбора:");
            var colors = Enum.GetValues(typeof(Colors));
            foreach (var color in colors)
            {
                Console.WriteLine($"{color} ({(int) color})");
            }
           
            Console.WriteLine("Введите строку");
            var inputString = Console.ReadLine();
            
            Console.WriteLine("Введите код цвета");
            var colorCode = Console.ReadLine();

            Int32.TryParse(colorCode, out int colorIntCode);

            if (colorIntCode == 0)
            {
                Console.WriteLine("Введены неверные данные.");
                return;
            }

            StringPrinter.Print(inputString, colorIntCode);
        }
    }

    internal static class StringPrinter
    {
        internal static void Print(string stroka, int color)
        {
            var name = Enum.GetName(typeof(Colors), color);

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine($"Цвет с кодом {color} не найден.");
                return;
            }
            
            var consoleColor = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), name);
            
            Console.BackgroundColor = consoleColor;
            Console.WriteLine(stroka);
        }
    }

    internal enum Colors
    {
        Blue = 9,
        Green = 10,
        Red = 12,
        Yellow = 13,
        White = 14
    }
}