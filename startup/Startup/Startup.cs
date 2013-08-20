using System.IO;
using System.Web;
using System.Reflection;
using System.Web.Hosting;

using platform;

[assembly: PreApplicationStartMethod(typeof(startup.Startup), "_runStart")]
namespace startup
{
    public class Startup
    {
        public static void _runStart()
        {
            _initMvcEngine();
            _initApp();
            _startApp();
            _startMvcEngine();
        }

        static void _initMvcEngine()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(MvcApplication));
            MvcEngineSingleton mvcEngineSingleton_ = __singleton<MvcEngineSingleton>._instance();
            mvcEngineSingleton_._addAssembly(assembly);
        }

        static void _startMvcEngine()
        {
            MvcEngineSingleton mvcEngineSingleton_ = __singleton<MvcEngineSingleton>._instance();
            mvcEngineSingleton_._runMvcEngine();
        }

        static void _initApp()
        {
            string systemPath_ = HostingEnvironment.MapPath(@"~");
            systemPath_ = Path.Combine(systemPath_, @"../../bin/platform");
            SettingSingleton settingSingleton_ = __singleton<SettingSingleton>._instance();
            settingSingleton_._runInit(systemPath_);
        }

        static void _startApp()
        {
            string appUrl_ = @"local://";
            appUrl_ += HostingEnvironment.MapPath(@"~\platform\appUrls.xml");
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            platformSingleton_._startApp(appUrl_);
        }
    }
}
