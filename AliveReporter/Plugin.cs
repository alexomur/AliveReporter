using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using MEC;
using PlayerRoles;
using Server = Exiled.Events.Handlers.Server;

namespace AliveReporter
{
    public sealed class Plugin : Plugin<Config>
    {
        public override string Author => "DrBright";
        public override string Name => "AliveReporter";
        public override Version Version => new Version("0.1.0");

        public override string Prefix => Name;

        public static Plugin Instance;


        private EventHandler _handlers;
        

        public override void OnEnabled()
        {
            Instance = this;
            RegisterEvents();
            base.OnEnabled();
            
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            Instance = null;

            base.OnDisabled();
        }
        
        private void RegisterEvents()
        {
            _handlers = new EventHandler();
            Server.RoundStarted += _handlers.OnRoundStarted;
            Server.RoundEnded += _handlers.OnRoundEnded;
        }

        private void UnregisterEvents()
        {
            Server.RoundStarted -= _handlers.OnRoundStarted;
            Server.RoundEnded -= _handlers.OnRoundEnded;
            _handlers = null;
        }
    }
}