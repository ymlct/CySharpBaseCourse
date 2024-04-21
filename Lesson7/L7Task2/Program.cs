using System;

namespace L7Task2
{
    /*
    Создайте класс MyClass и структуру MyStruct, которые содержат в себе поля public string change.
    В классе Program создайте два метода:
    - static void ClassTaker(MyClass myClass), который присваивает полю change экземпляра
      myClass значение «изменено».
    - static void StruktTaker(MyStruct myStruct), который присваивает полю change экземпляра
      myStruct значение «изменено».
    Продемонстрируйте разницу в использовании классов и структур, создав в методе Main() экземпляры
    структуры и класса. Измените, значения полей экземпляров на «не изменено», а затем вызовите методы
    ClassTaker и StruktTaker. Выведите на экран значения полей экземпляров. Проанализируйте
    полученные результаты.
     */
    internal class Program
    {
        public static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            MyStruct myStruct = new MyStruct();
            
            myClass.Change = "не изменено";
            myStruct.Change = "не изменено";

            Console.WriteLine($"До передачи в метод: MyClass: hashCode={myClass.GetHashCode()}, {myClass.Change}");
            Console.WriteLine($"До передачи в метод: MyStruct: hashCode={myStruct.GetHashCode()}, {myStruct.Change}");
            
            ClassTaker(myClass);
            StructTaker(myStruct);
            
            Console.WriteLine($"После передачи в метод: MyClass: hashCode={myClass.GetHashCode()}, {myClass.Change}");
            Console.WriteLine($"После передачи в метод: MyStruct: hashCode={myStruct.GetHashCode()}, {myStruct.Change}");
        }


        static void ClassTaker(MyClass myClass)
        {
            myClass.Change = "изменено";
            Console.WriteLine($"В момент исполнения метода: MyClass: hashCode={myClass.GetHashCode()}, {myClass.Change}");
        }

        static void StructTaker(MyStruct myStruct)
        {
            myStruct.Change = "изменено";
            Console.WriteLine($"В момент исполнения метода: MyStruct: hashCode={myStruct.GetHashCode()}, {myStruct.Change}");
        }
    }

    internal class MyClass
    {
        public string Change;
    }
    
    internal struct MyStruct
    {
        public string Change;
    }
}