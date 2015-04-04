using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRepositoryInterface;
using BookLogicLayer;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Repository
{
    public class BinarySerialization : IBookRepository
    {
        public static string FileName { get; private set; }
        public BinarySerialization(string fileName)
        {
            FileName = fileName;
        }
        public IEnumerable<Book> LoadBooks()
        {
            try
            {
                List<Book> books = new List<Book>();
                BinaryFormatter binFormat = new BinaryFormatter();

                using (Stream stream = new FileStream(FileName, FileMode.OpenOrCreate))
                {
                    if (stream.Length != 0)
                        books = (List<Book>)binFormat.Deserialize(stream);
                }
                return books;
            }
            catch
            {
                throw new IOException();
            }
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            if (ReferenceEquals(books, null)) throw new ArgumentNullException();

            BinaryFormatter binFormat = new BinaryFormatter();
            try
            {
                using (Stream stream = new FileStream(FileName, FileMode.OpenOrCreate))
                {
                    if (stream.Length != 0)
                        binFormat.Serialize(stream, books);
                }
            }
            catch
            {
                throw new IOException();
            }
        }
    }
}
