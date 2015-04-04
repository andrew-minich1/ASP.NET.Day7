using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLogicLayer;
using BookListServiceLogicLayer;
using FileRepository;
using BookRepositoryInterface;
using LogInterface;
using Repository;
using XMLExporterInterface;
using XMLExporter;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            BookListService service = new BookListService(new BinaryFileRepository("Book.doc"), new NLogLogic());


            Book book1 = new Book("Jeffrey Richter", "CLR via C#", "2014", "Programming", 890);
            Book book2 = new Book("Joseph Albahari", "C# 5.0 in a Nutshell", "2013", "Programming", 1029);
            Book book3 = new Book("Andrew Troelsen", "Pro C# 5.0 and the .NET 4.5 Framework", "2013", "Programming", 950);

            service.AddBook(book1);
            service.AddBook(book2);
            service.AddBook(book3);

            foreach (var x in service.Books)
            {
                Console.WriteLine(x.ToString());
            }

            BookListService service2 = new BookListService(new BinaryFileRepository("Book2.doc"), new NLogLogic());
            service2 = service.Filter(service2, book => book.Title == "CLR via C#");

            foreach (var x in service2.Books)
            {
                Console.WriteLine(x.ToString());
            }

            BookListService service3 = new BookListService(new BinarySerialization("Book3.dat"), new NLogLogic());
            service3.AddBook(book1);
            service3.AddBook(book2);
            service3.AddBook(book3);

            foreach (var x in service3.Books)
            {
                Console.WriteLine(x.ToString());
            }

            service.ExportToXML("Book4.xml" , new XMLExporterXmlWriter());
            service.ExportToXML("Book5.xml", new XMLExporterLINQ());
        }
    }
}
