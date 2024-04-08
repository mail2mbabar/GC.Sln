
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
            private readonly IMemberRepository _memberRepository;

            public MemberController(IMemberRepository memberRepository)
            {
                _memberRepository = memberRepository;
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Member>> GetMember(int id)
            {
                var member = await _memberRepository.GetMemberByIdAsync(id);

                if (member == null)
                {
                    return NotFound();
                }

                return member;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
            {
                var members = await _memberRepository.GetAllMembersAsync();
                return members;
            }

            [HttpPost]
            public async Task<ActionResult<Member>> PostMember(Member member)
            {
                await _memberRepository.AddMemberAsync(member);
                return CreatedAtAction(nameof(GetMember), new { id = member.MemberId }, member);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutMember(Guid id, Member member)
            {
                if (id != member.MemberId)
                {
                    return BadRequest();
                }

                await _memberRepository.UpdateMemberAsync(member);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteMember(int id)
            {
                await _memberRepository.DeleteMemberAsync(id);
                return NoContent();
            }
        }
    }
