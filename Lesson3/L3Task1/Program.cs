using System;

namespace L3Task1
{
    /*
    Задание 2
    Создайте проект по шаблону Console Application.
    Требуется:
    - Создать класс, представляющий учебный класс ClassRoom.
    - Создайте класс ученик Pupil. В теле класса создайте методы void Study(), void Read(), void Write(),void Relax().
    - Создайте 3 производных класса ExcelentPupil, GoodPupil, BadPupil от класса базового класса Pupil 
      и переопределите каждый из методов, в зависимости от успеваемости ученика.
    - Конструктор класса ClassRoom принимает аргументы типа Pupil, класс должен состоять из 4 учеников. 
      Предусмотрите возможность того, что пользователь может передать 2 или 3 аргумента.
    - Выведите информацию о том, как все ученики экземпляра класса ClassRoom умеют учиться, читать, писать, отдыхать.
     */

    internal class Program
    {
        public static void Main(string[] args)
        {

            Pupil pupil1 = new ExcelentPupil();
            Pupil pupil2 = new GoodPupil();
            Pupil pupil3 = new GoodPupil();
            Pupil pupil4 = new BadPupil();

            ClassRoom classRoom = new ClassRoom(pupil1, pupil2, pupil3, pupil4);
            
            classRoom.ShowClassRoomStatistics();
            
        }

        internal class ClassRoom
        {
            internal Pupil Pupil1 { get; private set; }
            internal Pupil Pupil2 { get; private set; }
            internal Pupil Pupil3 { get; private set; }
            internal Pupil Pupil4 { get; private set; }

            internal ClassRoom(Pupil pupil1, Pupil pupil2)
            {
                Pupil1 = pupil1;
                Pupil2 = pupil2;
            }
            
            internal ClassRoom(Pupil pupil1, Pupil pupil2, Pupil pupil3)
                : this (pupil1: pupil1, pupil2: pupil2)
            {
                Pupil1 = pupil1;
                Pupil2 = pupil2;
                Pupil3 = pupil3;
            }
            
            internal ClassRoom(Pupil pupil1, Pupil pupil2, Pupil pupil3, Pupil pupil4)
                : this (pupil1: pupil1, pupil2: pupil2, pupil3: pupil3)
            {
                Pupil1 = pupil1;
                Pupil2 = pupil2;
                Pupil3 = pupil3;
                Pupil4 = pupil4;
            }

            internal void ShowClassRoomStatistics()
            {
                Console.WriteLine("Статистика класса:\n");

                Console.WriteLine("\nУченик 1:");
                Pupil1.Study();
                Pupil1.Read();
                Pupil1.Write();
                Pupil1.Relax();
                
                Console.WriteLine("\nУченик 2:");
                Pupil2.Study();
                Pupil2.Read();
                Pupil2.Write();
                Pupil2.Relax();
                
                if (Pupil3 != null)
                {
                    Console.WriteLine("\nУченик 3:");
                    Pupil3.Study();
                    Pupil3.Read();
                    Pupil3.Write();
                    Pupil3.Relax();
                }
                if (Pupil4 != null)
                {
                    Console.WriteLine("\nУченик 4:");
                    Pupil4.Study();
                    Pupil4.Read();
                    Pupil4.Write();
                    Pupil4.Relax();
                }
            }

        }

        internal abstract class Pupil
        {
            internal abstract void Study();
            internal abstract void Read();
            internal abstract void Write();
            internal abstract void Relax();
            
            
        }

        internal class ExcelentPupil : Pupil
        {
            internal override void Study()
            {
                Console.WriteLine("Учусь 8 часов в день.");
            }

            internal override void Read()
            {
                Console.WriteLine("Читаю 2 часа в день.");
            }

            internal override void Write()
            {
                Console.WriteLine("Пишу 2 часа в день.");
            }

            internal override void Relax()
            {
                Console.WriteLine("Отдыхаю 1 час в день.");
            }
        }

        internal class GoodPupil : Pupil
        {
            internal override void Study()
            {
                Console.WriteLine("Учусь 5 часов в день.");
            }

            internal override void Read()
            {
                Console.WriteLine("Читаю 1 час в день.");
            }

            internal override void Write()
            {
                Console.WriteLine("Пишу 1 час в день.");
            }

            internal override void Relax()
            {
                Console.WriteLine("Отдыхаю 3 часа в день.");
            }
        }

        internal class BadPupil : Pupil
        {
            internal override void Study()
            {
                Console.WriteLine("Учусь 1 час в день.");
            }

            internal override void Read()
            {
                Console.WriteLine("Читаю 20 минут в день.");
            }

            internal override void Write()
            {
                Console.WriteLine("Пишу 10 минут в день.");
            }

            internal override void Relax()
            {
                Console.WriteLine("Отдыхаю 8 часов в день.");
            }
        }

    }
}