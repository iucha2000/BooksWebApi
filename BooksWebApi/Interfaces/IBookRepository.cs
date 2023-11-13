using BooksWebApi.Entities;

namespace BooksWebApi.Interfaces
{
    public interface IBookRepository
    {
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(int bookId, Book book);
        Task DeleteBookAsync(int bookId);
        Task<Book> GetBookByIdAsync(int bookId);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<IEnumerable<Book>> SearchBookAsync(string keyword);
        Task<IEnumerable<Book>> GetBooksWithPageNumbersAsync(int pageSize, int pageNum);

    }
}
