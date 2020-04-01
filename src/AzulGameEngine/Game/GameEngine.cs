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

        public GameEngine(Random rnd)
        {
            this.rnd = rnd;
        }

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

        public long Start()
        {
        }
    }
}