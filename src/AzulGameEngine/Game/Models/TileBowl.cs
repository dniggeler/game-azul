using System;
using System.Linq;
using LanguageExt;

namespace AzulGameEngine.Game.Models
{
    public class TileBowl
    {
        private const int MaxTiles = 4;

        private Lst<Tile> tiles;

        public TileBowl()
        {
        }

        public bool IsEmpty => tiles.IsEmpty;

        public void AddTile<T>(T tile) where T : Tile
        {
            if (tiles.Count == MaxTiles)
            {
                throw new ArgumentException($"Maximum number of tiles ({MaxTiles}) reaches");
            }

            tiles = tiles.Add(tile);
        }

        public Option<T> RemoveTile<T>() where T : Tile
        {
            if (tiles.IsEmpty)
            {
                return Option<T>.None;
            }

            var r = tiles.OfType<T>().Find(t => t != null);

            r.IfSome(t => tiles = tiles.Remove(t));

            return r;
        }
    }
}