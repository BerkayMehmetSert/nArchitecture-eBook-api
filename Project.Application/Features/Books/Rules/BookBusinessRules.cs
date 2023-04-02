using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using core.Application.Rules;
using Core.CrossCuttingConcers.Exceptions;
using Core.Persistence.Paging;
using static Project.Application.Features.Books.Constants.BookMessages;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;

namespace Project.Application.Features.Books.Rules
{
    public class BookBusinessRules : BaseBusinessRules
    {
        private readonly IBookRepository _bookRepository;

        public BookBusinessRules(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task CheckIfBookNameIsUnique(string name)
        {
            var book = _bookRepository.GetAsync(x => x.Name == name);
            if (book != null) throw new BusinessException(BookNameAlreadyExists);
        }

        public void CheckIfBookListIsEmpty(IPaginate<Book> books)
        {
            if (books.Items != null && books.Items.Count == 0) throw new BusinessException(BookListIsEmpty);
        }

        public async Task<Book> CheckIfBookExistsByIdReturnBook(int id)
        {
            var book = await _bookRepository.GetAsync(x => x.Id == id);

            if (book == null) throw new BusinessException(BookNotFound);

            return book;
        }

    }
}
