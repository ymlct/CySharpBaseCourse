using System;
using System.Collections;

namespace L14Task2
{
    public class MyDictionary<TKey, TValue>
    {
        private Entry[] _entries;
        
        // хранит индексы Entry в _entries
        private int[] _bucketIndices;


        /// свойство только для чтения для получения общего количества элементов
        internal int Count { get; private set; }
        
        private const int InitialCapacity = 3;
        private const int DefPointerValue = -1;

        private struct Entry
        {
            internal int Hashcode;

            internal int Next;
            
            internal TKey Key;
            
            internal TValue Value;
        }

        public MyDictionary()
        {
            _bucketIndices = new int[InitialCapacity];
            // необходимо установить дефолтные значения, т.к. логика работы класса ожидает это 
            SetBucketsWithDefaultValues(_bucketIndices);
            
            _entries = new Entry[InitialCapacity];
            Count = 0;
        }

        /// метод добавления элемента
        public void Add(TKey key, TValue value)
        {
            int hashcode = CalcHashcode(key);

            if (Count == _entries.Length)
            {
                IncreaseCapacity(
                    newCapacity: _entries.Length * 2, 
                    fromEntries: _entries, 
                    out int[] bucketIndices, 
                    out Entry[] entries
                );
                _bucketIndices = bucketIndices;
                _entries = entries;
            }
            
            int targetBucketIdx = ResolveBucketIdx(hashcode, _entries.Length);

            int entryIndex = Count;
            Count++;
            
            // если под данным индексом лежит указатель с дефолтным значением, значит bucket еще не занят
            if (_bucketIndices[targetBucketIdx] == DefPointerValue)
            {
                _bucketIndices[targetBucketIdx] = entryIndex;
            }
            // иначе ищем последний элемент в связанном списке;
            // последним будет тот `Entry`, у которого в поле `Next` лежит `-1`
            else {
                for (int i = _bucketIndices[targetBucketIdx]; i >= 0; i = _entries[i].Next)
                {
                    if (_entries[i].Next == DefPointerValue)
                    {
                        _entries[i].Next = entryIndex;
                        break;
                    }
                }
            }
            
            _entries[entryIndex].Hashcode = hashcode;
            _entries[entryIndex].Next = DefPointerValue;
            _entries[entryIndex].Key = key;
            _entries[entryIndex].Value = value;
        }

        
        // индексатор для получения значения элемента по указанному ключу
        public TValue this[TKey key]
        {
            get
            {
                int hashcode = CalcHashcode(key);
                int targetBucket = ResolveBucketIdx(hashcode, _entries.Length);

                int entryIndex = _bucketIndices[targetBucket];

                for (int i = entryIndex; i >= 0; i = _entries[entryIndex].Next)
                {
                    if (_entries[i].Key.GetHashCode() == key.GetHashCode())
                    {
                        return _entries[i].Value;
                    }
                }
                
                throw new NullReferenceException();
            }
        }
        
        /// индексатор для получения значения элемента по указанному индексу
        internal TValue this[int index]
        {
            get
            {
                if (index >= 0 && index < Count) return _entries[index].Value;
                throw new IndexOutOfRangeException();
            }
        }

        private int CalcHashcode(TKey key)
        {
            return Math.Abs(key.GetHashCode());
        }
        
        private int ResolveBucketIdx(int hashcode, int capacity)
        {
            return hashcode % capacity;
        }

        private void SetBucketsWithDefaultValues(int[] buckets)
        {
            for (var i = 0; i < buckets.Length; i++)
            {
                buckets[i] = DefPointerValue;
            }
        }

        // увеличивает размер словаря
        private void IncreaseCapacity(
            int newCapacity,
            Entry[] fromEntries,
            out int[] toBucketIndices,
            out Entry[] toEntries
            )
        {
            var currentCapacity = fromEntries.Length;

            toBucketIndices = new int[newCapacity];
            toEntries = new Entry[newCapacity];
            
            // необходимо установить дефолтные значения, т.к. логика работы класса ожидает это 
            SetBucketsWithDefaultValues(toBucketIndices);
            
            // т.к. механизм преобразования значения Key в индекс для Bucket использует текущий размер внутренних
            // коллекций, то при их увеличении необходимо пересчитать индексы для всех ранее добавленных элементов 
            for (var i = 0; i < currentCapacity; i++)
            {
                toEntries[i] = fromEntries[i];
                
                var recalcBucketIdx = ResolveBucketIdx(toEntries[i].Hashcode, newCapacity);
                
                if (toBucketIndices[recalcBucketIdx] == DefPointerValue) 
                {
                    toBucketIndices[recalcBucketIdx] = i;
                }
            }
        }
        
        
        /// обеспечение работы `foreach`

        // Реализация интерфейса `IEnumerable`
        public IEnumerator GetEnumerator()
        {
            return new MyDictionaryEnumerator(this);
        }
        
        // Реализация интерфейса `IEnumerator`
        internal class MyDictionaryEnumerator : IEnumerator
        {

            private MyDictionary<TKey, TValue> _dict;
            
            private int _position = -1;

            internal MyDictionaryEnumerator(MyDictionary<TKey, TValue> dict)
            {
                _dict = dict;
            }

            public bool MoveNext()
            {
                if (_position < _dict.Count - 1)
                {
                    _position++;
                    return true;
                }

                Reset();
                return false;
            }

            public void Reset() { _position = -1; }
            
            public object Current => _dict[_position];
            
        }
    }
}