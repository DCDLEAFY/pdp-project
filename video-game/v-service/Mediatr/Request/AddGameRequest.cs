using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Mediatr.Response;
using Domain.Models;
using MediatR;

namespace Application.Mediatr.Request;

public class AddGameRequest : IRequest<AddGameResponse>
{
    private readonly GameDto _game;

    public AddGameRequest(GameDto Game)
    {
        _game = Game;
    }

    public GameDto Game => _game;
}