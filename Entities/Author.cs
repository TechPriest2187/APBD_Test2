using System.ComponentModel.DataAnnotations;

namespace Test2.Entities;

public class Author
{
    public int AuthorId {get; set;}

    [MaxLength(50)]
    public required string FirstName {get; set;}

    [MaxLength(100)]
    public required string LastName {get; set;}

    [MaxLength(100)]
    public required string Email {get; set;}

    [MaxLength(50)]
    public required string Country {get; set;}
    public required int BirthYear {get; set;}
}