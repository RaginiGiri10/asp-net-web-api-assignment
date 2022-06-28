using Assignment_2_BookManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment_2_BookManagement.Controllers
{
    public class ValuesController : ApiController
    {
        [Route("api/book")]
        public HttpResponseMessage Get()
        {
            BookRepository bookRepository = new BookRepository();
            var books = bookRepository.GetBooks();
            if (books == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"No book found.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, books);

        }

        public HttpResponseMessage Get(string author)
        {
            var bookRepository = new BookRepository();
            var book = bookRepository.GetAuthor(author);
            if (book == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Book with author ={author} not found.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, book);
        }
        public HttpResponseMessage GetRating(int rating)
        {
            var bookRepository = new BookRepository();
            var book = bookRepository.GetBookByRating(rating);
            if (book == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Book with rating ={rating} not found.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, book);
        }





        public HttpResponseMessage Post(Book book)
        {
            var bookRepository = new BookRepository();
            var addedBook = bookRepository.AddBook(book);
            if (addedBook == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Book with the title alreday exists");
            }
            var responseMessage = Request.CreateResponse(HttpStatusCode.Created);
            responseMessage.Headers.Location = new Uri($"{Request.RequestUri}/{book.Id}");
            return responseMessage;
        }

        public HttpResponseMessage Delete(int id)
        {
            var bookRepository = new BookRepository();
            bool isBookRemoved = bookRepository.DeleteBook(id);
            if (!isBookRemoved)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Book with id:{id} not found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, $"Book with id={id} is suceessfully removed");
        }




    }
}
