using System.ComponentModel.DataAnnotations;

namespace Test2.Entities
{
    public class Review
    {
        public required int MemberId { get; set; }
        public required Member Member { get; set; } = null!;
        public required int BookId { get; set; }
        public required Book Book { get; set; } = null!;
        public required int Rating { get; set; }

        [MaxLength(500)]
        public string Comment { get; set; } = "";
        public required DateTime ReviewDate { get; set; }
    }  
}