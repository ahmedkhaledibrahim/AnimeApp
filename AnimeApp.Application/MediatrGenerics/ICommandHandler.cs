using AnimeApp.Domain.Entities.Common;
using AnimeApp.Domain.Interfaces;
using Ardalis.Result;
using AutoMapper;
using MediatR;

namespace AnimeApp.Application.MediatrGenerics
{
    public abstract class ICommandHandler<TEntity, TRequest, TResponse> : IRequestHandler<TRequest, Result<TResponse>>
        where TRequest : ICommand<TResponse>
        where TEntity : BaseEntity
    {
        protected readonly IMapper _mapper;
        protected readonly IGenericRepository<TEntity> _repository;
        protected readonly IUnitOfWork _unitOfWork;

        public ICommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<TEntity>();
            _mapper = mapper;
        }

        public abstract Task<Result<TResponse>> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
