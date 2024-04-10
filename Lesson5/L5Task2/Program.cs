using System;

namespace L5Task2
{
    /*
    Задание 3
    Cоздайте проект по шаблону Console Application.
    Требуется:
    - Создать класс MyMatrix, обеспечивающий представление матрицы произвольного размера
      с возможностью изменения числа строк и столбцов.
    - Написать программу, которая выводит на экран матрицу и производные от нее матрицы разных порядков.
     */
    internal class Program
    {
        private static MyMatrix _matrix = null;
        
        public static void Main(string[] args)
        {
            
            
            bool shouldExitProgram = false;
            while (!shouldExitProgram)
            {
                if (_matrix == null)
                {
                    _matrix = CreateMatrix(ref shouldExitProgram);
                    
                    PrintSeparator();
                    Console.WriteLine("Матрица создана.");
                    _matrix.Print();
                    PrintSeparator();

                }
                else
                {
                    try
                    {
                        Console.WriteLine("Для изменения рамеров матрицы введите '1', для печати производной матрицы введите '2'. Для выхода введите значение '<= 0'");
                        var input = Convert.ToInt32(Console.ReadLine());
                        
                        if (input <= 0) break;

                        switch (input)
                        {
                            case 1:
                                EditMatrix(_matrix, ref shouldExitProgram);
                                break;
                            
                            case 2:
                                PrintDerivedMatrix(_matrix, ref shouldExitProgram);
                                break;
                        }
                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Введенное значение не может быть конвертировано в целое число. Попробуйте еще раз.");
                    }
                }
            }

            Console.WriteLine("Работа завершена.");

        }

        private static void PrintSeparator()
        {
            Console.WriteLine("\n");
            Console.WriteLine(new String('*', _matrix.Columns));
            Console.WriteLine("\n");
        }

        private static MyMatrix CreateMatrix(ref bool shouldExitProgram)
        {
            MyMatrix matrix = null;
            while (!shouldExitProgram)
            {
                var rows = ReadInputForRows(ref shouldExitProgram);
                if (shouldExitProgram) continue;
                    
                var columns = ReadInputForColumns(ref shouldExitProgram);
                if (shouldExitProgram) continue;
                 
                matrix = new MyMatrix(rows, columns);
                break;
            }

            return matrix;
        }

        public static void EditMatrix(MyMatrix matrix, ref bool shouldExitProgram) {
            var rows = ReadInputForRows(ref shouldExitProgram);
            if (shouldExitProgram) return;
                    
            var columns = ReadInputForColumns(ref shouldExitProgram);
            if (shouldExitProgram) return;

            matrix.Rows = rows;
            matrix.Columns = columns;
        }
        
        public static void PrintDerivedMatrix(MyMatrix matrix, ref bool shouldExitProgram) {
            var rows = ReadInputForRows(ref shouldExitProgram);
            if (shouldExitProgram) return;
                    
            var columns = ReadInputForColumns(ref shouldExitProgram);
            if (shouldExitProgram) return;

            matrix.Print(rows, columns);
        }

        private static int ReadInputForRows(ref bool shouldExitProgram)
        {
            Console.WriteLine("Введите количество строк в матрице. Для выхода введите значение '<= 0'");
            var rows = Convert.ToInt32(Console.ReadLine());
            if (rows <= 0)
            {
                shouldExitProgram = true;
            }

            return rows;
        }
        
        private static int ReadInputForColumns(ref bool shouldExitProgram)
        {
            Console.WriteLine("Введите количество столбцов в матрице. Для выхода введите значение '<= 0'");
            var columns = Convert.ToInt32(Console.ReadLine());
            if (columns <= 0)
            {
                shouldExitProgram = true;
            }

            return columns;
        }

        internal class MyMatrix
        {
            private int _rows, _columns;
            private int[,] _matrix;

            internal int Rows
            {
                get => _rows;
                set
                {
                    _rows = value;
                    RebuildMatrix();
                }
            }
            
            internal int Columns
            {
                get => _columns;
                set
                {
                    _columns = value;
                    RebuildMatrix();
                }
            }

            public MyMatrix(int rows, int columns)
            {
                _rows = rows;
                _columns = columns;
                _matrix = new int[_rows, _columns];

                FillMatrix(_matrix);
            }

            private void RebuildMatrix()
            {
                _matrix = new int[_rows, _columns];
            }
            
            private void FillMatrix(int[,] matrix)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = i * j;
                    }
                }
            }
            
            internal void Print(int upToRow = 0, int upToColumn = 0)
            {
                var rowsCount = _matrix.GetLength(0);
                var columnsCount = _matrix.GetLength(1);

                int min = -1;
                int max = 1;

                IterateMatrix(
                    matrix: _matrix,
                    onNext: (i, j, next) =>
                    {
                        if (next < min) { min = next; }
                        if (next > max) { max = next; }
                    }
                    );

                var minLength = $"{min}".Length;
                var maxLength = $"{max}".Length;
                var lengthToUse = maxLength >= minLength ? maxLength : minLength;
                var format = "{0:d" + $"{lengthToUse}" + "}";

                var maxRow = (upToRow != 0 && upToRow < rowsCount) ? upToRow : rowsCount;
                var maxColumn = (upToColumn != 0 && upToColumn < columnsCount) ? upToColumn : columnsCount;
                
                IterateMatrix(
                    matrix: _matrix,
                    onNext: (i, j, next) =>
                    {
                        if (i < maxRow && j < maxColumn)
                        {
                            Console.Write(format, next);
                            if (j == maxColumn - 1) Console.Write("\n");
                            else Console.Write(" ");   
                        }
                    }
                );
            }
            
            private void IterateMatrix(int[,] matrix, Action<int,int,int> onNext)
            {
                var rowsCount = matrix.GetLength(0);
                var columnsCount = matrix.GetLength(1);
     
                for (int i = 0; i < rowsCount; i++)
                {
                    for (int j = 0; j < columnsCount; j++)
                    {
                        onNext(i, j, matrix[i, j]);
                    }
                }
            }
            
        }
    }
}