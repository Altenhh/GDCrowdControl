using osu.Framework;
using osu.Framework.Platform;

namespace CCGD.Game.Tests
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableHost("visual-tests"))
            using (var game = new CCGDTestBrowser())
                host.Run(game);
        }
    }
}
