using System;

namespace L16Task1
{
    /*
    Задание 2
    Создайте класс Block с 4-мя полями сторон, переопределите в нем методы:
    Equals – способный сравнивать блоки между собой,
    ToString – возвращающий информацию о полях блока.            
    */
    internal class Program
    {
        public static void Main(string[] args)
        {
            Point p1 = new Point(1 ,1);
            Point p2 = new Point(2, 1);
            
            Point p3 = new Point(2, 2);
            Point p4 = new Point(1, 2);
            
            Point p5 = new Point(3, 3);
            Point p6 = new Point(1, 3);
            
            Block b1 = new Block(p1, p2, p3, p4);
            Block b2 = new Block(p1, p2, p3, p4);
            Block b3 = new Block(p1, p2, p5, p6);
            
            Console.WriteLine($"b1 == b2 : {b1.Equals(b2)}");
            Console.WriteLine($"b1 == b3 : {b1.Equals(b3)}");
            Console.WriteLine($"b2 == b3 : {b2.Equals(b3)}");
            
            Console.WriteLine($"{b1}");
        }
    }

    internal class Block
    {
        public readonly Line Ab;
        public readonly Line Bc;
        public readonly Line Cd;
        public readonly Line Da;

        public Block(Point a, Point b, Point c, Point d)
        {
            Ab = new Line(a, b);
            Bc = new Line(b, c);
            Cd = new Line(c, d);
            Da = new Line(d, a);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) { return false; }
            
            Block b = (Block) obj;
            
            return b.Ab.Equals(Ab) && b.Bc.Equals(Bc) && b.Cd.Equals(Cd) && b.Da.Equals(Da);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = 37; 
                result *= 397;
                
                result += Ab.GetHashCode();
                result *= 397;
                
                result += Bc.GetHashCode();
                result *= 397;
                
                result += Cd.GetHashCode();
                result *= 397;
                
                result += Da.GetHashCode();
                result *= 397;
                
                return result;
            }
        }

        public override string ToString()
        {
            return $"Стороны: AB: {Ab}, BC: {Bc}, CD: {Cd}, DA: {Da}";
        }
    }
    
    internal class Line
    {
        
        public readonly Point A;
        public readonly Point B;

        public Line(Point a, Point b)
        {
            A = a;
            B = b;
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) { return false; }
            
            Line l = (Line) obj;
            
            return l.A.Equals(A) && l.B.Equals(B);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = 37; 
                result *= 397;
                
                result += A.GetHashCode();
                result *= 397;
                
                result += B.GetHashCode();
                result *= 397;
                
                return result;
            }
        }
        
        public override string ToString()
        {
            return $"({A}), ({B})";
        }
    }
    
    internal class Point
    {
        
        public readonly double X;
        public readonly double Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) { return false; }
            
            Point p = (Point) obj;
            
            return p.X == X && p.Y == Y;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = 37; 
                result *= 397;
                
                result += X.GetHashCode();
                result *= 397;
                
                result += Y.GetHashCode();
                result *= 397;
                
                return result;
            }
        }
        
        public override string ToString()
        {
            return $"{X},{Y}";
        }
    }
}