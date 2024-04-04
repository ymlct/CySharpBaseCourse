using System;

namespace L3Task3
{
    /*
    Создайте проект по шаблону Console Application.
    Требуется:
    Создайте класс DocumentWorker.
    - В теле класса создайте три метода OpenDocument(), EditDocument(), SaveDocument().
    - В тело каждого из методов добавьте вывод на экран соответствующих строк: "Документ открыт", 
      "Редактирование документа доступно в версии Про", "Сохранение документа доступно в версии Про".
    - Создайте производный класс ProDocumentWorker.
    - Переопределите соответствующие методы, при переопределении методов выводите следующие строки: 
      "Документ отредактирован", "Документ сохранен в старом формате, сохранение в остальных форматах доступно в версии Эксперт".
    - Создайте производный класс ExpertDocumentWorker от базового класса ProDocumentWorker. Переопределите соответствующий метод. 
      При вызове данного метода необходимо выводить на экран "Документ сохранен в новом формате".
    - В теле метода Main() реализуйте возможность приема от пользователя номера ключа доступа pro и exp. 
      Если пользователь не вводит ключ, он может пользоваться только бесплатной версией (создается экземпляр базового класса), 
      если пользователь ввел номера ключа доступа pro и exp, то должен создаться экземпляр соответствующей версии класса, 
      приведенный к базовому - DocumentWorker.
     */
    
    internal class Program
    {
        public static void Main(string[] args)
        {
          
          Console.WriteLine("Введите номера ключа программы:");
          var licenceKey = Console.ReadLine();

          DocumentWorker documentWorker = ResolveDocumentWorkerVersion(licenceKey);
          
          documentWorker.OpenDocument();
          documentWorker.EditDocument();
          documentWorker.SaveDocument();
        }

        internal static DocumentWorker ResolveDocumentWorkerVersion(string licenceKey)
        {
          DocumentWorker documentWorker;
          
          switch (licenceKey)
          {
            case "1": 
              documentWorker = new ExpertDocumentWorker();
              break;
            
            case "2": 
              documentWorker = new ProDocumentWorker();
              break;
            
            default:
              documentWorker = new DocumentWorker();
              break;
          }

          return documentWorker;
        }

        internal class DocumentWorker
        {
          internal void OpenDocument()
          {
            Console.WriteLine("Документ открыт");
          }
          internal virtual void EditDocument()
          {
            Console.WriteLine("Редактирование документа доступно в версии Про");
          }
          internal virtual void SaveDocument()
          {
            Console.WriteLine("Сохранение документа доступно в версии Про");
          }
        }

        internal class ProDocumentWorker : DocumentWorker
        {
          internal override void EditDocument()
          {
            Console.WriteLine("Документ отредактирован");
          }
          internal override void SaveDocument()
          {
            Console.WriteLine("Документ сохранен в старом формате, сохранение в остальных форматах доступно в версии Эксперт");
          }
        }
        
        internal class ExpertDocumentWorker : ProDocumentWorker
        { 
          internal override void SaveDocument()
          {
            Console.WriteLine("Документ сохранен в новом формате");
          }
        }
    }
}