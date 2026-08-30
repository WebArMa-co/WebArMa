using WebArMa.Application.Interfaces.Mediator;
using WebArMa.Identity.Application.Tokens.Dtos;

namespace WebArMa.Identity.Application.Tokens.CreateToken
{
	public sealed class CreateTokenCommand(int userId) : IWebArMaCommand<CreateTokenResultDto>
	{
		public int UserId { get; private set; } = userId;
	}
}