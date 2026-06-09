namespace Test2.DTOs;

public class MembersResponseDTO
{
    public string FirstName {get; set;} = "";
    public string LastName {get; set;} = "";
    public string Email {get; set;} = "";
    public string Phone {get; set;} = "";
    public List<BorrowingDTO> Borrowings { get; set; } = new();
}

public class BorrowingDTO
{
        public int BorrowingId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; } = "";
        public BookDTO Book { get; set; } = null!;
}

public class BookDTO
{
    public int BookId {get; set;}
    public required string Title {get; set;}
    public required string ISBN {get; set;}
    public required int PublishedYear {get; set;}
    public required AuthorDTO Author {get; set;} = null!;
}

public class AuthorDTO
{
    public string FirstName {get; set;} = "";
    public string LastName {get; set;} = "";
    public string Country {get; set;} = "";
}