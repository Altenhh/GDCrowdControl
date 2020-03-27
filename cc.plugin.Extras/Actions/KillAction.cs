﻿// Copyright (c) Alten. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using Crowd.Control.GD.Actions;
using osu.Framework.Bindables;

namespace cc.plugin.Extras.Actions
{
    public class KillAction : CCAction
    {
        public override string Name => "Kill player";

        public override BindableInt Price => new BindableInt(9000);

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
