using System;

namespace L3Task2
{
    /*
    Задание 3
    Создайте проект по шаблону Console Application.
    Требуется:
    - Создать класс Vehicle.
    - В теле класса создайте поля: координаты и параметры средств передвижения (цена, скорость, год выпуска).
    - Создайте 3 производных класса Plane, Саг и Ship.
    - Для класса Plane должна быть определена высота и количество пассажиров.
    - Для класса Ship — количество пассажиров и порт приписки.
    - Написать программу, которая выводит на экран информацию о каждом средстве передвижения.
     */
    internal class Program
    {
        public static void Main(string[] args)
        {
            Vehicle plane = new Plane(
                coordinates: new Coordinates(x: 100, y: 100, z: 5000), 
                price: 100000000, 
                speed: 850, 
                yearOfManufacturing: 2000, 
                altitude: 10500, 
                amountOfPassengers: 200
                );
            
            Vehicle car = new Car(
                coordinates: new Coordinates(x: 200, y: 200, z: 200), 
                price: 2000000, 
                speed: 160, 
                yearOfManufacturing: 2020
                );
            
            Vehicle ship = new Ship(
                coordinates: new Coordinates(x: 300, y: 300, z: 0), 
                price: 40000000, 
                speed: 50, 
                yearOfManufacturing: 2010,
                amountOfPassengers: 500,
                hostPort: "Порт"
                );

            ShowVehicleInfo(plane);
            ShowVehicleInfo(car);
            ShowVehicleInfo(ship);
        }

        internal static void ShowVehicleInfo(Vehicle vehicle)
        {
            string vehicleInfo;
            
            if (vehicle is Plane)
            {
                vehicleInfo = $"{GetVehicleInfo(vehicle)}, {GetPlaneSpecificInfo((Plane) vehicle)}.";
            }
            else if (vehicle is Ship)
            {
                vehicleInfo = $"{GetVehicleInfo(vehicle)}, {GetShipSpecificInfo((Ship) vehicle)}.";
            }
            else
            {
                vehicleInfo = $"{GetVehicleInfo(vehicle)}.";
            }
            Console.WriteLine(vehicleInfo);
        }
        
        internal static string GetVehicleInfo(Vehicle vehicle)
        {
            return $"Цена: {vehicle.Price}, скорость: {vehicle.Speed}, год выпуска: {vehicle.YearOfManufacturing}, координаты: {GetCoordinatesInfo(vehicle.Coordinates)}";
        }
        
        internal static string GetPlaneSpecificInfo(Plane vehicle)
        {
            return $"высота: {vehicle.Altitude}, количество пассажиров: {vehicle.AmountOfPassengers}";
        }
        
        internal static string GetShipSpecificInfo(Ship vehicle)
        {
            return $"порт приписки: {vehicle.HostPort}, количество пассажиров: {vehicle.AmountOfPassengers}";
        }
        
        
        internal static string GetCoordinatesInfo(Coordinates coordinates)
        {
            return $"(x: {coordinates.X}, y: {coordinates.Y}, z: {coordinates.Z})";
        }

        internal abstract class Vehicle
        {
            internal Coordinates Coordinates { get; set; }
            internal double Price { get; set; }
            internal double Speed { get; set; }
            internal int YearOfManufacturing { get; }
            
            protected Vehicle(Coordinates coordinates, double price, double speed, int yearOfManufacturing)
            {
                Coordinates = coordinates;
                Price = price;
                Speed = speed;
                YearOfManufacturing = yearOfManufacturing;
            }
        }

        internal class Plane : Vehicle
        {
            internal double Altitude { get; }
            internal int AmountOfPassengers { get; }

            public Plane(
                Coordinates coordinates, 
                double price, 
                double speed, 
                int yearOfManufacturing, 
                double altitude, 
                int amountOfPassengers
                ) : base(coordinates, price, speed, yearOfManufacturing)
            {
                Altitude = altitude;
                AmountOfPassengers = amountOfPassengers;
            }
        }
        internal class Car : Vehicle
        {
            public Car(Coordinates coordinates,
                double price,
                double speed,
                int yearOfManufacturing
                ) : base(coordinates, price, speed, yearOfManufacturing)
            {  }
        }
        
        internal class Ship : Vehicle
        {
            internal int AmountOfPassengers { get; }
            internal string HostPort { get; set; }

            public Ship(
                Coordinates coordinates,
                double price,
                double speed,
                int yearOfManufacturing,
                int amountOfPassengers,
                string hostPort
            ) : base(coordinates, price, speed, yearOfManufacturing)
            {
                AmountOfPassengers = amountOfPassengers;
                HostPort = hostPort;
            }
        }
        
        internal class Coordinates
        {
            internal double X { get; set; }
            internal double Y { get; set; }
            internal double Z { get; set; }
            
            public Coordinates(double x, double y, double z)
            {
                X = x;
                Y = y;
                Z = z;
            }
        }
    }
}