// Copyright (c) Alten. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using CC.GD.Service.Actions;
using osu.Framework.Bindables;

namespace cc.plugin.Extras.Actions
{
    public class MuteAction : CCAction
    {
        public override string Name => "Mute game";

        public override BindableInt Price => new BindableInt(700);

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
