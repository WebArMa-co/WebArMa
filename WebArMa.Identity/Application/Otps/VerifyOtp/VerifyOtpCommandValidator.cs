using FluentValidation;
using WebArMa.Application.Abstractions.Mediator;
using WebArMa.Identity.Application.Otps.Dtos;
using WebArMa.Identity.Domain.Helpers;

namespace WebArMa.Identity.Application.Otps.VerifyOtp
{
	public class VerifyOtpCommandValidator : WebArMaCommandValidation<VerifyOtpCommand, VerifyOtpResult>
	{
		public VerifyOtpCommandValidator()
		{
			RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("شماره تماس الزامی است")
				.Must(IranianPhoneNumber.IsValid).WithMessage("شماره تماس وارد شده معتبر نمی‌باشد");

			RuleFor(x => x.Code).NotEmpty().WithMessage("کد تایید الزامی است").NotNull().WithMessage("کد تایید الزامی است")
				.Length(5).WithMessage("کد تایید باید 5 رقم باشد");
		}
	}
}