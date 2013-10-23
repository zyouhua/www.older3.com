using System.IO;
using System.Web;
using System.Reflection;
using System.Web.Hosting;

using platform;

[assembly: PreApplicationStartMethod(typeof(startup.Startup), "_runLoad")]
namespace startup
{
    public static class Startup
    {
        public static void _runLoad()
        {
            _initMvcEngine();
            _configPlugin();
            _loadPlugin();
            _startMvcEngine();
        }

        public static void _runStart()
        {
            InitService initService_ = __singleton<InitService>._instance();
            if (null != initService_.m_tRunInit)
            {
                initService_.m_tRunInit();
            }
            if (null != initService_.m_tRunStart)
            {
                initService_.m_tRunStart();
            }
        }

        public static void _runQuit()
        {
            InitService initService_ = __singleton<InitService>._instance();
            if (null != initService_.m_tRunSave)
            {
                initService_.m_tRunSave();
            }
            if (null != initService_.m_tRunExit)
            {
                initService_.m_tRunExit();
            }
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

        static void _configPlugin()
        {
            string systemPath_ = HostingEnvironment.MapPath(@"~");
            systemPath_ = Path.Combine(systemPath_, @"../../bin/platform");
            SettingSingleton settingSingleton_ = __singleton<SettingSingleton>._instance();
            settingSingleton_._runConfig(systemPath_);
        }

        static void _loadPlugin()
        {
            string pluginUrl_ = @"local://";
            pluginUrl_ += HostingEnvironment.MapPath(@"~\platform\pluginUrls.xml");
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            platformSingleton_._loadPlugin(pluginUrl_);
        }
    }
}
