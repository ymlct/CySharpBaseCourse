namespace L7Task1
{
    /*
    Создайте проект по шаблону Console Application.
    Требуется: 
    - Описать структуру с именем Train, содержащую следующие поля: название пункта
    назначения, номер поезда, время отправления.
    - Написать программу, выполняющую следующие действия:
        - ввод с клавиатуры данных в массив, состоящий из восьми элементов типа Train (записи должны быть
        упорядочены по номерам поездов);
        - вывод на экран информации о поезде, номер которого введен с клавиатуры (если таких поездов нет,
          вывести соответствующее сообщение).
     */
    internal class Program
    {
        public static void Main(string[] args)
        {

            Train[] trains = new Train[8];
            
            for (var i = 0; i < trains.Length; i++)
            {
                var number = i + 1;
                trains[i] = new Train(
                    destinationPointName: $"Назначение {number}",
                    number: number,
                    departureTime: $"0{number}:00:00"
                );
            }
        }
    }

    internal struct Train
    {
        public string DestinationPointName { get; private set; }

        private int _number;
        public int Number { get => _number; private set => _number = value; }
        
        public string DepartureTime { get; private set; }

        public Train(
            string destinationPointName,
            int number,
            string departureTime
            )
        {
            DestinationPointName = destinationPointName;
            _number = number;
            DepartureTime = departureTime;
        }
    }

}