using System;
using System.Collections.Generic;
using AzulGameEngine.Game.Models;
using LanguageExt;

namespace AzulGameEngine.Game
{
    public interface IGameState
    {
        int NumberOfPlayers { get; }

        ICollection<PlayerModel> GetPlayers();

        Either<string, long> AddPlayer(string playerName);

        Either<string, (long GameId, long GameStateId)> Create();

        Either<string, long> Start();

        Either<string, FinalGameResult> Finish();
    }
}