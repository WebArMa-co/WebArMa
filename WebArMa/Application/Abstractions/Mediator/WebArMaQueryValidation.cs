using FluentValidation;
using WebArMa.Application.Interfaces.Mediator;

namespace WebArMa.Application.Abstractions.Mediator
{
    public abstract class WebArMaQueryValidation<TRequest, TResult> : AbstractValidator<TRequest> where TRequest : IWebArMaQuery<TResult>;
}
