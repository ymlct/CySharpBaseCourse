using System;

namespace Task1
{
    /*
     Задание 4
     Создайте проект по шаблону Console Application.
     Требуется: Создать расширяющий метод для целочисленного массива, который сортирует элементы массива по возрастанию.
     */
    public class L6Task3
    {
        internal void Execute()
        {
            // int[] arr = { 5, 2, 6, 0, -1, 1, 3, 4 };
            int[] arr = new int[6];
            arr[3] = 4;
            arr[5] = -1;
            
            arr.Print();
            arr.Sort();
            arr.Print();
        }
    }
    
    internal static class ArraySortExtension
    {
        internal static void Sort(this int[] target)
        {
            
            var curValIdx = 0;
            var bufferedVal = 0;
            var nextVal = 0;

            while (curValIdx < target.Length)
            {
                bufferedVal = target[curValIdx];
                
                for (int i = curValIdx + 1; i < target.Length; i++)
                {
                    nextVal = target[i];
                    
                    if (bufferedVal > nextVal)
                    {
                        target[curValIdx] = nextVal;
                        target[i] = bufferedVal;
                        bufferedVal = nextVal;
                    }
                }
                curValIdx++;
            }
        }

        internal static void Print(this int[] target)
        {
            foreach (var i in target)
            {
                Console.Write($"{i}, ");
            }
            Console.Write("\n");
        }
    }
}