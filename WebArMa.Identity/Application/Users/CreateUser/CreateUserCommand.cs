using WebArMa.Application.Interfaces.Mediator;

namespace WebArMa.Identity.Application.Users.CreateUser
{
    public sealed class CreateUserCommand(string phoneNumber) : IWebArMaCommand<Guid>
    {
        public string PhoneNumber { get; private set; } = phoneNumber; /*Since FirstName, LastName, and DisplayName are all optional and set later via CompleteProfile(not at creation), they don't belong on the creation command — keeping it phone-only mirrors what's actually required to create a User.*/
    }
}