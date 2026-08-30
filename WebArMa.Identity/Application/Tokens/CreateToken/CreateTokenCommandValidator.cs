using FluentValidation;
using WebArMa.Application.Abstractions.Mediator;
using WebArMa.Identity.Application.Tokens.Dtos;

namespace WebArMa.Identity.Application.Tokens.CreateToken
{
	public class CreateTokenCommandValidator : WebArMaCommandValidation<CreateTokenCommand, CreateTokenResultDto>
	{
		public CreateTokenCommandValidator()
		{
			RuleFor(x => x.UserId).GreaterThan(0).WithMessage("کاربر معتبر نمی‌باشد");
		}
	}
}