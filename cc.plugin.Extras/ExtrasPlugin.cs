// Copyright (c) Alten. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using cc.plugin.Extras.Actions;
using CC.GD.Service.Actions;

namespace cc.plugin.Extras
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
