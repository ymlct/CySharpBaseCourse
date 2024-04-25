using System;

namespace L9Task2
{
    /*
    Задание 3
    Cоздайте проект по шаблону Console Application.
    - Создайте анонимный метод, который принимает в качестве аргумента массив делегатов и возвращает
      среднее арифметическое возвращаемых значений методов сообщенных с делегатами в массиве.
    - Методы, сообщенные с делегатами из массива, возвращают случайное значение типа double.
     */
    internal class Program
    {

        private delegate double Random();

        private delegate double Fold(Random[] randoms);
        
        public static void Main(string[] args)
        {
            Random[] randomGens =
            {
                () => 1,
                () => 2,
                () => 3,
                () => 4
            };
            
            Fold fold = rndGens =>
            {
                double acc = 0;
                
                for (var i = 0; i < rndGens.Length; i++)
                {
                    acc += rndGens[i].Invoke();
                }
                
                return acc / rndGens.Length;
            };

            var result = fold.Invoke(randomGens);
            
            Console.WriteLine(result);
        }
    }
}