using System;
using System.Collections.Generic;

namespace L14Task3
{
    /*
    Задание 4
    Создайте проект по шаблону Console Application.
    - Создайте расширяющий метод:
      public static T[] GetArray<T>(this IEnumerable<T> list){…}
    - Примените расширяющий метод к экземпляру типа MyList<T>, разработанному в домашнем задании 2
       для данного урока. 
    - Выведите на экран значения элементов массива, который вернул расширяющий метод GetArray().                      
    */
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            MyList<MyListElement> myList = new MyList<MyListElement>();
            
            myList.Add(new MyListElement("A"));
            myList.Add(new MyListElement("B"));
            myList.Add(new MyListElement("C"));

            var array = myList.GetArray();
            
            foreach (var element in array)
            {
                Console.WriteLine($"Элемент {element.Name}");
            }
        }
    }

    internal static class MyListExtension
    {
        internal static T[] GetArray<T>(this IEnumerable<T> list)
        {
            List<T> result = new List<T>();
            
            foreach (var element in list)
            {
                result.Add(element);
            }

            return result.ToArray();
        }
    }

    internal class MyListElement
    {
        public string Name { get; }

        public MyListElement(string name)
        {
            Name = name;
        }
    }
}