using System;
using System.Linq;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using Exiled.API.Features;
using RueI.API.Elements;
using System.Text;
using RueI.API;

namespace SpectatorListRueI
{
    public class EventHandler
    {
        private readonly DynamicElement _spectatorElement;
        private Config _config => Plugin.Instance.Config;
        private static readonly Tag tagSpectator = new("SpectatorListElement");
        
        public EventHandler()
        {
            Exiled.Events.Handlers.Player.Verified += OnVerified;
            
            _spectatorElement = new DynamicElement(Plugin.Instance.Config.Position, (hub =>
            {
                Player player = Player.Get(hub);
                int count = player.CurrentSpectatingPlayers.Count(p => p.Role != RoleTypeId.Overwatch);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(count == 0
                    ? String.Empty
                    : _config.Spectators.Replace("%amount%", count.ToString()));
                
                int iteration = 0;
                foreach (Player spectator in player.CurrentSpectatingPlayers.Where(p => p.Role != RoleTypeId.Overwatch))
                {
                    sb.AppendLine(_config.PlayerDisplay.Replace("%name%", spectator.CustomName));
                    iteration++;

                    if (iteration > _config.MaximumLines)
                    {
                        int overflowCount = count - _config.MaximumLines;
                        sb.AppendLine(_config.OverflowText.Replace("%overflow%", overflowCount.ToString()));
                        break;
                    }
                }

                return _config.FullText.Replace("%display%", sb.ToString());
            }))
            {
                UpdateInterval = TimeSpan.FromSeconds(_config.RefreshRate)
            };
        }

        ~EventHandler()
        {
            Exiled.Events.Handlers.Player.Verified -= OnVerified;
        }

        private void OnVerified(VerifiedEventArgs ev)
        {
            RueDisplay display = RueDisplay.Get(ev.Player);
            display.Show(tagSpectator, _spectatorElement, _config.RefreshRate);
        }
        
    }
}