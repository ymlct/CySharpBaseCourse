using System;

namespace L1Task3
{
    /*
    Урок 1, Задание 4
    Cоздайте проект по шаблону Console Application.
    Требуется:
    - Создать классы Point и Figure. Класс Point должен содержать два целочисленных поля и одно строковое поле.
    - Создать три свойства с одним методом доступа get.
    - Создать пользовательский конструктор, в теле которого проинициализируйте поля значениями аргументов. 
    - Класс Figure должен содержать конструкторы, которые принимают от 3-х до 5-ти аргументов типа Point.
    - Создать два метода: double LengthSide(Point A, Point B), который рассчитывает длину стороны многоугольника; 
      void PerimeterCalculator(), который рассчитывает периметр многоугольника.
    - Написать программу, которая выводит на экран название и периметр многоугольника
     */
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            var point1 = new Point(x: 2, y: 1, name: "т1");
            var point2 = new Point(x: 4, y: 1, name: "т2");
            var point3 = new Point(x: 5, y: 3, name: "т3");
            var point4 = new Point(x: 3, y: 5, name: "т4");
            var point5 = new Point(x: 1, y: 5, name: "т5");
            
            var figure1 = new Figure(point1, point2, point3);
            var figure2 = new Figure(point1, point2, point3, point4);
            var figure3 = new Figure(point1, point2, point3, point4, point5);
            
            Console.WriteLine($"Многоугольник по точкам {point1.Name}, {point2.Name}, {point3.Name}, с периметром {figure1.PerimeterCalculator()}.");
            Console.WriteLine($"Многоугольник по точкам {point1.Name}, {point2.Name}, {point3.Name}, {point4.Name}, с периметром {figure2.PerimeterCalculator()}.");
            Console.WriteLine($"Многоугольник по точкам {point1.Name}, {point2.Name}, {point3.Name}, {point4.Name}, {point5.Name}, с периметром {figure3.PerimeterCalculator()}.");

        }
    }

    internal class Point
    {

        private int _x, _y;
        private string _name;

        public int X { get => _x; }
        
        public int Y { get => _y; }
        
        public string Name { get => _name; }

        public Point(int x, int y, string name)
        {
            _x = x;
            _y = y;
            _name = name;
        }
    }
    
    internal class Figure
    {

        private Point _point1;
        private Point _point2;
        private Point _point3;
        private Point _point4;
        private Point _point5;

        public Figure(Point point1, Point point2, Point point3)
        {
            _point1 = point1;
            _point2 = point2;
            _point3 = point3;
        }
        
        public Figure(Point point1, Point point2, Point point3, Point point4) : this(point1, point2, point3)
        {
            _point4 = point4;
        }
        
        public Figure(Point point1, Point point2, Point point3, Point point4, Point point5) : this(point1, point2, point3, point4)
        {
            _point5 = point5;
        }

        public double LengthSide(Point a, Point b)
        {
            var triangleLegByX = a.X - b.X;
            var triangleLegByY = a.Y - b.Y;

            double result = Math.Sqrt(triangleLegByX * triangleLegByX + triangleLegByY * triangleLegByY);

            return result;
        }
        
        public double PerimeterCalculator()
        {
            var side1Length = LengthSide(a: _point1, b: _point2);
            var side2Length = LengthSide(a: _point2, b: _point3);
            var side3Length = 0d;
            var side4Length = 0d;
            var side5Length = 0d;
            
            double result = 0d;

            if (_point4 == null && _point5 == null)
            {
                side3Length = LengthSide(a: _point3, b: _point1);
            } 
            else
            {
                side3Length = LengthSide(a: _point3, b: _point4);

                if (_point5 == null)
                {
                    side4Length = LengthSide(a: _point4, b: _point1);
                }
                else
                {
                    side4Length = LengthSide(a: _point4, b: _point5);
                    side5Length = LengthSide(a: _point5, b: _point1);  
                    
                    result += side5Length;
                }

                result += side4Length;
            }
            
            result += side1Length + side2Length + side3Length;
            
            return result;
        }
    }
}