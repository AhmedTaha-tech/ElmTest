namespace Elm.Books.Domain.Models.Books
{
    public class BooksData
    {
        public long BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookDescription { get; set; }
        public string Author { get; set; }
        public string CoverBase64 { get; set; }
        public string PublishDate { get; set; }
        public DateTime LastModified { get; set; }
    }
}
