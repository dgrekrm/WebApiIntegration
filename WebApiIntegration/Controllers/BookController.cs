using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiIntegration.Models;

namespace WebApiIntegration.Controllers {

    [Authorize]
    public class BookController : ApiController {

        private static readonly List<Book> Books = new List<Book> {
            new Book{ Id = 1,Category = "A",Title = "A"},
            new Book{ Id = 2,Category = "B",Title = "B"},
            new Book{ Id = 3,Category = "C",Title = "C"}
        };

        public List<Book> GetBooks() {
            return Books;
        }

        public Book GetBook(int id) {
            return Books.FirstOrDefault(s => s.Id == id);
        }

    }
}
