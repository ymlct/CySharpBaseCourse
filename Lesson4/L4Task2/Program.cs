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

            IPlayable playable = player;
            playable.Play();
            playable.Pause();
            playable.Stop();
            
            IRecordable recordable = player;
            recordable.Record();
            recordable.Pause();
            recordable.Stop();
        }
    }

    interface IPlayable
    {
        void Play();
        void Pause();
        void Stop();
    }
    
    public interface IRecordable
    {
        void Record();
        void Pause();
        void Stop();
    }

    public class Player : IPlayable, IRecordable
    {
        
        void IPlayable.Play()
        {
            Console.WriteLine("Playable.Play");
        }
        
        void IPlayable.Pause()
        {
            Console.WriteLine("Playable.Pause");
        }

        void IPlayable.Stop()
        {
            Console.WriteLine("Playable.Stop");
        }

        
        void IRecordable.Record()
        {
            Console.WriteLine("IRecodable.Record");
        }
        void IRecordable.Pause()
        {
            Console.WriteLine("IRecodable.Pause");
        }
        void IRecordable.Stop()
        {
            Console.WriteLine("IRecodable.Stop");
        }
    }
}