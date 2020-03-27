// Copyright (c) Alten. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using CC.GD.Service.Actions;
using osu.Framework.Bindables;

namespace cc.plugin.Extras.Actions
{
    public class MainMenuAction : CCAction
    {
        public override string Name => "Go to Main Menu";

        public override BindableInt Price => new BindableInt(7000);

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
