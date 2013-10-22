using System.IO;
using System.Reflection;
using System.Web.Hosting;

using platform;

namespace startup
{
    public class Startup
    {
        public void _runLoad()
        {
            this._initMvcEngine();
            this._configPlugin();
            this._loadPlugin();
        }

        public void _runInit()
        {
            InitService initService_ = __singleton<InitService>._instance();
            initService_.m_tRunInit();
            initService_.m_tRunStart();
        }

        public void _runStart()
        {
            this._startMvcEngine();
        }

        public void _runQuit()
        {
            InitService initService_ = __singleton<InitService>._instance();
            initService_.m_tRunSave();
            initService_.m_tRunExit();
        }

        void _initMvcEngine()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(MvcApplication));
            MvcEngineSingleton mvcEngineSingleton_ = __singleton<MvcEngineSingleton>._instance();
            mvcEngineSingleton_._addAssembly(assembly);
        }

        void _startMvcEngine()
        {
            MvcEngineSingleton mvcEngineSingleton_ = __singleton<MvcEngineSingleton>._instance();
            mvcEngineSingleton_._runMvcEngine();
        }

        void _configPlugin()
        {
            string systemPath_ = HostingEnvironment.MapPath(@"~");
            systemPath_ = Path.Combine(systemPath_, @"../../bin/platform");
            SettingSingleton settingSingleton_ = __singleton<SettingSingleton>._instance();
            settingSingleton_._runConfig(systemPath_);
        }

        void _loadPlugin()
        {
            string pluginUrl_ = @"local://";
            pluginUrl_ += HostingEnvironment.MapPath(@"~\platform\pluginUrls.xml");
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            platformSingleton_._loadPlugin(pluginUrl_);
        }


    }
}
