using Exiled.API.Interfaces;

namespace SpectatorListRueI
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; }
        public bool Debug { get; set; }
        public float Position { get; set; }
    }
}