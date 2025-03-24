using Ardalis.Result;
using MediatR;

namespace AnimeApp.Application.MediatrGenerics
{
    public interface ICommand : IRequest<Result>
    {
    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>> { }
}
