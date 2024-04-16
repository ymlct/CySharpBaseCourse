using System;

namespace Task1
{
    
    /*
    Урок 1, Задание 2
    Cоздайте проект по шаблону Console Application.
    Требуется: 
    - Создать класс с именем Rectangle.
    - В теле класса создать два поля, описывающие длины сторон double side1, side2.
    - Создать пользовательский конструктор Rectangle(double side1, double side2), в теле которого поля side1 и side2 
      инициализируются значениями аргументов.
    - Создать два метода, вычисляющие площадь прямоугольника - double AreaCalculator() и периметр прямоугольника - 
      double PerimeterCalculator().
    - Создать два свойства double Area и double Perimeter с одним методом доступа get.
    - Написать программу, которая принимает от пользователя длины двух сторон прямоугольника и выводит на экран 
      периметр и площадь.
     */
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите длину стороны 1");
            var side1AsString = Console.ReadLine();
            var side1 = Convert.ToDouble(side1AsString);
            
            Console.WriteLine("Введите длину стороны 2");
            var side2AsString = Console.ReadLine();
            var side2 = Convert.ToDouble(side2AsString);
            
            var rect = new Rectangle(side1: side1, side2: side2);
            
            var rectArea = rect.AreaCalculator();
            var rectPerimeter = rect.PerimeterCalculator();
            
            Console.WriteLine($"Площадь прямоугольника: {rectArea} ед.кв., периметр прямоугольника: {rectPerimeter} ед.");
        }
    }

    internal class Rectangle
    {
        private double _side1, _side2;

        public double Side1
        {
            get => _side1;
        }
        
        public double Side2  
        {
            get => _side2;
        }

        public Rectangle(double side1, double side2)
        {
            _side1 = side1;
            _side2 = side2;
        }

        public double AreaCalculator()
        {
            return Side1 * Side2;
        }
        
        public double PerimeterCalculator()
        {
           return Side1 * 2 + Side2 * 2;
        }

    }
}