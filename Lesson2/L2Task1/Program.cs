using System;

namespace L2Task1
{
    /*
    Урок 2, Задание 2
    Создайте проект по шаблону Console Application.
    Требуется:
    - Создать класс Converter.
    - В теле класса создать пользовательский конструктор, который принимает три вещественных аргумента,
      и инициализирует поля соответствующие курсу 3-х основных валют, по отношению к рублю - public
      Converter(double usd, double eur, double cny).
    - Написать программу, которая будет выполнять конвертацию из рубля в одну из указанных валют,
      также программа должна производить конвертацию из указанных валют в рубль
     */
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            var converter = new Converter(
                rubToUsdExchangeCourse: 0.010808,
                rubToEurExchangeCourse: 0.010059,
                rubToCnyExchangeCourse: 0.07861
            );

            var shouldFinalize = false;

            Console.ForegroundColor = ConsoleColor.White;
            while (!shouldFinalize)
            {
                try
                {
                    Console.WriteLine(new string('\n', 1));
                    Console.WriteLine(new string('*', 10));
                    Console.WriteLine(new string('\n', 1));
                    Console.WriteLine(
                        "Выберите вариант конвертации:\n1. RUR -> USD\n2. RUR -> EUR\n3. RUR -> CYN\n4. USD -> RUR\n5. EUR -> RUR\n6. CYN -> RUR");

                    Console.WriteLine("\n");
                    Console.WriteLine("Для выбора введите порядковый номер операции и нажмите 'Enter'.");
                    var operationOrdinalStr = Console.ReadLine();
                    Console.WriteLine("\n");

                    Console.WriteLine("Введите количество конвертируемой валюты и нажмите 'Enter'.");
                    var currencyAmountStr = Console.ReadLine();
                    Console.WriteLine("\n");
                    
                    var operationOrdinal = Convert.ToInt16(operationOrdinalStr);
                    var currencyAmount = Convert.ToDouble(currencyAmountStr);

                    if (operationOrdinal < 1 || operationOrdinal > 6 || currencyAmount <= 0)
                    {
                        throw new Exception("");
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    switch (operationOrdinal)
                    {
                        case 1:
                            var usdAmount = converter.ConvertFromRub(rubAmount: currencyAmount,
                                converter.RubToUsdExchangeCourse);
                            Console.WriteLine($"{currencyAmount} RUR = {usdAmount} USD.");
                            break;

                        case 2:
                            var eurAmount = converter.ConvertFromRub(rubAmount: currencyAmount,
                                converter.RubToEurExchangeCourse);
                            Console.WriteLine($"{currencyAmount} RUR = {eurAmount} EUR.");
                            break;

                        case 3:
                            var cynAmount = converter.ConvertFromRub(rubAmount: currencyAmount,
                                converter.RubToCnyExchangeCourse);
                            Console.WriteLine($"{currencyAmount} RUR = {cynAmount} CYN.");
                            break;

                        case 4:
                            var rubToUsdAmount = converter.ConvertToRub(currencyAmount: currencyAmount,
                                converter.RubToUsdExchangeCourse);
                            Console.WriteLine($"{currencyAmount} USD = {rubToUsdAmount} RUR.");
                            break;

                        case 5:
                            var rubToEurAmount = converter.ConvertToRub(currencyAmount: currencyAmount,
                                converter.RubToEurExchangeCourse);
                            Console.WriteLine($"{currencyAmount} EUR = {rubToEurAmount} RUR.");
                            break;

                        case 6:
                            var rubToCynAmount = converter.ConvertToRub(currencyAmount: currencyAmount,
                                converter.RubToCnyExchangeCourse);
                            Console.WriteLine($"{currencyAmount} CYN = {rubToCynAmount} RUR.");
                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.White;

                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введены неверные значения.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                finally
                {
                    Console.WriteLine(
                        "Введите 'Да' и нажмите 'Enter', если хотите завершить работу программы. Для продожения нажмите 'Enter'.");
                    var userAnswer = Console.ReadLine();

                    shouldFinalize = userAnswer == "Да";
                }
            }
        }


        internal class Converter
        {

            private double _rubToUsdExchangeCourse, _rubToEurExchangeCourse, _rubToCnyExchangeCourse;

            public double RubToUsdExchangeCourse 
            { 
                get => _rubToUsdExchangeCourse;
                set { _rubToUsdExchangeCourse = value; }
            }
            
            public double RubToEurExchangeCourse 
            { 
                get => _rubToEurExchangeCourse;
                set { _rubToEurExchangeCourse = value; } 
            }

            public double RubToCnyExchangeCourse
            {
                get => _rubToCnyExchangeCourse;
                set { _rubToCnyExchangeCourse = value; }
            }


            public Converter(double rubToUsdExchangeCourse, double rubToEurExchangeCourse, double rubToCnyExchangeCourse)
            {
                RubToUsdExchangeCourse = rubToUsdExchangeCourse;
                RubToEurExchangeCourse = rubToEurExchangeCourse;
                RubToCnyExchangeCourse = rubToCnyExchangeCourse;
            }

            public double ConvertToRub(double currencyAmount, double rubToCurrencyExchangeCourse)
            {
                return rubToCurrencyExchangeCourse *currencyAmount;
            }
            
            public double ConvertFromRub(double rubAmount, double rubToCurrencyExchangeCourse)
            {
                return rubToCurrencyExchangeCourse * rubAmount;
            }

        }
    }
}