using System;

namespace L16Task3
{
    /*
    Задание 4
    Создайте класс, который будет содержать информацию о дате (день, месяц, год). С помощью
    механизма перегрузки операторов, определите операцию разности двух дат (результат в виде
    количества дней между датами), а также операцию увеличения даты на определенное количество дней.           
    */
    internal class Program
    {
        public static void Main(string[] args)
        {

            Date date1 = new Date(2024, 5, 14);
            Date date2 = new Date(2024, 5, 12);
            
            var diff = date1 - date2;
            Console.WriteLine(diff);
            
            var date3 = date1 + 2;
            Console.WriteLine("{0}.{1}.{2}", date3.Year, date3.Month, date3.Day);
        }
    }

    internal class Date
    {
        private readonly DateTime _date;

        public int Year => _date.Year;
        public int Month => _date.Month;
        public int Day => _date.Day;
        
        public Date(int year, int month, int day)
        {
            _date = new DateTime(year, month, day);
        }

        public static int operator -(Date date1, Date date2)
        {
            if (date1._date > date2._date)
            {
                TimeSpan timeSpan = date1._date - date2._date;
                return timeSpan.Days;
            } 
            if (date1._date < date2._date)
            {
                TimeSpan timeSpan = date2._date - date1._date;
                return timeSpan.Days;
            }
            return 0;
        }
        
        public static Date operator +(Date date, int days)
        {
            var newDate = date._date.AddDays(days);
            
            return new Date(newDate.Year, newDate.Month, newDate.Day);
        }
    }
}