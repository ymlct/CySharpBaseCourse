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
            
            Console.WriteLine(dict.Count);

        }
    }
    
    // ключ элемента словаря 
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
    
    // элемент словаря
    internal class DictValue
    {
        public string Name { get; }

        public DictValue(string name)
        {
            Name = name;
        }
    }
    
    
}