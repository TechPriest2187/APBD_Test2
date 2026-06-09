

using System.ComponentModel.DataAnnotations;

namespace Test2.Entities;

public class Member
{
    public required int MemberId {get; set;}

    [MaxLength(50)]
    public required string FirstName {get; set;}

    [MaxLength(100)]
    public required string LastName {get; set;}

    [MaxLength(100)]
    public required string Email {get; set;}

    [MaxLength(9)]
    public required string Phone {get; set;}
    public ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}