// Copyright (c) Alten. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using Crowd.Control.GD;
using Crowd.Control.GD.Actions;
using osu.Framework.Bindables;

namespace cc.plugin.Base.Actions
{
    public class PauseAction : CCAction
    {
        public override string Name => "Pause";

        public override BindableInt Price => new BindableInt(500);

        public override void Execute()
        {
            Click(GDButtonsLocation.Pause);
        }
    }
}
