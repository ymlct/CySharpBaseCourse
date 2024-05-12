using System;

namespace L11Task3
{
    /*
    Задание 4
    Создайте проект по шаблону Console Application.
    Создайте класс ArrayList. Реализуйте в простейшем приближении возможность использования его
    экземпляра аналогично экземпляру класса ArrayList из пространства имен System.Collections.            
    */
    internal class Program
    {
        public static void Main(string[] args)
        {

            MyArrayList myArrayList = new MyArrayList();
            
            myArrayList.Add("A");
            myArrayList.Add(1);
            Console.WriteLine(myArrayList.Size);
            
            myArrayList.Add(2F);
            Console.WriteLine(myArrayList.Size);

            PrintIfNotNull(myArrayList, 0);
            PrintIfNotNull(myArrayList, 1);
        }

        private static void PrintIfNotNull(MyArrayList arrayList, int idx)
        {
            try
            {
                var element = arrayList[idx];
                Console.WriteLine($"Елемент {element}");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    internal class MyArrayList
    {
        
        public int Size => _count;
        
        private object[] _elements;

        private const int InitialCapacity = 2;
        
        private int _count = 0;
        
        internal MyArrayList(int initialCapacity = InitialCapacity)
        {
            _elements = new object[initialCapacity];
        }

        internal void Add(object element)
        {
            if (!IsWithinBounds(_count))
            {
                object[] newElements = new object[_elements.Length * 2];
                Copy(_elements, ref newElements);

                _elements = newElements;
            }
            
            _elements[_count] = element;
            _count++; 
        }

        internal object this[int index]
        {
            get
            {
                if (index >= 0 && index < _count) return _elements[index];
                throw new IndexOutOfRangeException();
            }
        }

        private void Copy(object[] from, ref object[] to)
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