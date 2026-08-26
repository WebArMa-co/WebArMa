using FluentValidation;
using WebArMa.Application.Interfaces.Mediator;

namespace WebArMa.Application.Abstractions.Mediator
{
    public abstract class WebArMaValidation<TRequest, TResult> : AbstractValidator<TRequest> where TRequest : IWebArMaCommand<TResult>;
}
