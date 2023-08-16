using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediatr.Response;
public class UpdateGameResponse
{
    private readonly bool _isSuccesful;
    private readonly Game? _game;

    public UpdateGameResponse(bool IsSuccesful, Game Game)
    {
        _isSuccesful = IsSuccesful;
        _game = Game;
    }

    public bool IsSuccesful => _isSuccesful;
    public Game? Game => _game;
}