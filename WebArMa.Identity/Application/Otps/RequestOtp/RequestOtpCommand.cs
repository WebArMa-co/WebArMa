using WebArMa.Application.Interfaces.Mediator;

namespace WebArMa.Identity.Application.Otps.RequestOtp
{
	public sealed class RequestOtpCommand(string phoneNumber) : IWebArMaCommand<bool>
	{
		public string PhoneNumber { get; private set; } = phoneNumber;
	}
}