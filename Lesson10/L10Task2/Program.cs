using System;

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
            MyDict<DictKey, DictValue> dict = new MyDict<DictKey, DictValue>();
            
            Console.WriteLine(dict.Count);

            var k1 = new DictKey("a");
            var k2 = new DictKey("b");
            var k31 = new DictKey("x");
            var k32 = new DictKey("y");
            var k33 = new DictKey("z");
            
            var v1 = new DictValue("A");
            var v2 = new DictValue("B");
            var v31 = new DictValue("X");
            var v32 = new DictValue("Y");
            var v33 = new DictValue("Z");
            
            dict.Add(k1, v1);
            dict.Add(k2, v2);
            dict.Add(k31, v31);
            dict.Add(k32, v32);
            dict.Add(k33, v33);
            
            var elementA = dict[k1];
            var elementB = dict[k2];
            var elementX = dict[k31];
            var elementY = dict[k32];
            var elementZ = dict[k33];
            
            Console.WriteLine(elementA.Name);
            Console.WriteLine(elementB.Name);
            Console.WriteLine(elementX.Name);
            Console.WriteLine(elementY.Name);
            Console.WriteLine(elementZ.Name);
        }
    }
    
    internal class DictValue
    {
        public string Name { get; }

        public DictValue(string name)
        {
            Name = name;
        }
    }
    
    internal class DictKey
    {
        public string Val { get; }

        public DictKey(string val)
        {
            Val = val;
        }

        // симуляция коллизии хэшей
        // public override int GetHashCode()
        // {
        //     int hash;
        //     switch (Val)
        //     {
        //         case "a":
        //             hash = 1;
        //             break;
        //         
        //         case "b":
        //             hash = 2;
        //             break;
        //         
        //         default:
        //             hash = 3;
        //             break;
        //     }
        //     return hash;
        // }
    }
    
    /*
     Value - хранимое в словаре значение
     Key - ключ для хранимого в словаре значения
     Entry - контейнер для Key и Value
     Bucket - односторонний связанный список, состоящий из Value; используется для разрешения коллизий по хэшкоду
     
     Принцип работы:
     1. Внутри есть два массива: 
     1.1. В первый последовательно записываются Value (в обертке Entry) по мере их добавления в словарь. 
     1.2. Второй используется как адаптер:
     1.2.1. Значение Key с помощью некоторых вычислений преобразуется в индекс в этом массиве.
     1.2.2. Под полученным индексом в этот массив записывается индекс из первого массива для соответствующего Entry.
     2. Когда происходит коллизия по хэшу от Key, и для очередной добавляемой пары Key Value возвращается Bucket, 
     в котором уже есть другая пара Key Value, то в такой ситуации индекс (в массиве с Entry) записывается 
     в поле Entry.Next, в результате чего формируется однонаправленный связанный список.                 
    */
    internal class MyDict<TKey, TValue>
    {
        // хранит индексы Entry в _entries
        private int[] _bucketIndices;
        
        private Entry[] _entries;

        internal int Count { get; private set; }
        
        private const int InitialCapacity = 3;
        private const int DefPointerValue = -1;
        
        internal struct Entry
        {
            internal int Hashcode;

            internal int Next;
            
            internal TKey Key;
            
            internal TValue Value;
            
        }

        public MyDict()
        {
            _bucketIndices = InitBuckets(InitialCapacity);
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
            // иначе ищем последний элемент в связанном списке
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

        private int[] InitBuckets(int size)
        {
            var buckets = new int[size];
            for (var i = 0; i < buckets.Length; i++)
            {
                buckets[i] = DefPointerValue;
            }
            return buckets;
        }

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
            
            for (var i = 0; i < newCapacity; i++)
            {
                toBucketIndices[i] = DefPointerValue;
            }
            
            for (var i = 0; i < currentCapacity; i++)
            {
                toEntries[i] = fromEntries[i];
                
                var updBucketIdx = ResolveBucketIdx(toEntries[i].Hashcode, newCapacity);
                
                if (toBucketIndices[updBucketIdx] == DefPointerValue) 
                {
                    toBucketIndices[updBucketIdx] = i;
                }
            }
        }
    }
}