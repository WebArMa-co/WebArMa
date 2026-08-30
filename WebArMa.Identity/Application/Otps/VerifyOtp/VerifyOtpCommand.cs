using WebArMa.Application.Interfaces.Mediator;
using WebArMa.Identity.Application.Otps.Dtos;

namespace WebArMa.Identity.Application.Otps.VerifyOtp
{
	public sealed class VerifyOtpCommand(string phoneNumber, string code) : IWebArMaCommand<VerifyOtpResult>
	{
		public string PhoneNumber { get; private set; } = phoneNumber;
		public string Code { get; private set; } = code;
	}
}