using System;

namespace L10Task3
{
    /*
    Задание 4
    Cоздайте проект по шаблону Console Application.
    - Создайте расширяющий метод: public static T[] GetArray<T>(this MyList<T> list)
    - Примените расширяющий метод к экземпляру типа MyList<T>, разработанному в домашнем задании 2 для данного урока. 
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
            
            var arr = myList.GetArray();
            
            for (var i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i].Name);
            }
        }
    }

    internal static class Extension
    {
        public static T[] GetArray<T>(this MyList<T> list)
        {
            T[] result = new T[list.Size];
            
            for (int i = 0; i < list.Size; i++)
            {
                result[i] = list[i];
            }

            return result;
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