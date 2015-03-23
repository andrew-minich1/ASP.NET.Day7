﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLogicLayer;
using BookRepositoryInterface;
using NLog;
using LogInterface;


namespace BookListServiceLogicLayer
{
    public class BookListService
    {
        private static  ILog logger;
        private IBookRepository repository;
        public  List<Book> Books { get; private set; }
        public BookListService(IBookRepository repository , ILog log)
        {
            if (repository == null) throw new ArgumentNullException();
            this.repository = repository;
            Books = repository.LoadBooks().ToList<Book>();
            logger = log;
        }
        public void AddBook(Book book)
        {
            if (book == null) throw new ArgumentNullException();
            try
            {
                if (this.Books.Contains<Book>(book)) throw new ArgumentException();
            }
            catch (ArgumentException e)
            {
                logger.Log(e);
            }
            Books.Add(book);
            repository.SaveBooks(this.Books);
        }
        public void RemoveBook(Book book)
        {
            if (book == null) throw new ArgumentNullException();
            Books.Remove(book);
            repository.SaveBooks(this.Books);
        }
        public void SortBooks(IComparer<Book> comparer)
        {
            if (comparer == null) throw new ArgumentNullException();
            Books.Sort(comparer);
            repository.SaveBooks(Books);
        }
        public IEnumerable<Book> SelectByTitle(string title)
        {
            IEnumerable<Book> temp = new List<Book>();
            temp = Books.Where(book => book.Title == title).Select(book => book);
            return temp;
        }
    }

    #region IComparer
    public class ComporatorByTitle : IComparer<Book>
    {
        public int Compare(Book first, Book second)
        {
            return first.Title.CompareTo(second.Title);
        }
    }

    public class ComporatorByAuthor : IComparer<Book>
    {
        public int Compare(Book first, Book second)
        {
            return first.Author.CompareTo(second.Author);
        }
    }

    public class ComporatorByYear : IComparer<Book>
    {
        public int Compare(Book first, Book second)
        {
            return first.Year.CompareTo(second.Year);
        }
    } 
    #endregion
}
