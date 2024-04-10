using System;

namespace L5Task1
{
    /*
    Задание 2
    Создайте проект по шаблону Console Application.
    Требуется:
    - Создать массив размерностью N элементов, заполнить его произвольными целыми значениями. 
    - Вывести наибольшее значение массива, наименьшее значение массива, общую сумму элементов, 
      среднее арифметическое всех элементов, вывести все нечетные значения.
    */
    internal class Program
    {
        public static void Main(string[] args)
        {

            Solution solution = new Solution();

            solution.Execute();

        }

        private class Solution
        {
            private int[] _ints;
            private Random _randomGen;
 
            private int _max;
            private int _min;
            private int _sum;
            private int _average;
            
            private int[] _oddIndices;
            private int _nextOddIdx;
            
            internal Solution()
            {
                InitMembers();
            }

            internal void Execute()
            {
                Iterate(_ints, SetMax, SetMin, UpdateSum, SaveOddIdx);
                CalcAverage();

                Console.Write("\n");
                PrintAllInts();
                Console.WriteLine($"Максимальное число: {_max}");
                Console.WriteLine($"Минимальное число: {_min}");
                Console.WriteLine($"Сумма: {_sum}");
                Console.WriteLine($"Среднее: {_average}");
                PrintOddInts();
                Console.Write("\n");
            }

            private void InitMembers()
            {
                _randomGen = new Random();
                _ints = new int[_randomGen.Next(5, 10)];
                _max = 0;
                _min = Int32.MaxValue;
                _sum = 0;
                _average = 0;
                _oddIndices = new int[_ints.Length];
                _nextOddIdx = 0;
                
                for (int i = 0; i < _ints.Length; i++)
                {
                    _ints[i] = _randomGen.Next(1, 10);
                }
            }
        
            private void Iterate(
                int[] ints,
                params Action<int, int>[] receivers
                )
            {
                for (var i = 0; i < ints.Length; i++)
                {
                    foreach (var receiver in receivers)
                    {
                        receiver.Invoke(i, ints[i]);
                    }
                }
            }

            private void SetMax(int idx, int next)
            {
                if (_max < next) _max = next;
            }
            
            private void SetMin(int idx, int next)
            {
                if (_min > next) _min = next;
            }
            
            private void UpdateSum(int idx, int next)
            {
                _sum += next;
            }
            
            private void CalcAverage()
            {
                _average = _sum / _ints.Length;
            }
            
            private void SaveOddIdx(int idx, int next)
            {
                if (next == 1 || next % 2 != 0)
                {
                    _oddIndices[_nextOddIdx] = idx;
                    _nextOddIdx++;
                }
            }

            private void PrintAllInts()
            {
                Console.Write("Все числа: ");
                for (int i = 0; i < _ints.Length; i++)
                {
                    Console.Write($"{_ints[i]}");
                    if (i != _ints.Length - 1) Console.Write(", ");
                }
                Console.Write("\n");
            }

            private void PrintOddInts()
            {
                Console.Write("Нечетные числа: ");
               
                for (int i = 0; i < _nextOddIdx; i++)
                {
                    var idx = _oddIndices[i];
                    
                    Console.Write($"{_ints[idx]}");
                    
                    if (i != _nextOddIdx - 1) Console.Write(", ");
                }
            }
            
        }
        
    }
}