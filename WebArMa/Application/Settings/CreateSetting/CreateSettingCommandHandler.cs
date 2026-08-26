using Microsoft.EntityFrameworkCore;
using WebArMa.Application.Contexts;
using WebArMa.Application.Interfaces.Mediator;
using WebArMa.Domain.Entities;

namespace WebArMa.Application.Settings.CreateSetting
{
    public class CreateSettingCommandHandler(IWebArMaDbContext dbContext) : IWebArMaCommandHandler<CreateSettingCommand, Guid>
    {
        public async ValueTask<Guid> Handle(CreateSettingCommand command, CancellationToken cancellationToken)
        {
            var checkSettingIsAlreadyExist = await dbContext.Settings.FirstOrDefaultAsync(s => s.Key == command.Key, cancellationToken: cancellationToken);

            if (checkSettingIsAlreadyExist != null)
            {
                dbContext.Settings.Remove(checkSettingIsAlreadyExist);
            }

            var newSetting = Setting.Create(command.Key, command.Type, command.Section, command.Value);
            await dbContext.Settings.AddAsync(newSetting, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            return newSetting.Guid;
        }
    }
}
