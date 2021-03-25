using LightDesktop.Activities;

namespace LightDesktop.Core
{
    public class LightDesktopCore
    {

        private static readonly MainActivity mainActivity = new MainActivity();

        public static void Launch(string[] args)
        {
            Renderer.DXInit(960, 540);
            mainActivity.Launch();
        }
    }
}
