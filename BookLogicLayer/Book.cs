using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLogicLayer
{
    [Serializable()]
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        public string Author { get; private set; }
        public string Title { get; private set; }
        public string Year { get; private set; }
        public string Genre { get; private set; }
        public int Pages { get; private set; }

        public Book(string author, string title, string year, string genre, int pages)
        {
            Author = author;
            Title = title;
            Year = year;
            Genre = genre;
            Pages = pages;
        }
        public Book() { }
        public override string ToString()
        {
            return string.Format("Title: {0} \r\nAuthor: {1} \r\nGenre: {2} \r\nYear: {3} \r\nPages: {4}\r\n", Title, Author, Genre, Year, Pages);
        }
        public int CompareTo(Book other)
        {
            return this.Title.CompareTo(other.Title);
        }

        public bool Equals(Book other)
        {
            if (other == null) return false;
            if (this.Title == other.Title && this.Author == other.Author && this.Year == other.Year) return true;
            return false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null) return false;

            Book book = obj as Book;
            if (book == null) return false;
            return Equals(book);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Book lhs, Book rhs)
        {
            if ((object)lhs == null || ((object)rhs) == null)
                return Object.Equals(lhs, rhs);
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Book lhs, Book rhs)
        {
            if (lhs == null || rhs == null) return !Object.Equals(lhs, rhs);

            return !(lhs.Equals(rhs));
        }
    }
}
