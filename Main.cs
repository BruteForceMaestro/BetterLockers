using Exiled.API.Features;
using System;
using Server = Exiled.Events.Handlers.Server;

namespace BetterLockers
{
    public class Main : Plugin<Config>
    {
        EventHandlers handlers;
        public override string Author => "nutmaster#4861";
        public override Version Version => new Version(1, 1, 2);
        public override Version RequiredExiledVersion => new Version(4, 2, 3);

        public override void OnEnabled()
        {
            handlers = new EventHandlers(this);
            Server.RoundStarted += handlers.OnRoundStart;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Server.RoundStarted -= handlers.OnRoundStart;
            handlers = null;
            base.OnDisabled();
        }
    }
}