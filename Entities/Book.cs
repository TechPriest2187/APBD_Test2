using System.ComponentModel.DataAnnotations;

namespace Test2.Entities;

public class Book
{
    public int BookId {get; set;}

    [MaxLength(200)]
    public required string Title {get; set;}

    [MaxLength(13)]
    public required string ISBN {get; set;}
    public required int PublishedYear {get; set;}
    public required int AuthorsId {get; set;}
    public required Author Author {get; set;} = null!;
    public ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}