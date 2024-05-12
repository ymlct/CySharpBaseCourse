using System;
using System.Threading;

namespace L13Task2
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

                // длины первой и второй цепочек
                int charChain1ActualLength = _random.Next(_charChainMaxLength / 4, _charChainMaxLength / 2);
                int charChain2ActualLength = _random.Next(_charChainMaxLength / 4, _charChainMaxLength - charChain1ActualLength);
                int charChainsOverallLength = charChain1ActualLength + charChain2ActualLength;
                
                // индекс колонки, в которой отображается символ
                int currentColumnIdx = _random.Next(0, _matrixSize) * 2;
                
                int speed = _random.Next(50, 150);
                
                // позиция первого по ходу движения (нижнего) символа в цепочке
                int charChain1HeadPosition = 0;
                int charChain2HeadPosition = -charChain1ActualLength;
                
                int charChain1EffectiveLength = 0;
                int charChain2EffectiveLength = 0;

                lock (block) 
                {
                    // пока вся цепочка не выйдет за пределы матрицы 
                    while (charChain1HeadPosition <= _matrixSize + charChainsOverallLength)
                    {
                        for (int i = 0; i < _matrixSize; i++)
                        {
                            Console.CursorLeft = currentColumnIdx + _columnTopLeftOffset;
                            Console.CursorTop = _columnTopLeftOffset + i;

                            // цепочка появляется сверху и еще не достигла полной длины
                            if (charChain1HeadPosition < charChainsOverallLength)
                            {
                                charChain1EffectiveLength = charChain1HeadPosition > charChain1ActualLength ? charChain1ActualLength : charChain1HeadPosition;
                                charChain2EffectiveLength = charChain2HeadPosition > 0 ? charChain2HeadPosition : 0;
                                PrintSymbolByValueOfI(
                                    i,
                                    charChain1HeadPosition,
                                    charChain1EffectiveLength,
                                    charChain2HeadPosition,
                                    charChain2EffectiveLength
                                    );
                            }
                            
                            // цепочка скрывается внизу и ее длина начинает уменьшаться
                            else if (charChain1HeadPosition > _matrixSize)
                            {
                                charChain1EffectiveLength =  charChain1ActualLength - (charChain1HeadPosition - _matrixSize);
                                if (charChain1EffectiveLength < 0) { charChain1EffectiveLength = 0; }
                                
                                charChain2EffectiveLength = charChain2HeadPosition > _matrixSize ? charChain2ActualLength - (charChain2HeadPosition - _matrixSize) : charChain2ActualLength;
                                
                                PrintSymbolByValueOfI(
                                    i,
                                    charChain1HeadPosition,
                                    charChain1EffectiveLength,
                                    charChain2HeadPosition,
                                    charChain2EffectiveLength
                                );
                            }
                            
                            // цепочка полной длины движется сверху вниз
                            else
                            {
                                charChain1EffectiveLength = charChain1ActualLength;
                                charChain2EffectiveLength = charChain2ActualLength;
                                
                                PrintSymbolByValueOfI(
                                    i,
                                    charChain1HeadPosition,
                                    charChain1EffectiveLength,
                                    charChain2HeadPosition,
                                    charChain2EffectiveLength
                                );
                            }
                        }
                        
                        charChain1HeadPosition++;
                        charChain2HeadPosition++;
                        
                        // скорость движения цепочки
                        Thread.Sleep(speed);
                    }
                }
            }
        }
        
        
        private void PrintSymbolByValueOfI(
            int i, 
            int charChain1HeadPosition,
            int charChain1EffectiveLength,
            int charChain2HeadPosition,
            int charChain2EffectiveLength
            )
        {
            if (i == charChain1HeadPosition || i == charChain2HeadPosition) { PrintFirst(); }
            else if (i == charChain1HeadPosition - 1 || i == charChain2HeadPosition - 1) { PrintSecond(); } 
            else if (
                charChain1EffectiveLength > 0 && i <= charChain1HeadPosition - 2 && i > charChain1HeadPosition - charChain1EffectiveLength ||
                i <= charChain2HeadPosition - 2 && i > charChain2HeadPosition - charChain2EffectiveLength
                ) { PrintOther(); } 
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