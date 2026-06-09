using System.ComponentModel.DataAnnotations;

namespace Test2.DTOs;

public class ReturnBookResponseDTO
{
    [Required]
    [MaxLength(50)]
    public DateTime ReturnDate { get; set; }
}