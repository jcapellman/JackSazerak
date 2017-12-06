﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Microsoft.Xna.Framework;

using JackSazerak.UWP.Objects.JSONObjects;
using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Objects.Containers;
using JackSazerak.UWP.GameObjects.Aircraft;

namespace JackSazerak.UWP.Objects
{
    public class LevelContainer : BaseObject<Level, LevelContainer>
    {
        public Vector2 Camera { get; set; }

        public List<Text> TextElements { get; set; }

        public List<Tile> Tiles { get; set; }

        public Player CurrentPlayer { get; set; }

        private List<BaseAircraft> GetAllAircraft(GameWrapper gameWrapper) => Assembly.GetExecutingAssembly().GetTypes().Where(a => a.BaseType == typeof(BaseAircraft)).Select(b => (BaseAircraft)Activator.CreateInstance(b, gameWrapper)).ToList();        

        public LevelContainer(Level jsonObject, GameWrapper gameWrapper)
        {
            var aircraft = GetAllAircraft(gameWrapper);

            Tiles = new List<Tile>();

            // Swap out temporary code when level editor is done
            for (var x = 0; x < 100; x++)
            {
                Tiles.Add(new Tile(new LevelTile
                {
                    TileType = TILE_TYPE.TILES,
                    TextureName = "Water",
                    PositionX = 100,
                    PositionY = x * -128,
                    Height = 128,
                    Width = 128
                }, gameWrapper));
            }

            foreach (var tile in jsonObject.Tiles)
            {
                Tiles.Add(new Tile(tile, gameWrapper));
            }

            CurrentPlayer = new Player(aircraft.FirstOrDefault(a => a.Name == jsonObject.CurrentPlayer));

            TextElements = new List<Text>
            {
                new Text(jsonObject.LevelName, Color.White, gameWrapper.ContentManager)
            };
        }
    }
}