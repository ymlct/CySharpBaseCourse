namespace L10Task2
{
    /*
    Задание 3
    Создайте проект по шаблону Console Application.
    - Создайте класс MyDictionary<TKey,TValue>. 
    - Реализуйте в простейшем приближении возможность использования его экземпляра аналогично экземпляру класса 
      Dictionary (Урок 6 пример 5).
    - Минимально требуемый интерфейс взаимодействия с экземпляром, должен включать 
        - метод добавления пар элементов, 
        - индексатор для получения значения элемента по указанному индексу и
        - свойство только для чтения для получения общего количества пар элементов.
     */
    internal class Program
    {
        public static void Main(string[] args)
        {
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
    
    /*


    internal class MyList<T> where T : class
    {
        
        public int Size => _elements.Length;
        
        private T[] _elements;

        private const int InitialCapacity = 2;
        
        private int _capacityUsedPointer = 0;
        
        internal MyList(int initialCapacity = InitialCapacity)
        {
            _elements = new T[initialCapacity];
        }

        internal void Add(T element)
        {
            if (IsWithinBounds(_capacityUsedPointer))
            {
                _elements[_capacityUsedPointer] = element;
                _capacityUsedPointer++; 
            }
            else
            {
                T[] newElements = new T[_elements.Length * 2];
                Copy(_elements, ref newElements);

                _elements = newElements;
            }
        }

        internal T this[int index]
        {
            get
            {
                if (index >= 0 && index < _capacityUsedPointer) return _elements[index];
                else return null;
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
     */
}