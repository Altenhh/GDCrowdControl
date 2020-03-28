// Copyright (c) Alten. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using CCGD.Game.Screens;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using osu.Framework.Testing;

namespace CCGD.Game.Tests.Visual
{
    public class TestSceneMainScreen : TestScene
    {
        public TestSceneMainScreen()
        {
            Add(new ScreenStack(new MainScreen()) { RelativeSizeAxes = Axes.Both });
        }
    }
}
