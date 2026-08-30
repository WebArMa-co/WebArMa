using FluentValidation;
using WebArMa.Application.Abstractions.Mediator;
using WebArMa.Application.Dtos;
using WebArMa.Identity.Application.Users.Dtos;

namespace WebArMa.Identity.Application.Users.GetUserList
{
	public class GetUserListCommandValidator : WebArMaCommandValidation<GetUserListCommand, PagedResult<UserDto>>
	{
		public GetUserListCommandValidator()
		{
			RuleFor(x => x.PageNumber).GreaterThan(0).WithMessage("شماره صفحه باید بزرگتر از صفر باشد");
			RuleFor(x => x.PageSize).GreaterThan(0).LessThanOrEqualTo(100).WithMessage("تعداد آیتم در صفحه باید بین 1 تا 100 باشد");
			RuleFor(x => x.Search).MaximumLength(200).When(x => !string.IsNullOrWhiteSpace(x.Search)).WithMessage("عبارت جستجو نمی‌تواند بیشتر از 200 کاراکتر باشد");
		}
	}
}