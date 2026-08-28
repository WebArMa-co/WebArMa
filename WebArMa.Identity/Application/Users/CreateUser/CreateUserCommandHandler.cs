using Microsoft.EntityFrameworkCore;
using WebArMa.Application.Contexts;
using WebArMa.Application.Interfaces.Mediator;
using WebArMa.Identity.Domain.Entities;

namespace WebArMa.Identity.Application.Users.CreateUser
{
	public class CreateUserCommandHandler(IWebArMaDbContext dbContext) : IWebArMaCommandHandler<CreateUserCommand, Guid>
	{
		public async ValueTask<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
		{
			var existingUser = await dbContext.Set<User>().FirstOrDefaultAsync(u => u.PhoneNumber == command.PhoneNumber, cancellationToken);

			if (existingUser != null)
			{
				return existingUser.Guid;
			}

			var newUser = User.Create(command.PhoneNumber);
			await dbContext.Set<User>().AddAsync(newUser, cancellationToken);
			await dbContext.SaveChangesAsync(cancellationToken);
			return newUser.Guid;
		}
	}
}
