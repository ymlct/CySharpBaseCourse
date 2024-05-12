using System;
using System.Collections;

namespace L14Task1
{
    internal class MyList<T> : IEnumerable where T : class
    {
        
        /// свойство только для чтения для получения общего количества элементов
        public int Size => _count;
        
        private T[] _elements;

        private const int InitialCapacity = 2;
        
        private int _count = 0;
        
        internal MyList(int initialCapacity = InitialCapacity)
        {
            _elements = new T[initialCapacity];
        }

        
        /// метод добавления элемента
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

        
        /// индексатор для получения значения элемента по указанному индексу
        internal T this[int index]
        {
            get
            {
                if (index >= 0 && index < _count) return _elements[index];
                throw new IndexOutOfRangeException();
            }
        }
        
        internal void Clear()
        {
            _elements = new T[_elements.Length];
            _count = 0;
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
        
        
        // обеспечение работы `foreach`
        
        /// Реализация интерфейса `IEnumerable`
        public IEnumerator GetEnumerator()
        {
            return new MyListEnumerator(this);
        }
        
        /// Реализация интерфейса `IEnumerator`
        internal class MyListEnumerator : IEnumerator
        {

            private MyList<T> _list;
            
            private int _position = -1;

            internal MyListEnumerator(MyList<T> list)
            {
                _list = list;
            }

            public bool MoveNext()
            {
                if (_position < _list.Size - 1)
                {
                    _position++;
                    return true;
                }

                Reset();
                return false;
            }

            public void Reset() { _position = -1; }
            
            public object Current => _list[_position];
            
        }

    }
}