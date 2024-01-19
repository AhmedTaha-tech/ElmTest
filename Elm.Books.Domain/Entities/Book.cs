namespace Elm.Books.Domain.Entities
{
    public class Book
    {
        public long BookId { get; set; }
        public string BookInfo { get; set; }
        public DateTime LastModified { get; set; }
    }
}
