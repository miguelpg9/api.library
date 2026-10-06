namespace api.library.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Isbn { get; set; } = string.Empty;
    public int PublicationYear { get; set; }
    public string? Publisher { get; set; } = string.Empty;
    public string? Genre { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public ICollection<Author> Authors { get; set; } = new List<Author>();
}