// Copyright (c) Alten. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using CC.GD.Service.Actions;
using osu.Framework.Bindables;

namespace cc.plugin.Base.Actions
{
    public class JumpAction : CCAction
    {
        public override string Name => "Jump";

        public override BindableInt Price => new BindableInt(100);

        public override void Execute()
        {
            Click();
        }
    }
}
