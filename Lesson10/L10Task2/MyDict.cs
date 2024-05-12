using System;

namespace L10Task2
{
   /*
     Value - хранимое в словаре значение
     Key - ключ для хранимого в словаре значения
     Entry - контейнер для Key и Value
     Bucket - односторонний связанный список, состоящий из Entry; используется для разрешения коллизий по хэшкоду от Key
     
     Принцип работы:
     1. Внутри есть два массива: 
     1.1. В первый последовательно записываются Value (в обертке Entry) по мере их добавления в словарь. 
     1.2. Второй используется как адаптер:
     1.2.1. Значение Key с помощью некоторых вычислений преобразуется в индекс в этом массиве.
     1.2.2. Под полученным индексом в этот массив записывается индекс из первого массива для соответствующего Entry.
     2. Когда происходит коллизия по хэшу от Key, и для очередной добавляемой пары Key Value возвращается Bucket, 
     в котором уже есть другая пара Key Value, то в такой ситуации индекс (в массиве с Entry) для добавляемого элемента 
     записывается в поле Entry.Next существующего элемента, в результате чего формируется однонаправленный связанный список.                 
    */
    internal class MyDict<TKey, TValue>
    {
        private Entry[] _entries;
        
        // хранит индексы Entry в _entries
        private int[] _bucketIndices;

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

        public MyDict()
        {
            _bucketIndices = new int[InitialCapacity];
            // необходимо установить дефолтные значения, т.к. логика работы класса ожидает это 
            SetBucketsWithDefaultValues(_bucketIndices);
            
            _entries = new Entry[InitialCapacity];
            Count = 0;
        }

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
    }
}