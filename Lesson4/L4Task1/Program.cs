using System;  
  
namespace L4Task1  
{  
    /*  
    Задание 2    
    Создайте проект по шаблону Console Application.    
    Требуется:    
    - Создайте класс AbstractHandler.    
    - В теле класса создать методы void Open(), void Create(), void Change(), void Save().    
    - Создать производные классы XMLHandler, TXTHandler, DOCHandler от базового класса AbstractHandler.    
    - Написать программу, которая будет выполнять определение документа и для каждого формата должны
      быть методы открытия, создания, редактирования, сохранения определенного формата документа     
      */    
    internal class Program  
    {  
        private const string XmlExtension = "xml";  
        private const string TxtExtension = "txt";  
        private const string DocExtension = "doc";  
        public static void Main(string[] args)  
        {  
            Document[] documents =  
            {  
                new Document("Документ XML", extension: XmlExtension),  
                new Document("Документ TXT", extension: TxtExtension),  
                new Document("Документ DOC", extension: DocExtension)  
            };  
  
            AbstractHandler[] handlers = new AbstractHandler[documents.Length];  
            for (var i = 0; i < documents.Length; i++)  
            {  
                handlers[i] = ResolveHandlerForDocument(documents[i]);  
            }  
              
            foreach (var handler in handlers)  
            {  
                Console.WriteLine("\n");
                handler.Create();  
                handler.Open();  
                handler.Change();  
                handler.Save();  
            }  
        }  
  
        internal static AbstractHandler ResolveHandlerForDocument(Document document)  
        {  
            AbstractHandler handler = null;  
            switch (document.Extension)  
            {  
                case XmlExtension:  
                    handler = new XMLHandler();  
                    break;        
                
                case TxtExtension:  
                    handler = new TXTHandler();  
  
                    break;                
                
                case DocExtension:  
                    handler = new DOCHandler();  
                    break;            }  
  
            return handler;  
        }  
    }  
      
  
    internal class Document  
    {  
        internal string Name { get; set; }  
        internal string Extension { get; set; }  
  
        public Document(string name, string extension)  
        {  
            Name = name;  
            Extension = extension;  
        }  
    }  
  
    internal abstract class AbstractHandler  
    {  
        internal abstract void Open();  
        internal abstract void Create();  
        internal abstract void Change();  
        internal abstract void Save();  
    }  
  
    internal class XMLHandler : AbstractHandler  
    {  
        internal override void Open()  
        {  
            Console.WriteLine("XMLHandler открыл файл.");  
        }  
        internal override void Create()  
        {  
            Console.WriteLine("XMLHandler создал файл.");  
  
        }  
        internal override void Change()  
        {  
            Console.WriteLine("XMLHandler изменил файл.");  
        }  
        internal override void Save()  
        {  
            Console.WriteLine("XMLHandler сохранил файл.");  
        }  
    }  
      
    internal class TXTHandler : AbstractHandler  
    {  
        internal override void Open()  
        {  
            Console.WriteLine("TXTHandler открыл файл.");  
        }  
        internal override void Create()  
        {  
            Console.WriteLine("TXTHandler создал файл.");  
  
        }  
        internal override void Change()  
        {  
            Console.WriteLine("TXTHandler изменил файл.");  
        }  
        internal override void Save()  
        {  
            Console.WriteLine("TXTHandler сохранил файл.");  
        }  
    }  
      
    internal class DOCHandler : AbstractHandler  
    {  
        internal override void Open()  
        {  
            Console.WriteLine("DOCHandler открыл файл.");  
        }  
        internal override void Create()  
        {  
            Console.WriteLine("DOCHandler создал файл.");  
  
        }  
        internal override void Change()  
        {  
            Console.WriteLine("DOCHandler изменил файл.");  
        }  
        internal override void Save()  
        {  
            Console.WriteLine("DOCHandler сохранил файл.");  
        }  
    }  
}