using osu.Framework.Platform;
using osu.Framework;
using CCGD.Game;

namespace CCGD.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableHost(@"CCGD"))
            using (osu.Framework.Game game = new CCGDGame())
                host.Run(game);
        }
    }
}
