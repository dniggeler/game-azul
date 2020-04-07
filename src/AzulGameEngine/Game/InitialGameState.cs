using AzulGameEngine.Game.Models;
using LanguageExt;

namespace AzulGameEngine.Game
{
    public class InitialGameState : IGameState
    {
        private readonly GameEngine gameEngine;

        public InitialGameState(GameEngine gameEngine)
        {
            this.gameEngine = gameEngine;
        }

        public Either<string, (long GameId, long GameStateId)> Start()
        {
            return this.gameEngine.Start();
        }
    }
}