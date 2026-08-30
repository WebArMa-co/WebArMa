using FluentValidation;
using WebArMa.Application.Abstractions.Mediator;
using WebArMa.Identity.Domain.Helpers;

namespace WebArMa.Identity.Application.Otps.RequestOtp
{
	public class RequestOtpCommandValidator : WebArMaCommandValidation<RequestOtpCommand, bool>
	{
		public RequestOtpCommandValidator()
		{
			RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("شماره تماس الزامی است").NotNull().WithMessage("شماره تماس الزامی است")
				.Must(IranianPhoneNumber.IsValid).WithMessage("شماره تماس وارد شده معتبر نمی‌باشد");
		}
	}
}