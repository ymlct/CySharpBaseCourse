using System;

namespace L2Task2
{
    
    /*
    Урок 2, Задание 3
    Создайте проект по шаблону Console Application.
    Требуется:
    - Создать класс Employee.
    - В теле класса создать пользовательский конструктор, который принимает два строковых аргумента, и
      инициализирует поля, соответствующие фамилии и имени сотрудника.
    - Создать метод рассчитывающий оклад сотрудника (в зависимости от должности и стажа) и налоговый сбор.
    - Написать программу, которая выводит на экран информацию о сотруднике (фамилия, имя, должность), 
      оклад и налоговый сбор.
     */
    
    internal class Program
    {
        public static void Main(string[] args)
        {

            var emp1 = new Employee("Richard", "Hendrix");
            var emp2 = new Employee("Bertram", "Gilfoyle");
            var emp3 = new Employee("Erlich", "Bachman");
            var emp4 = new Employee("Dinesh", "Chugtai");
            var emp5 = new Employee("Big", "Head");
            
            emp1.PrintBio();
            emp2.PrintBio();
            emp3.PrintBio();
            emp4.PrintBio();
            emp5.PrintBio();

        }

        internal class Employee
        {

            public string Name { get; }

            public string Surname { get; }

            private int _positionKey;
            
            private int _experienceInYears;

            
            public Employee(string name, string surname)
            {
                Name = name;
                Surname = surname;
                
                Init();
            }

            public void PrintBio()
            {
                CalcSalaryAndTaxes(
                    out double salary,
                    out double taxes
                    );
                
                Console.WriteLine($"\nИмя, отчество: {Name} {Surname},\n-- должность: {GetPositionByKey(_positionKey)},\n-- оклад: {salary}, \n-- налог: {taxes}");
            }

            private void Init()
            {
                Random rnd = new Random();
                
                _positionKey = rnd.Next(1, 5); 
                _experienceInYears = rnd.Next(1, 15); 
            }

            private void CalcSalaryAndTaxes(
                out double salary,
                out double taxes
                )
            {
                salary = CalcSalary(_positionKey);
                taxes = CalcTaxes(salary);
            }
            
            private double CalcSalary(int positionKey)
            {
                var baseSalary = 20000;
                double result;

                switch (positionKey)
                {
                    case 1:
                    case 2:
                    case 3:
                        result = baseSalary + baseSalary / (double) positionKey * _experienceInYears * _experienceInYears * 0.1;
                        break;
                    
                    default:
                        result = baseSalary;
                        break;
                }

                return result;
            }
            
            private double CalcTaxes(double salary)
            {
                return salary * 0.13;
            }

            private string GetPositionByKey(int positionKey)
            {
                string result;
                
                switch (positionKey)
                {
                    case 1:
                        result = "Директор";
                        break;
                    
                    case 2:
                        result = "Заместитель";
                        break;
                    
                    case 3:
                        result = "Специалист";
                        break;
                    
                    default:
                        result = "Стажер";
                        break;
                }

                return result;
            }

        }
    }
}