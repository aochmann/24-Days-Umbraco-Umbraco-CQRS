using System.Threading.Tasks;
using CleanArchitecture.MembersRegistration.Application.Queries;
using CleanArchitecture.SharedAbstractions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.MembersRegistration.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public MemberController(IQueryDispatcher queryDispatcher)
            => _queryDispatcher = queryDispatcher;

        public ActionResult<TResult> OkOrNotFound<TResult>(TResult result)
            => result is not null
                ? Ok(result)
                : NotFound();

        [HttpGet("{email}")]
        public async ValueTask<ActionResult<string>> Get([FromRoute] GetMemberByEmail query)
        {
            var member = await _queryDispatcher.QueryAsync(query);

            return OkOrNotFound(member?.Name ?? "Error");
        }
    }
}