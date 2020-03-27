// Copyright (c) Alten. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Threading;
using Crowd.Control.GD;
using Crowd.Control.GD.Actions;
using osu.Framework.Bindables;

namespace cc.plugin.Base.Actions
{
    public class PracticeAction : CCAction
    {
        public override string Name => "Practice";

        public override BindableInt Price => new BindableInt(900);

        public override void Execute()
        {
            Console.WriteLine("hello?");

            Click(GDButtonsLocation.Pause);
            Thread.Sleep(10);
            Click(GDButtonsLocation.Practice);
        }
    }
}
