using Database.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class BooksRepository : IBookRepository
    {
        private readonly IMongoCollection<Book> _books;
        public BooksRepository(IDbClient dbClient)
        {
           _books = dbClient.GetBooksCollection();
        }

        public Book AddBook(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void RemoveBook(string id)
        {
            _books.DeleteOne(x => x.Id == id);
        }

        public Book GetBook(string id)
        {
            return _books.Find(book => book.Id == id).FirstOrDefault();
        }

        public List<Book> GetBooks()
        {
            return _books.Find(book => true).ToList();
        }

        public Book UpdateBook(Book book)
        {
            GetBook(book.Id);
            _books.ReplaceOne(b => b.Id == book.Id, book);
            return book;
        }
    }
}
