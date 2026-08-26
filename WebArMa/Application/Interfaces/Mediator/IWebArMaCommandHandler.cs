using Mediator;

namespace WebArMa.Application.Interfaces.Mediator
{
    public interface IWebArMaCommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : IWebArMaCommand;
    public interface IWebArMaCommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : IWebArMaCommand<TResult>;
}
