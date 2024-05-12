using System;
using System.Threading;

namespace L13Task1
{
    /*
    Задание 1
    Создайте проект по шаблону Console Application.
    Создайте программу, которая будет выводить на экран цепочки падающих символов. Длина каждой
    цепочки задается случайно. Первый символ цепочки – белый, второй символ – светло-зеленый,
    остальные символы темно-зеленые. Во время падения цепочки, на каждом шаге, все символы меняют
    свое значение. Дойдя до конца, цепочка исчезает и сверху формируется новая цепочка. 
    */
    internal class Program
    {

        private static readonly int _matrixSize = 20;
        private static readonly int _charChainLength = 6;
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