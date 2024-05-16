using System;

namespace L17Task2
{
    /*
    Задание 3
    Cоздайте проект по шаблону Console Application
    Используя динамические и анонимные типы данных, создайте Англо-Русский словарь на 10 слов и
    выведите на экран его содержание.                 
    */
    internal class Program
    {
        public static void Main(string[] args)
        {
            dynamic[] englishWords =
            {
                new { Val = "amount" },
                new { Val = "argument" },
                new { Val = "be" },
                new { Val = "cause" },
                new { Val = "certain" },
                new { Val = "chance" },
                new { Val = "clear" },
                new { Val = "common" },
                new { Val = "comparison" },
                new { Val = "copy" }
            };
        
            dynamic[] russianWords =
            {
                new { Val = "количество" },
                new { Val = "аргумент" },
                new { Val = "быть" },
                new { Val = "причина" },
                new { Val = "определенный" },
                new { Val = "шанс" },
                new { Val = "очищать" },
                new { Val = "общий" },
                new { Val = "сравнение" },
                new { Val = "копировать" }
            };

            for (int i = 0; i < englishWords.Length; i++)
            {
                var engWord = englishWords[i];
                var rusWord = russianWords[i];

                Console.WriteLine($"{engWord} - {rusWord}");
            }
        }
    }
}