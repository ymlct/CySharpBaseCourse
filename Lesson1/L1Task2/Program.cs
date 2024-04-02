using System;

namespace L1Task2
{
    /*
    Урок 1, Задание 3
    Cоздайте проект по шаблону Console Application.
    Требуется:
    - Создать класс Book. 
    - Создать классы Title, Author и Content, каждый из которых должен содержать одно строковое поле и метод void Show().
    - Реализуйте возможность добавления в книгу названия книги, имени автора и содержания.
    - Выведите на экран разными цветами при помощи метода Show() название книги, имя автора и содержание.
     */
    
    internal class Program
    {
        public static void Main(string[] args)
        {

            var author = new Author("Joshua Bloch");
            var title = new Title("Effective Java Programming Language Guide");
            var content = new Content("This highly readable book tells you how to use the Java programming language and its most fundamental libraries to best effect ...");

            var book = new Book();
            book.Author = author;
            book.Title = title;
            book.Content = content;

            book.Show();
        }
    }

    internal class Book
    {
        private Author _author;
        private Title _title;
        private Content _content;

        public Author Author
        {
            get { return _author; }
            set { _author = value; }
        }
        
        public Title Title{
            get { return _title; }
            set { _title = value; }
        }
        
        public Content Content{
            get { return _content; }
            set { _content = value; }
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Название книги:");
            Author.Show();
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Автор:");
            Title.Show();
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Содержание книги:");
            Content.Show();
        }

    }
    
    internal class Title
    {
        private string _value;

        public Title(string value)
        {
            _value = value;
        }

        public void Show()
        {
            Console.WriteLine(_value);
        }
    }
    
    internal class Author
    {
        private string _value;
        
        public Author(string value)
        {
            _value = value;
        }

        public void Show()
        {
            Console.WriteLine(_value);
        }
    }
    
    internal class Content
    {
        private string _value;

        public Content(string value)
        {
            _value = value;
        }
        
        public void Show()
        {
            Console.WriteLine(_value);
        }
    }
}