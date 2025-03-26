using AnimeApp.Application.MediatrGenerics;
using AnimeApp.Domain.Entities;
using AnimeApp.Domain.Interfaces;
using Ardalis.Result;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.Features.AnimeShows.Commands.Delete
{
    public class DeleteAnimeShowHandler(IUnitOfWork unitOfWork, IMapper mapper): ICommandHandler<AnimeShow, DeleteAnimeShowCommand, bool>(unitOfWork,mapper)
    {
        

        public async override Task<Result<bool>> Handle(DeleteAnimeShowCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var animeShow = await _unitOfWork.GetRepository<AnimeShow>().GetByIdAsync(request.Id);
                if (animeShow == null)
                {
                    return Result.NotFound("Anime Show With ID " + request.Id + " Not Found");
                }
                await _unitOfWork.GetRepository<AnimeShow>().DeleteByIdAsync(request.Id);
                await _unitOfWork.SaveChangesAsync();

                return Result.Success(true);
            }
            catch (ArgumentException ex)
            {
               return Result.Error(ex.Message);

            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }
}
