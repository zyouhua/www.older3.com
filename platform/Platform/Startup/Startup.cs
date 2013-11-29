using System;
using System.Reflection;

using startup.i;

namespace platform
{
    public class Startup : IStartup
    {
        public void _runInit()
        {
            this._initAssemblyLoad();
            this._configPlugin();
            this._loadPlugin();
        }

        public void _runStart()
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

        public void _runQuit()
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

        void _configPlugin()
        {
        }

        void _loadPlugin()
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            platformSingleton_._loadPlugin();
        }

        void _initAssemblyLoad()
        {
            AppDomain appdomain_ = AppDomain.CurrentDomain;
            appdomain_.AssemblyResolve += _assemblyLoad;
        }

        static Assembly _assemblyLoad(object source, ResolveEventArgs e)
        {
            AppDomain appDomain_ = AppDomain.CurrentDomain;
            Assembly[] assemblies_ = appDomain_.GetAssemblies();
            foreach (Assembly i in assemblies_)
            {
                if (string.Compare(i.FullName, e.Name) == 0)
                {
                    return i;
                }
            }
            return null;
        }
    }
}
