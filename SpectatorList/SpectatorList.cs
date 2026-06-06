using System;
using Exiled.API.Features;

namespace SpectatorList
{
    public class SpectatorList : Plugin<Config>
    {
        public static SpectatorList Instance { get; private set; }

        public override string Name { get; } = "Spectator List";
        public override string Author { get; } = "polyshed";
        public override Version Version { get; } = new Version(1,2,0);
        public override Version RequiredExiledVersion { get; } = new Version(9, 14, 2);

        private EventHandler _handler;

        public override void OnEnabled()
        {
            Instance = this;
            _handler = new EventHandler();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            _handler = null;
            Instance = null;

            base.OnDisabled();
        }
    }
}