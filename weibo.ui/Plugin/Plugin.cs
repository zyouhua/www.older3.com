using System.Reflection;

using startup;
using platform;

namespace weibo.ui
{
    public class Plugin : IPlugin
    {
        public void _runLoad()
        {
            Assembly assembly = typeof(Plugin).Assembly;
            MvcEngineSingleton mvcEngineSingleton_ = __singleton<MvcEngineSingleton>._instance();
            mvcEngineSingleton_._addAssembly(assembly);
        }
    }
}
