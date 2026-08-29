using FluentValidation;
using WebArMa.Application.Interfaces.Mediator;

namespace WebArMa.Application.Abstractions.Mediator
{
    public abstract class WebArMaCommandValidation<TRequest, TResult> : AbstractValidator<TRequest> where TRequest : IWebArMaCommand<TResult>;
}
