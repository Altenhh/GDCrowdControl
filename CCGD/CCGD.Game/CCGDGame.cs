using CCGD.Game.Screens;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Screens;
using osuTK.Graphics;

namespace CCGD.Game
{
    public class CCGDGame : CCGDGameBase
    {
        private ScreenStack screenStack;

        [BackgroundDependencyLoader]
        private void load()
        {
            Children = new Drawable[]
            {
                new Box
                {
                    Colour = new Color4(0f, 1f, 0f, 1f),
                    RelativeSizeAxes = Axes.Both
                },
                screenStack = new ScreenStack { RelativeSizeAxes = Axes.Both }
            };
        }

        protected override void LoadComplete()
        {
            screenStack.Push(new MainScreen());

            base.LoadComplete();
        }
    }
}
