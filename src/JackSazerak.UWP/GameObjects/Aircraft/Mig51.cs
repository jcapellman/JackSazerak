﻿using JackSazerak.UWP.Objects.Containers;

namespace JackSazerak.UWP.GameObjects.Aircraft
{
    public class Mig51 : BaseAircraft
    {
        public Mig51(GameWrapper wrapper) : base("Mig51", wrapper)
        {
        }

        public override string Name => "Mig51";

        protected override int AgilityHorizontal => 50;

        protected override int AgilityVertical => 50;
    }
}