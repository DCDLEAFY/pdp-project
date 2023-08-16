using Application.Mediatr.Request;
using Application.Mediatr.Response;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediatr.Handler;
public class UpdateGameHandler : IRequestHandler<UpdateGameRequest, UpdateGameResponse>
{
    private readonly IGameService _gameService;

    public UpdateGameHandler(IGameService GameService)
    {
        _gameService = GameService;
    }

    public async Task<UpdateGameResponse> Handle(UpdateGameRequest request, CancellationToken cancellationToken)
    {
        var result = _gameService.UpdateGameFromStoreById(request.Id, request.Game);

        if(result.Result == null)
        {
            return new UpdateGameResponse(false, result.Result);
        }

        return new UpdateGameResponse(true, result.Result);
    }
}