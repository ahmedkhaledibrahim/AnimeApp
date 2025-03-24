using AnimeApp.Domain.Interfaces;
using Ardalis.Result;
using AutoMapper;
using MediatR;

namespace AnimeApp.Application.MediatrGenerics
{
    public interface ICommandHandler<TRequest> : IRequestHandler<TRequest, Result> 
        where TRequest : ICommand
    {
    }
    public interface ICommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, Result<TResponse>>
        where TRequest : ICommand<TResponse>
    {
    }
}
