using System;

namespace L4Task2
{
    /*
    Задание 3
    Создайте проект по шаблону Console Application.
    Требуется:
    - Создайте 2 интерфейса IPlayable и IRecodable. В каждом из интерфейсов создайте по 3 метода void Play() / 
      void Pause() / void Stop() и void Record() / void Pause() / void Stop() соответственно.
    - Создайте производный класс Player от базовых интерфейсов IPlayable и IRecodable.
    - Написать программу, которая выполняет проигрывание и запись.
     */
    internal class Program
    {
        public static void Main(string[] args)
        {

            Player player = new Player();
            
            player.Pause();
        }
    }

    interface IPlayable
    {
        void Play();
        void Pause();
        void Stop();
    }
    
    interface IRecodable
    {
        void Record();
        void Pause();
        void Stop();
    }

    internal class Player : IPlayable, IRecodable
    {
        
        public void Play()
        {
            Console.WriteLine("Playable.Play");
        }
        public void PausePlaying()
        {
            // Pause();
        }
        
        public void Pause()
        {
            Console.WriteLine("Playable.Pause");
        }

        public void Stop()
        {
            Console.WriteLine("Playable.Stop");
        }

        
        public void Record()
        {
            Console.WriteLine("IRecodable.Record");
        }
        
        void IRecodable.Pause()
        {
            Console.WriteLine("IRecodable.Pause");
        }
        void IRecodable.Stop()
        {
            Console.WriteLine("IRecodable.Stop");
        }
    }
}