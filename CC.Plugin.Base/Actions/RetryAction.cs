// Copyright (c) Alten. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using CC.GD.Service.Actions;

namespace CC.Plugin.Base.Actions
{
    public class RetryAction : CCAction
    {
        public override string Name => "Retry";

        public override int Price => 1000;

        public override void Start()
        {
        }
    }
}
