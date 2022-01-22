using Exiled.API.Features;
using System;
using Server = Exiled.Events.Handlers.Server;

namespace BetterLockers
{
    public class Main : Plugin<Config>
    {
        EventHandlers handlers = new();
        public override string Author => "nutmaster#4861";
        public override Version Version => new Version(1, 1, 1);
        public override Version RequiredExiledVersion => new Version(4, 2, 3);
        public static Main Instance { get; set; }

        public override void OnEnabled()
        {
            Instance = this;
            handlers = new();
            Server.RoundStarted += handlers.OnRoundStart;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            handlers = null;
            Server.RoundStarted -= handlers.OnRoundStart;
            base.OnDisabled();
        }
    }
}