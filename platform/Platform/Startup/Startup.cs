using System;
using System.Reflection;

using startup.i;

namespace platform
{
    public class Startup : IStartup
    {
        public void _runInit()
        {
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
    }
}
