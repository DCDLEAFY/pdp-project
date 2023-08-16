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
public class AddGameHandler : IRequestHandler<AddGameRequest, AddGameResponse>
{
    private readonly IGameService _gameService;

    public AddGameHandler(IGameService GameService)
    {
        _gameService = GameService;
    }

    public async Task<AddGameResponse> Handle(AddGameRequest request, CancellationToken cancellationToken)
    {
        var result = _gameService.AddGameToStore(request.Game);
        
        if (result.Result == null)
        {
            return new AddGameResponse(false ,result.Result);
        }

        return new AddGameResponse(true, result.Result);
    }
}