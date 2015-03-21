using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRepositoryInterface;
using BookLogicLayer;
using System.IO;

namespace FileRepository
{
    public class BinaryFileRepository : IBookRepository
    {
        public static string FileName { get; private set; }
        public BinaryFileRepository(string fileName) 
        {
            FileName = fileName;
        }

        #region LoadBooks
        public IEnumerable<Book> LoadBooks()
        {
            List<Book> books = new List<Book>();
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.OpenOrCreate)))
                {
                    while (reader.PeekChar() != -1)
                    {
                        string author = reader.ReadString();
                        string name = reader.ReadString();
                        string year = reader.ReadString();
                        string genre = reader.ReadString();
                        int pages = reader.ReadInt32();
                        books.Add(new Book(name, author, year, genre, pages));
                    }
                    return books;
                }
            }
            catch
            {
                throw new IOException();
            }
        } 
        #endregion

        #region SaveBooks
        public void SaveBooks(IEnumerable<Book> books)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.OpenOrCreate)))
                {
                    foreach (var book in books)
                    {
                        writer.Write(book.Title);
                        writer.Write(book.Author);
                        writer.Write(book.Year);
                        writer.Write(book.Genre);
                        writer.Write(book.Pages);
                    }
                }
            }
            catch
            {
                throw new IOException();
            }
        } 
        #endregion
    }
}
