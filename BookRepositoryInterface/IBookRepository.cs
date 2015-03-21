﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLogicLayer;

namespace BookRepositoryInterface
{
    public interface IBookRepository
    {
        IEnumerable<Book> LoadBooks();
        void SaveBooks(IEnumerable<Book> books);
    }
}
