using System;

namespace L10Task1
{
    /*
    Задание 2
    Создайте проект по шаблону Console Application.
     - Создайте класс MyList<T>. Реализуйте в простейшем приближении возможность использования его
    экземпляра аналогично экземпляру класса List<T>. 
     - Минимально требуемый интерфейс взаимодействия с экземпляром, должен включать:
        - метод добавления элемента, 
        - индексатор для получения значения элемента по указанному индексу и 
        - свойство только для чтения для получения общего количества элементов.
     */
    internal class Program
    {
        public static void Main(string[] args)
        {

            MyList<MyListElement> myList = new MyList<MyListElement>();
            
            myList.Add(new MyListElement("A"));
            myList.Add(new MyListElement("B"));
            Console.WriteLine(myList.Size);
            
            myList.Add(new MyListElement("C"));
            Console.WriteLine(myList.Size);

            PrintIfNotNull(myList, 1);
            PrintIfNotNull(myList, 3);
        }

        private static void PrintIfNotNull(MyList<MyListElement> list, int idx)
        {
            var element = list[idx];
            if (element != null) 
                Console.WriteLine($"Елемент {element.Name}");
            else 
                Console.WriteLine($"Елемент null");


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

    internal class MyList<T>
    {
        
        public int Size => _count;
        
        private T[] _elements;

        private const int InitialCapacity = 2;
        
        private int _count = 0;
        
        internal MyList(int initialCapacity = InitialCapacity)
        {
            _elements = new T[initialCapacity];
        }

        internal void Add(T element)
        {
            if (!IsWithinBounds(_count))
            {
                T[] newElements = new T[_elements.Length * 2];
                Copy(_elements, ref newElements);

                _elements = newElements;
            }
            
            _elements[_count] = element;
            _count++; 
        }

        internal T this[int index]
        {
            get
            {
                if (index >= 0 && index < _count) return _elements[index];
                throw new IndexOutOfRangeException();
            }
        }

        private void Copy(T[] from, ref T[] to)
        {
            for (var i = 0; i < from.Length; i++)
            {
                to[i] = from[i];
            }
        }

        private bool IsWithinBounds(int pointer)
        {
            return pointer >= 0 && pointer < _elements.Length;
        }

    }
}