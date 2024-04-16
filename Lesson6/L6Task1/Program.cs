using System;

namespace L6Task1
{
    /*
     Задание 2
     Создайте проект по шаблону Console Application.
     Требуется:
     - Создать статический класс FindAndReplaceManager с методом void FindNext(string str) для поиска по книге из примера урока 005_Delegation.
     - При вызове этого метода, производится последовательный поиск строки в книге.
     */
    internal class Program
    {
        public static void Main(string[] args)
        {
            var author = new Author("Joshua Bloch");
            var title = new Title("Effective Java Programming Language Guide");
            var content = new Content(
                "This highly readable book tells you how to use the Java programming language and its most fundamental libraries to best effect ...",
                "Objects...",
                "Inheritance... in Java"
            );
            
            Book book = new Book(
                title: title,
                author: author,
                content: content
            );
            
            FindAndReplaceManager.FindNext(book, "Java");
        }
    }
    
     static class FindAndReplaceManager
    {
        static public void FindNext(Book book, string str)
        {
            book.FindNext(str);
        }
    }
    
    class Book
    {
        readonly Title title;
        readonly Author author;
        readonly Content content;

        public Book(Title title, Author author, Content content)
        {
            this.title = title;
            this.author = author;
            this.content = content;
        }
        
        public void FindNext(string str)
        {
            Console.WriteLine($"Поиск слова: {str}");

            for (int i = 0; i < content.Pages; i++)
            {
                Console.WriteLine($"\nна странице {i + 1}");
                var page = content[i];
                var words = page.Split(' ');
                var found = false;
                
                for (var j = 0; j < words.Length; j++)
                {
                    if (words[j].Equals(str))
                    {
                        Console.WriteLine($"-- порядковый номер искомого слова {j + 1}");
                        found = true;
                    }
                }

                if (!found) { Console.WriteLine($"-- искомого слова не найдено."); }
            }
        }

        public void Show()
        {
            title.Show();
            author.Show();
            content.Show();
        }
    }
    class Title
    {
        readonly string _title;

        public Title(string title)
        {
            _title = title;
        }

        public void Show()
        {
            Console.WriteLine("Название: {_title}");
        }
    }
    
    class Content
    {
        readonly string[] _content;
        
        public readonly int Pages;
        
        public string this[int index] {
            get
            {
                if (index >= 0 && index < _content.Length)
                {
                    return _content [index];
                }
                return null;
            }
        }

        public Content(params string[] content)
        {
            _content = content;
            Pages = content.Length;
        }

        public void Show()
        {
            Console.WriteLine("Содержание");
            for (var i = 0; i < _content.Length; i++)
            {
                Console.WriteLine($"\nСтраница {i + 1}\n{_content}");
            }
        }
    }
    
    class Author
    {
        readonly string _name;
            
        public Author(string name)
        {
            _name = name;
        }

        public void Show()
        {
            Console.WriteLine($"Автор: {_name}");
        }
    }
}