using System.Collections.Concurrent;
using AzulGameEngine.Game.Models;
using LanguageExt;


namespace AzulGameEngine.Game
{
    public class PlayerList
    {
        private readonly ConcurrentDictionary<long, PlayerModel> players =
            new ConcurrentDictionary<long, PlayerModel>();

        public Either<string, bool> Add(PlayerModel player)
        {
            if (players.ContainsKey(player.Id))
            {
                return "Player already exist";
            }

            if (players.Count == GameConfiguration.MaxPlayers)
            {
                return "Game is full of players";
            }

            players.AddOrUpdate(
                player.Id,
                id => player,
                (_, p) => p);

            return true;
        }
    }
}
