using FluentValidation;
using WebArMa.Application.Abstractions.Mediator;

namespace WebArMa.Application.Settings.CreateSetting
{
    public class CreateSettingCommandValidator : WebArMaCommandValidation<CreateSettingCommand, Guid>
    {
        public CreateSettingCommandValidator()
        {
            RuleFor(x => x.Key).NotEmpty().WithMessage("شناسه تنظیمات الزامی است").NotNull().WithMessage("شناسه تنظیمات الزامی است")
                .MinimumLength(3).WithMessage("ورود حداقل 3 حرف برای شناسه تنظیمات الزامی است");
            RuleFor(x => x.Type).NotEmpty().WithMessage("نوع تنظیمات الزامی است").NotNull().WithMessage("نوع تنظیمات الزامی است")
                .MinimumLength(3).WithMessage("ورود حداقل 3 حرف برای نوع تنظیمات الزامی است"); ;
            RuleFor(x => x.Section).NotEmpty().WithMessage("بخش تنظیمات الزامی است").NotNull().WithMessage("بخش تنظیمات الزامی است")
                .MinimumLength(3).WithMessage("ورود حداقل 3 حرف برای بخش تنظیمات الزامی است"); ;
        }
    }
}
