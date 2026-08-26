using Mediator;

namespace WebArMa.Application.Interfaces.Mediator
{
    public interface IWebArMaQueryHandler<in TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IWebArMaQuery<TResult>;
}
