using System;
using System.Threading;

namespace L13Task1
{
    public class MatrixColumn
    {
        private static readonly object block = new object();

        private Random _random;
        
        private int _matrixSize;
        private int _charChainMaxLength;
        private int _columnTopLeftOffset;

        private readonly char[] _chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public MatrixColumn(
            int columnIdx, 
            int matrixSize, 
            int charChainMaxLength, 
            int columnTopLeftOffset
            )
        {
            _matrixSize = matrixSize;
            _charChainMaxLength = charChainMaxLength;
            _columnTopLeftOffset = columnTopLeftOffset;
            _random = new Random(Seed: columnIdx);
        }

        public void PrintChainInfinitely()
        {
            while (true)
            {
                Thread.Sleep(_random.Next(10, 3000));

                int charChainCurrentLength = _random.Next(_charChainMaxLength / 2, _charChainMaxLength);
                int currentColumnIdx = _random.Next(0, _matrixSize) * 2;
                int speed = _random.Next(50, 150);
                int charChainHeadPosition = 0;

                // lock (block) // для 2х потоков можно не использовать
                {
                    while (charChainHeadPosition <= _matrixSize + charChainCurrentLength)
                    {
                        for (int i = 0; i < _matrixSize; i++)
                        {
                            Console.CursorLeft = currentColumnIdx + _columnTopLeftOffset;
                            Console.CursorTop = _columnTopLeftOffset + i;

                            int charChainEffectiveLength;

                            // цепочка появляется сверху и еще не достигла полной длины
                            if (charChainHeadPosition < charChainCurrentLength)
                            {
                                charChainEffectiveLength = charChainHeadPosition;
                                PrintSymbolByValueOfI(i, charChainHeadPosition, charChainEffectiveLength);
                            }
                            
                            // цепочка скрывается внизу и ее длина начинает уменьшатся
                            else if (charChainHeadPosition > _matrixSize)
                            {
                                charChainEffectiveLength =  charChainCurrentLength - (charChainHeadPosition - _matrixSize);
                                PrintSymbolByValueOfI(i, charChainHeadPosition, charChainEffectiveLength);
                            }
                            
                            // цепочка полной длины движется сверху вниз
                            else
                            {
                                charChainEffectiveLength = charChainCurrentLength;
                                PrintSymbolByValueOfI(i, charChainHeadPosition, charChainEffectiveLength);
                            }
                        }
                        
                        charChainHeadPosition++;
                        
                        // скорость движения цепочки
                        Thread.Sleep(speed);
                    }
                }
            }
        }
        
        
        private void PrintSymbolByValueOfI(int i, int charChainHeadPosition, int charChainEffectiveLength)
        {
            if (i == charChainHeadPosition) { PrintFirst(); }
            else if (i == charChainHeadPosition - 1) { PrintSecond(); } 
            else if (i <= charChainHeadPosition - 2 && i > charChainHeadPosition - charChainEffectiveLength) { PrintOther(); } 
            else { PrintVoid(); } 
        }

        private void PrintFirst()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(GetChar());
        }
        
        private void PrintSecond()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            // Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(GetChar());
        }
        
        private void PrintOther()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            // Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(GetChar());
        }
        
        private void PrintVoid()
        {
            Console.Write(" ");
        }
        
        private char GetChar() => _chars[_random.Next(0, _chars.Length - 1)];

    }
}