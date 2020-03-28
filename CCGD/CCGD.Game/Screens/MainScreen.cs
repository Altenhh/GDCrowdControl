// Copyright (c) Alten. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using CCGD.Game.Graphics;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using osuTK;

namespace CCGD.Game.Screens
{
    public class MainScreen : Screen
    {
        public MainScreen()
        {
            AddInternal(new SpriteText
            {
                Y = 20,
                Text = "Main Screen",
                Anchor = Anchor.TopCentre,
                Origin = Anchor.TopCentre,
                Font = FontUsage.Default.With(size: 40)
            });
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            var colourScheme = new ColourProvider(313);

            AddInternal(new Box
            {
                Colour = colourScheme.Dark6,
                Size = new Vector2(220)
            });
        }
    }
}
