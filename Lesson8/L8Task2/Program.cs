using System;

namespace L8Task2
{
    /*
    Задание 3
    Cоздайте проект по шаблону Console Application.
    - Создайте перечисление, в котором будут содержаться должности сотрудников как имена констант.
    - Присвойте каждой константе значение, задающее количество часов, которые должен отработать
      сотрудник за месяц.
    - Создайте класс Accauntant с методом bool AskForBonus(Post worker, int hours), отражающее
      давать или нет сотруднику премию. Если сотрудник отработал больше положеных часов в месяц, то ему
      положена премия.
     */
    internal class Program
    {
        public static void Main(string[] args)
        {

            Accauntant accauntant = new Accauntant();
            Worker worker1 = new Worker("Richard Hendrix", Position.SeniorSpecialist);
            Worker worker2 = new Worker("Bertram Bertram", Position.MiddleSpecialist);
            Worker worker3 = new Worker("Dinesh Chugtai", Position.JuniorSpecialist);
            Worker worker4 = new Worker("Erlich Bachman", Position.TraineeSpecialist);
            
            var yes = "Да";
            var no = "Нет";
            
            var worker1HasBonus = accauntant.AskForBonus(worker1, 140) ? yes : no;
            var worker2HasBonus = accauntant.AskForBonus(worker2, 140) ? yes : no;
            var worker3HasBonus = accauntant.AskForBonus(worker3, 135) ? yes : no;
            var worker4HasBonus = accauntant.AskForBonus(worker4, 20) ? yes : no;
            
            Console.WriteLine($"{worker1.Name} получит премию? {worker1HasBonus}");
            Console.WriteLine($"{worker2.Name} получит премию? {worker2HasBonus}");
            Console.WriteLine($"{worker2.Name} получит премию? {worker3HasBonus}");
            Console.WriteLine($"{worker3.Name} получит премию? {worker4HasBonus}");
        }
    }

    internal class Accauntant
    {
        internal bool AskForBonus(Worker worker, int hours)
        {
            return (int) worker.Position <= hours;
        }
    }
    
    internal class Worker
    {
        internal string Name { get; private set; }
        internal Position Position { get; private set; }

        public Worker(string name, Position position)
        {
            Name = name;
            Position = position;
        }
    }

    internal enum Position
    {
        TraineeSpecialist = 140,
        JuniorSpecialist = 135,
        MiddleSpecialist = 130,
        SeniorSpecialist = 120
    }
}