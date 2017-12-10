﻿using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Objects.Containers;

namespace JackSazerak.UWP.GameObjects.Static
{
    public class Background : BaseGameObject
    {
        public Background(string textureName, GameWrapper wrapper) : base(textureName, TILE_TYPE.BACKGROUNDS, wrapper) { }
    }
}