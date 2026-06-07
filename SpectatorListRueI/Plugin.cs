using System;
using Exiled.API.Features;

namespace SpectatorListRueI
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance {get; private set;}
        
        public override string Name { get; } = "SpectatorListRueI";
        public override string  Author { get; } = "polyshed.";
        public override Version Version { get; } = new Version(0, 0, 1);
        public override Version RequiredExiledVersion { get; } = new Version(9, 14, 2);

        private EventHandler _handler;

        public override void OnEnabled()
        {
            base.OnEnabled();
            
            Instance = this;
            _handler = new EventHandler();
        }

        public override void OnDisabled()
        {
            
            base.OnDisabled();
            
            _handler = null;
            Instance = null;
        }
    }
}