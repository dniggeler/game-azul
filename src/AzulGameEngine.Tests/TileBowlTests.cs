using System;
using AzulGameEngine.Game.Models;
using FluentAssertions;
using LanguageExt;
using Xunit;


namespace AzulGameEngine.Tests
{
    [Trait("Game Engine", "TileBowl")]
    public class TileBowlTests
    {
        [Fact(DisplayName = "Add Tile to Bowl")]
        public void ShouldAddTileToBowl()
        {
            // given
            TileBowl bowl = new TileBowl();
            Tile newTile = new BlueTile();

            // when
            bowl.AddTile(newTile);

            // then
            bowl.IsEmpty.Should().BeFalse();
        }

        [Fact(DisplayName = "Remove Tile from Bowl")]
        public void ShouldRemoveTileFromBowl()
        {
            // given
            TileBowl bowl = new TileBowl();
            Tile newTile = new BlueTile();

            // when
            bowl.AddTile(newTile);
            var tile = bowl.RemoveTile<BlueTile>();

            // then
            bowl.IsEmpty.Should().BeTrue();
            tile.IsSome.Should().BeTrue();
        }
    }
}
