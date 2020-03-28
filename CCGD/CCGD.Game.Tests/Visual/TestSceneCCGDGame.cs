using System;
using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Platform;
using osu.Framework.Testing;

namespace CCGD.Game.Tests.Visual
{
    public class TestSceneCCGDGame : TestScene
    {
        // Add visual tests to ensure correct behaviour of your game: https://github.com/ppy/osu-framework/wiki/Development-and-Testing
        // You can make changes to classes associated with the tests and they will recompile and update immediately.

        private CCGDGame game;

        public override IReadOnlyList<Type> RequiredTypes => new[]
        {
            typeof(CCGDGame),
        };

        [BackgroundDependencyLoader]
        private void load(GameHost host)
        {
            game = new CCGDGame();
            game.SetHost(host);

            Add(game);
        }
    }
}
