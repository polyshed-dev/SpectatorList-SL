using Exiled.API.Interfaces;

namespace SpectatorListRueI
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public float Position { get; set; } = 0F;
        public string Spectators { get; set; } = "👥 Spectators (%amount%)";
        public string PlayerDisplay { get; set; } = "-> %name%";
        public string FullText { get; set; } = "<size=23><align=right>%display%</size></align>";
        public float RefreshRate { get; set; } = 2F;
        public int MaximumLines { get; set; } = 6;
        public string OverflowText { get; set; } = "%overflow% more...";
    }
}