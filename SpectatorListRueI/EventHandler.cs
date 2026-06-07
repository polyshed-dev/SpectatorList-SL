using Exiled.Events;
using Exiled.Events.Handlers;
using Exiled.Events.Features;
using System;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using RueI.API;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace SpectatorListRueI
{
    public class EventHandler
    {
        private static Config _config => Plugin.Instance.Config;

        public EventHandler()
        {
            Exiled.Events.Handlers.Player.Verified += OnVerified;
        }

        ~EventHandler()
        {
            Exiled.Events.Handlers.Player.Verified -= OnVerified;
        }
        
        

        private void OnVerified(VerifiedEventArgs ev)
        {
            RueDisplay display = RueDisplay.Get(ev.Player);
            
        }

        private void UpdateSpectators()
        {
            foreach (Exiled.API.Features.Player player in Exiled.API.Features.Player.List)
            {
                if (player.IsDead == true) continue;
                
                int spectatorCount = player.CurrentSpectatingPlayers.Count(p => p.Role != RoleTypeId.Overwatch);
                
                
            }
        }

    }
}