using FluentValidation;
using WebArMa.Application.Abstractions.Mediator;
using WebArMa.Identity.Domain.Helpers;

namespace WebArMa.Identity.Application.Users.CreateUser
{
	public class CreateUserCommandValidator : WebArMaCommandValidation<CreateUserCommand, Guid>
	{
		public CreateUserCommandValidator()
		{
			RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("شماره تماس الزامی است").NotNull().WithMessage("شماره تماس الزامی است")
				.Must(IranianPhoneNumber.IsValid).WithMessage("شماره تماس وارد شده معتبر نمی‌باشد");
		}
	}
}