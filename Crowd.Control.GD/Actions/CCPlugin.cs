// Copyright (c) Alten. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;

namespace Crowd.Control.GD.Actions
{
    public abstract class CCPlugin
    {
        public int Id;

        public abstract string Name { get; }

        public abstract IEnumerable<CCAction> GetActions();
    }
}
