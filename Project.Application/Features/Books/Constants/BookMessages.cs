using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Books.Constants
{
    public static class BookMessages
    {
        public const string BookNotFound = "Book not found";
        public const string BookNameAlreadyExists = "Book name already exists";
        public const string BookListIsEmpty = "Book list is empty";

        public const string BookNameIsRequired = "Book name is required";
        public const string BookAuthorIsRequired = "Book author is required";
        public const string BookPublisherIsRequired = "Book publisher is required";
        public const string BookCategoryIdIsRequired = "Book category id is required";
    }
}
