using Microsoft.AspNetCore.Mvc;

namespace BooksWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {

        [HttpPost("create-book")]
        public IActionResult CreateBook(Book book)
        {
            MockDb.Books.Add(book.Id, book);
            return Ok(book);
        }


        [HttpPut("update-book")]
        public IActionResult UpdateBook(Book book)
        {
            MockDb.Books.TryGetValue(book.Id, out var existingBook);
            if(existingBook != null)
            {
                existingBook.Name = book.Name;
                existingBook.Author = book.Author;
                return Ok(book);
            }
            return NotFound();

        }


        [HttpGet("book/{id}")]
        public IActionResult GetBookById(int id)
        {
            MockDb.Books.TryGetValue(id, out var book);
            return book == null ? NotFound() : Ok(book);
        }


        [HttpGet("books")]
        public IActionResult GetAllBooks()
        {
            List<Book> books = MockDb.Books.Values.ToList();
            return Ok(books);
        }


        [HttpDelete("book/{id}")]
        public IActionResult DeleteBook(int id)
        {
            return MockDb.Books.Remove(id) ? Ok() : BadRequest();
        }
    }
}
