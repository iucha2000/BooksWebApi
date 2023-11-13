using BooksWebApi.Entities;
using BooksWebApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BooksWebApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddBookAsync(Book book)
        {
            book.CreateDate = DateTime.Now;
            book.UpdateDate = DateTime.Now;
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int bookId)
        {
            var book = await _context.FindAsync<Book>(bookId);
            book.IsDeleted = true;
            book.UpdateDate = DateTime.Now;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(int bookId, Book newBook)
        {
            var book = await GetBookByIdAsync(bookId);
            book.Name = newBook.Name;
            book.Author = newBook.Author;
            book.Pages = newBook.Pages;
            book.UpdateDate = DateTime.Now;
            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetBookByIdAsync(int bookId)
        {
            var book = await _context.FindAsync<Book>(bookId);
            return book;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }

        public async Task<IEnumerable<Book>> SearchBookAsync(string keyword)
        {
            var books = await _context.Books.Where(x=> x.Name.Contains(keyword)).ToListAsync();
            return books;
        }

        public async Task<IEnumerable<Book>> GetBooksWithPageNumbersAsync(int pageSize, int pageNum)
        {
            var booksToSkip = (pageNum - 1) * pageSize;
            var books = await _context.Books.Skip(booksToSkip).Take(pageSize).ToListAsync();
            return books;
        }
    }
}
