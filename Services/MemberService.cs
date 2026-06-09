using Test2.Data;
using Test2.DTOs;
using Test2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace Test2.Services
{
    public interface IMemberService
    {
        // Returns an OrderResponseDto if found, or null if not.
        // The controller checks for null to return a 404 Not Found, otherwise returns 200 OK with the DTO.
        Task<MembersResponseDTO?> GetAllMembersAsync(string? email);

        // Returns a string representing the outcome of the operation ("Success", "OrderNotFound", etc.).
        // The controller uses a switch statement on this string to determine the correct HTTP status code (200, 400, or 404).
        Task<DateTime> ReturnBookAsync(int id, ReturnBookResponseDTO request);
    }

    public class MemberService : IMemberService
    {
        private readonly DBContext _context;

        public MemberService(DBContext context)
        {
            _context = context;
        }

        public async Task<MembersResponseDTO?> GetAllMembersAsync(string? email)
        {

            var members = await _context.Members
                .Where(x => x.Email == email)
                .Select(m => new MembersResponseDTO
                {
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    Email = m.Email,
                    Phone = m.Phone,
                    Borrowings = m.Borrowings.Select(b => new BorrowingDTO
                    {
                        BorrowingId = b.BorrowingId,
                        BorrowDate = b.BorrowDate,
                        ReturnDate = b.ReturnDate,
                        Status = b.Status,
                        Book = new BookDTO
                        {
                            BookId = b.Book.BookId,
                            Title = b.Book.Title,
                            ISBN = b.Book.ISBN,
                            PublishedYear = b.Book.PublishedYear,
                            Author = new AuthorDTO
                            {
                                FirstName = b.Book.Author.FirstName,
                                LastName = b.Book.Author.LastName,
                                Country = b.Book.Author.Country
                            }
                        }
                    }).ToList()
                }).FirstOrDefaultAsync();

            if (members == null) return null;
            
            return members;
        }

        public async Task<string> ReturnBookAsync(int id, ReturnBookResponseDTO request)
        {
            var borrowing = await _context.Borrowings
                .FirstOrDefaultAsync(o => o.BorrowingId == id);

            if (borrowing == null) return "BorrowingNotFound"; 

            if (borrowing.ReturnDate.HasValue) return "AlreadyReturned"; 

            borrowing.Status = "Returned";

            var now = DateTime.Now;
            borrowing.ReturnDate = now; 

            await _context.SaveChangesAsync();

            return now.ToString();
        }

        Task<DateTime> IMemberService.ReturnBookAsync(int id, ReturnBookResponseDTO request)
        {
            throw new NotImplementedException();
        }
    }
}