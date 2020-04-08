using AzulGameEngine.Game.Models;
using LanguageExt;

namespace AzulGameEngine.Game
{
    public interface IGameState
    {
        Either<string, (long GameId, long GameStateId)> Create();

        Either<string, long> Start();

        Either<string, FinalGameResult> Finish();
    }
}