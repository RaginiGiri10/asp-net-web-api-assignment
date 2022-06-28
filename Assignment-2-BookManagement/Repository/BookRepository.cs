using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_2_BookManagement.Repository
{
    public class BookRepository
    {
        public List<Book> GetBooks()
        {
            List<Book> bookList;
            using (BookDBEntities bookDBEntities = new BookDBEntities())
            {
                bookList = new List<Book>();
                bookList = bookDBEntities.Books.ToList();
            }
            return bookList;

        }
        public List<Book> GetAuthor(string author)
        {
            List<Book> bookList;
            using (BookDBEntities bookDBEntities = new BookDBEntities())
            {

                bookList =bookDBEntities.Books.Where(p => p.Author==author).ToList();
            }
            return bookList;
        }
        public List<Book> GetBookByRating(int rating)
        {
            List<Book> bookList;
            using (BookDBEntities bookDBEntities = new BookDBEntities())
            {

                bookList = bookDBEntities.Books.Where(p => p.Rating == rating).ToList();
            }
            return bookList;
        }


        public Book AddBook(Book book)
        {
            using (BookDBEntities bookDBEntities = new BookDBEntities())
            {
                var bookExits = bookDBEntities.Books.FirstOrDefault(p => p.Title == book.Title);
                if (bookExits == null)
                {
                    bookDBEntities.Books.Add(book);
                    bookDBEntities.SaveChanges();
                    return book;
                }
                
            }
            return null;
        }
        public bool DeleteBook(int id)
        {
            bool isBookRemoved = false;
            using (BookDBEntities bookDBEntities = new BookDBEntities())
            {
                var bookTobeDeleted = bookDBEntities.Books.FirstOrDefault(x => x.Id == id);
                if (bookTobeDeleted != null)
                {
                    bookDBEntities.Books.Remove(bookTobeDeleted);
                    bookDBEntities.SaveChanges();
                    isBookRemoved = true;
                }
                return isBookRemoved;
            }


        }
    }
}