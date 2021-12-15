using Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        Book AddBook(Book book);
        Book GetBook(string id);
        void RemoveBook(string id);
        Book UpdateBook(Book book);
    }
}
