namespace Test2.Entities
{
    public class Borrowing
    {
        public required int BorrowingId { get; set; }
        public required DateTime BorrowDate { get; set; }
        public required DateTime? ReturnDate { get; set; }
        public required string Status { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; } = null!;
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
    }  
}