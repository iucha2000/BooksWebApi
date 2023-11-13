namespace BooksWebApi.DTOs
{
    public class BookOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public bool IsDeleted { get; set; }
    }
}
