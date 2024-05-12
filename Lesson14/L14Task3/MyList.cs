using System;
using System.Collections;
using System.Collections.Generic;

namespace L14Task3
{
    internal class MyList<TList> : IEnumerable<TList> where TList : class
    {
        
        /// свойство только для чтения для получения общего количества элементов
        public int Size => _count;
        
        private TList[] _elements;

        private const int InitialCapacity = 2;
        
        private int _count = 0;
        
        internal MyList(int initialCapacity = InitialCapacity)
        {
            _elements = new TList[initialCapacity];
        }

        
        /// метод добавления элемента
        internal void Add(TList element)
        {
            if (!IsWithinBounds(_count))
            {
                TList[] newElements = new TList[_elements.Length * 2];
                Copy(_elements, ref newElements);

                _elements = newElements;
            }
            
            _elements[_count] = element;
            _count++; 
        }

        
        /// индексатор для получения значения элемента по указанному индексу
        internal TList this[int index]
        {
            get
            {
                if (index >= 0 && index < _count) return _elements[index];
                throw new IndexOutOfRangeException();
            }
        }
        
        internal void Clear()
        {
            _elements = new TList[_elements.Length];
            _count = 0;
        }

        private void Copy(TList[] from, ref TList[] to)
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


        IEnumerator<TList> IEnumerable<TList>.GetEnumerator()
        {
            return new MyListEnumerator<TList>(this);
        }

        /// обеспечение работы `foreach`
        
        // Реализация интерфейса `IEnumerable`
        public IEnumerator GetEnumerator()
        {
            return new MyListEnumerator<TList>(this);
        }
        
        // Реализация интерфейса `IEnumerator`
        internal class MyListEnumerator<TEnum> : IEnumerator<TEnum> where TEnum : class
        {

            private MyList<TEnum> _list;
            
            private int _position = -1;

            public object Current => _list[_position];

            TEnum IEnumerator<TEnum>.Current => _list[_position];

            internal MyListEnumerator(MyList<TEnum> list) 
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

            
            public void Dispose() { }
        }

    }
}