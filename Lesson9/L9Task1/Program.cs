using System;

namespace L9Task1
{
    /*
    Задание 2
    Cоздайте проект по шаблону Console Application.
    - Создайте четыре лямбда оператора для выполнения арифметических действий: (Add – сложение, Sub –
      вычитание, Mul – умножение, Div – деление). 
    - Каждый лямбда оператор должен принимать два аргумента и возвращать результат вычисления. 
    - Лямбда оператор деления должен делать проверку деления на ноль.
    - Написать программу, которая будет выполнять арифметические действия указанные пользователем
    */
    internal class Program
    {
        delegate double Operation(double a, double b);

        private const string addSymbol = "+";
        private const string subSymbol = "-";
        private const string multSymbol = "*";
        private const string divSymbol = "/";
        
        public static void Main(string[] args)
        {
            
            var shouldExit = false;
            var isFirstIteration = true;

            Operation operation = null;
            double first = 0, second = 0;
            string inputOperation = "";
            
            while (!shouldExit)
            {
                if (isFirstIteration)
                {
                    first = ReadNumberFromInput();
                }

                if (isFirstIteration)
                {
                    second = ReadNumberFromInput();
                    inputOperation = ReadOperationFromInput();
                    isFirstIteration = false;
                }
                else
                {
                    inputOperation = ReadOperationFromInput();
                    second = ReadNumberFromInput();
                }

                operation = ResolveOperation(inputOperation);
                
                var result = operation.Invoke(first, second);
                Console.WriteLine($"Результат операции: {first} {inputOperation} {second} = {result}");
                
                first = result;

                Console.WriteLine("Для выхода введите 'Q'");
                var quitInput = Console.ReadLine();
                if (quitInput is "Q") shouldExit = true;
            }
        }

        
        private static double ReadNumberFromInput()
        {
            double userNumber;
            string input;
            
            while (true)
            {
                Console.WriteLine("Введите число");
                
                input = Console.ReadLine();
                
                if (!TryParseStringTorealNumber(input, out double number))
                {
                    Console.WriteLine("Проверьте правильность ввода.");
                    continue;
                }

                userNumber = number;
                break;
            }
            
            return userNumber;
        }
        
        private static string ReadOperationFromInput()
        {
            var input = "";

            while (true)
            {
                Console.WriteLine("Для выбора операци над числами введите соответствующий символ. Доступные операции:");
                Console.WriteLine($"Сложение ('{addSymbol}'), вычитание ('{subSymbol}'), умножение ('{multSymbol}'), деление ('{divSymbol}').");

                input = Console.ReadLine();
                    
                if (!(input is addSymbol) && !(input is subSymbol) && !(input is multSymbol) && !(input is divSymbol)) continue;

                break;
            }
            return input;
        }
        
        private static Operation ResolveOperation(string operationCode)
        {
            Operation operation = null;
            switch (operationCode)
            {
                case addSymbol:
                    operation = (a, b) => a + b;
                    break;
                    
                case subSymbol:
                    operation = (a, b) => a - b;
                    break;
                    
                case multSymbol:
                    operation = (a, b) => a * b;
                    break;
                    
                case divSymbol:
                    operation = (a, b) => { if (b != 0) return a / b; else return 0; };
                    break;
            }
            return operation;
        }
        
        private static bool TryParseStringTorealNumber(string str, out double realNumber)
        {
            try
            {
                realNumber = Convert.ToDouble(str);
                return true;
            }
            catch (Exception ex)
            {
                realNumber = 0;
                return false;
            }
        }
    }
}