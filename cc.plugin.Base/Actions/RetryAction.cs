// Copyright (c) Alten. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Threading;
using Crowd.Control.GD;
using Crowd.Control.GD.Actions;
using osu.Framework.Bindables;

namespace cc.plugin.Base.Actions
{
    public class RetryAction : CCAction
    {
        public override string Name => "Retry";

        public override BindableInt Price => new BindableInt(1000);

        public override void Execute()
        {
            Click(GDButtonsLocation.Pause);
            Thread.Sleep(10);
            Click(GDButtonsLocation.Retry);
        }
    }
}
