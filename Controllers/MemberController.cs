using Test2.DTOs;
using Test2.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExampleTest2.Controllers
{
    [ApiController]
    public class MemberController : ControllerBase // Controllers in Web APIs inherit from ControllerBase, not Controller (which includes View support for MVC)
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [Route("api/members")]
        [HttpGet]
        public async Task<IActionResult> GetAllMembers(string? email)
        {
            var members = await _memberService.GetAllMembersAsync(email);

            if (members == null)
            {
                return NotFound($"No members found");
            }
            return Ok(members);
        }

        [Route("api/borrowings/{id}/return")]
        [HttpPut]
        public async Task<IActionResult> ReturnBook(int id, [FromBody] ReturnBookResponseDTO request)
        {

            var result = await _memberService.ReturnBookAsync(id, request);

            if (result.Equals("BorrowingNotFound"))
            {
                return NotFound();
            }
            if (result.Equals("AlreadyReturned"))
            {
                return Ok("AlreadyReturned");
            }
            else
            {
                return Ok(result);
            }
        }
    }
}