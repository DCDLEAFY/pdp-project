using Application.Mediatr.Response;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediatr.Request;
public class UpdateGameRequest : IRequest<UpdateGameResponse>
{
    private readonly int _id;
    private readonly GameDto _game;

    public UpdateGameRequest(int Id, GameDto Game)
    {
        _id = Id;
        _game = Game;
    }

    public int Id => _id;
    public GameDto Game => _game;
}