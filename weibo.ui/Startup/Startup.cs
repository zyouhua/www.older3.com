using System.Reflection;

using startup;
using platform;

namespace weibo.ui
{
    public class Startup : IStartup
    {
        public void _runStart()
        {
            Assembly assembly = typeof(Startup).Assembly;
            MvcEngineSingleton mvcEngineSingleton_ = __singleton<MvcEngineSingleton>._instance();
            mvcEngineSingleton_._addAssembly(assembly);
        }
    }
}
