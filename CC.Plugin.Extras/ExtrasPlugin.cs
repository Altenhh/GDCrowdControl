using System.Collections.Generic;
using CC.GD.Service.Actions;
using CC.Plugin.Extras.Actions;

namespace CC.Plugin.Extras
{
    public class ExtrasPlugin : CCPlugin
    {
        public override string Name => "Extras";

        public override IEnumerable<CCAction> GetActions() => new CCAction[]
        {
            new HoldAction(),
            new MuteAction(),
            new KillAction(),
            new GameRateAction(),
            new MainMenuAction()
        };
    }
}
