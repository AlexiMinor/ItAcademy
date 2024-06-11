using ItAcademy.Database;
using ItAcademy.Database.Entities;
using ItAcademy.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ItAcademy.Services
{
    public class BookService : IBookService
    {
        //private readonly BookStoreContext _context;
        //public BookService (BookStoreContext context)
        //{
        //    _context = context;
        //}

        //public async Task<Book[]> GetBooksAsync(CancellationToken cancellationToken)
        //{
        //    var books = await _context.Books.ToArrayAsync(cancellationToken);
        //    return books;
        //}
    }
}
