using Mediator;

namespace WebArMa.Application.Interfaces.Mediator
{
    public interface IWebArMaCommand : IRequest;
    public interface IWebArMaCommand<TResult> : IRequest<TResult>;
}
