using LanguageExt;

namespace AzulGameEngine.Game
{
    public interface IGameState
    {
        Either<string, (long GameId, long GameStateId)> Start();
    }
}