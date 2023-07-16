namespace BooksWebApi
{
    public static class MockDb
    {
        public static Dictionary<int, Book> Books { get; set; }

        static MockDb()
        {
            Books = new Dictionary<int, Book>();
        }
    }
}
