// Copyright (c) Alten. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using CC.GD.Service.Actions;

namespace cc.plugin.Extras.Actions
{
    public class HoldAction : CCAction
    {
        public override string Name => "Hold button";

        public override int Price => 2000;

        public override int Length => 5000;

        public override void Start()
        {
            throw new System.NotImplementedException();
        }
    }
}
