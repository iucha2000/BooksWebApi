using AutoMapper;
using BooksWebApi.DTOs;
using BooksWebApi.Entities;
using BooksWebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace BooksWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }


        [HttpPost("create-book")]
        public async Task<IActionResult> CreateBook(BookInputDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            await _bookRepository.AddBookAsync(book);
            return Ok(_mapper.Map<BookOutputDTO>(book));
        }


        [HttpPost("update-book")]
        public async Task<IActionResult> UpdateBook(int bookId, BookInputDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            await _bookRepository.UpdateBookAsync(bookId, book);
            book.Id = bookId;
            return Ok(_mapper.Map<BookOutputDTO>(book));
        }


        [HttpGet("book/{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            var result = _mapper.Map<BookOutputDTO>(book);
            return Ok(result);
        }


        [HttpGet("books")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            var results = _mapper.Map<List<BookOutputDTO>>(books.ToList());
            return Ok(results);
        }


        [HttpGet("books/{pageSize}/{pageNumber}")]
        public async Task<IActionResult> GetBooksWithPageNumbers(int pageSize, int pageNumber)
        {
            var books = await _bookRepository.GetBooksWithPageNumbersAsync(pageSize, pageNumber);
            var results = _mapper.Map<List<BookOutputDTO>>(books.ToList());
            return Ok(results);
        }


        [HttpGet("search/{keyword}")]
        public async Task<IActionResult> SearchBook(string keyword)
        {
            var books = await _bookRepository.SearchBookAsync(keyword);
            var results = _mapper.Map<List<BookOutputDTO>>(books.ToList());
            return Ok(results);
        }


        [HttpDelete("book/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookRepository.DeleteBookAsync(id);
            return Ok();
        }
    }
}
