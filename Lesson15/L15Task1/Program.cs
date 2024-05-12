using System;

namespace L15Task1
{
    /*
    Задание 2
    Требуется: Описать структуру с именем Worker, содержащую следующие поля:
    • фамилия и инициалы работника;
    • название занимаемой должности;
    • год поступления на работу.
    Написать программу, выполняющую следующие действия:
    • ввод с клавиатуры данных в массив, состоящий из пяти элементов типа Worker (записи должны
    быть упорядочены по алфавиту);
    • если значение года введено не в соответствующем формате выдает исключение.
    • вывод на экран фамилии работника, стаж работы которого превышает введенное значение.
    */
    internal class Program
    {
        public static void Main(string[] args)
        {
            int workersCount = 0;
            int workersCapacity = 5;

            Worker[] workers = new Worker[workersCapacity];
            
            while (workersCount < workersCapacity)
            {

                var name = ReadUserInput("имя работника");
                var position = ReadUserInput("должноть работника");
                
                var yearAsString = ReadUserInput("год приема на работу");
                var year = ConvertStringToYear(yearAsString);
                
                Console.WriteLine(year);

                workers[workersCount] = new Worker(name, position, year);

                workersCount++;
            }

            var experienceAsString = ReadUserInput("минимальный стаж для поиска работника");
            int minExperience = ParseStringToInt(experienceAsString);
            
            foreach (var worker in workers)
            {
                var workerExperience = DateTime.Now.Year - worker.YearOfHiring;
                if (workerExperience >= minExperience)
                {
                    Console.WriteLine($"Имя: {worker.Name}, должность: {worker.Position}, стаж: {workerExperience}");
                }
            }
        }

        public static string ReadUserInput(string inputDescription)
        {
            Console.WriteLine($"Введите {inputDescription}");
            return Console.ReadLine();
        }

        public static int ConvertStringToYear(string yearAsString)
        {
            int probableYear = ParseStringToInt(yearAsString);
            
            var currentYear = DateTime.Now.Year;

            var validationPeriod = 50;

            var upperBound = currentYear / validationPeriod;
            var lowerBound = upperBound - 2;
            var probableYearBound = probableYear / validationPeriod;
            
            bool isProbableYearWithinBounds = probableYearBound >= lowerBound && probableYear <= currentYear;
            
            if (!isProbableYearWithinBounds)
            {
                throw new ArgumentException($"Введено невалидное значение: год должен быть в промежутке от {lowerBound * validationPeriod} до {currentYear}.");
            }

            return probableYear;
        }
        
        public static int ParseStringToInt(string str)
        {
            if (int.TryParse(str, out int integer))
            {
                return integer;
            }
            throw new ArgumentException("Введено значение не являющееся натуральным числом.");
        }
    }
}