using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using AzulGameEngine.Game.Models;
using LanguageExt;

namespace AzulGameEngine.Game
{
    public class GameEngine
    {
        private readonly Random rnd;

        private readonly ConcurrentDictionary<string, PlayerModel> players =
            new ConcurrentDictionary<string, PlayerModel>();

        private readonly Dictionary<int,TileBowl> tileBowls = new Dictionary<int, TileBowl>();

        public GameEngine(Random rnd)
        {
            this.rnd = rnd;
        }

        public int NumberOfPlayers => players.Count;

        public ICollection<PlayerModel> GetPlayers()
        {
            return players.Values;
        }

        public Either<string, long> AddPlayer(string playerName)
        {
            if (players.ContainsKey(playerName))
            {
                return "Player already exist";
            }

            if (players.Count == GameConfiguration.MaxPlayers)
            {
                return "Game is full with players";
            }

            var newPlayer = players.AddOrUpdate(
                playerName,
                name => new PlayerModel
                {
                    Id = rnd.Next(),
                    Name = name,
                    JoinedAt = DateTime.Now
                }, 
                (_, p) => p);

            return newPlayer.Id;
        }

        public Either<string,(long GameId, long GameStateId)> Start()
        {

            long stateId = 0;
            long gameId = rnd.Next();

            for (int ii = 0; ii < GameConfiguration.NumberOfTileBowls(NumberOfPlayers); ii++)
            {
                tileBowls.Add(ii, new TileBowl());
            }

            return (gameId, stateId);
        }
    }
}