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
            List<Book> list = service.SelectByTitle("CLR via C#").ToList<Book>();
            foreach (var x in list)
            {
                Console.WriteLine(x.ToString());
            }
        }
    }
}
