// Copyright (c) Alten. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using cc.plugin.Base.Actions;
using CC.GD.Service.Actions;

namespace cc.plugin.Base
{
    public class BasePlugin : CCPlugin
    {
        public override string Name => "Base";

        public override IEnumerable<CCAction> GetActions() => new CCAction[]
        {
            new JumpAction(),
            new PracticeAction(),
            new RetryAction(),
            new PauseAction(),
        };
    }
}
