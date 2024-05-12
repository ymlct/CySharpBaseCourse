using System;

namespace L14Task1
{
    /*
    Задание 2
    Создайте проект по шаблону Console Application.
    - Создайте коллекцию MyList<T>. Реализуйте в простейшем приближении возможность использования
      ее экземпляра аналогично экземпляру класса List<T>. 
    - Минимально требуемый интерфейс взаимодействия с экземпляром, должен включать 
      - метод добавления элемента, 
      - индексатор для получения значения элемента по указанному индексу и 
      - свойство только для чтения для получения общего количества элементов. 
    - Реализуйте возможность перебора элементов коллекции в цикле foreach. 
    */
    internal class Program
    {
        public static void Main(string[] args)
        {
            MyList<MyListElement> myList = new MyList<MyListElement>();
            
            myList.Add(new MyListElement("A"));
            myList.Add(new MyListElement("B"));
            myList.Add(new MyListElement("C"));

            PrintElements(myList);
            
            myList.Clear();
            
            PrintElements(myList);
        }

        private static void PrintElements (MyList<MyListElement> list)
        {
            foreach (MyListElement element in list)
            {
                Console.WriteLine($"Элемент {element.Name}");
            }
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