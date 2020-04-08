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

        public Either<string, (long GameId, long GameStateId)> Create()
        {
            return this.gameEngine.Start();
        }

        public Either<string, long> Start()
        {
            return "Change not allowed";
        }

        public Either<string, FinalGameResult> Finish()
        {
            return "Change not allowed";
        }
    }
}