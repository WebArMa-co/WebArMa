using FluentValidation;
using WebArMa.Application.Abstractions.Mediator;

namespace WebArMa.Application.Settings.CreateSetting
{
    public class CreateSettingCommandValidator : WebArMaValidation<CreateSettingCommand, Guid>
    {
        public CreateSettingCommandValidator()
        {
            RuleFor(x => x.Key).NotEmpty().WithMessage("شناسه تنظیمات نباید خالی باشد").NotNull().WithMessage("شناسه تنظیمات نباید خالی باشد");
            RuleFor(x => x.Type).NotEmpty().WithMessage("نوع تنظیمات نباید خالی باشد").NotNull().WithMessage("نوع تنظیمات نباید خالی باشد");
            RuleFor(x => x.Section).NotEmpty().WithMessage("بخش تنظیمات نباید خالی باشد").NotNull().WithMessage("بخش تنظیمات نباید خالی باشد");
        }
    }
}
