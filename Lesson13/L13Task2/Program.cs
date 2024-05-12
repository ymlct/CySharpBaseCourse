using System;
using System.Threading;

namespace L13Task2
{
    
    /*
    Задание 2
    Создайте проект по шаблону Console Application.
    Расширьте задание 2, так, чтобы в одном столбце одновременно могло быть две цепочки символов.
    Смотрите ниже снимок экрана, представленный как образец.            
    */
    internal class Program
    {
        private static readonly int _matrixSize = 30;
        private static readonly int _charChainLength = 16;
        private static readonly int _matrixTopLeftOffset = 3;
        private static readonly int _matrixPadding = 2; 
        private static readonly ConsoleColor _backgroundColor = ConsoleColor.Black; 
        
        public static void Main(string[] args)
        {
            PrepareMatrixBackground();
            
            for (int i = 0; i < 2; i++) // количество потоков
            {
                var matrixColumn = new MatrixColumn(i * i, _matrixSize, _charChainLength, _matrixTopLeftOffset);
                new Thread(matrixColumn.PrintChainInfinitely).Start();
            }
        }

        private static void PrepareMatrixBackground()
        {
            Console.BackgroundColor = _backgroundColor;
            
            Console.CursorTop = _matrixTopLeftOffset - _matrixPadding;
            
            for (int i = 0; i < _matrixSize + _matrixPadding * 2; i++)
            {
                Console.CursorLeft = _matrixTopLeftOffset - _matrixPadding;
                for (int j = 0; j < _matrixSize * 2 + _matrixPadding * 2; j++)
                {
                    Console.Write(" ");
                }
                Console.Write("\n");
            }
        }
    }
}