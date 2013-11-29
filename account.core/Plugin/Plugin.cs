using platform;
using startup.i;

namespace account.core
{
    public class Plugin : IPlugin
    {
        public void _runLoad()
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();

            string sqlUrl_ = @"rid://account.core.sqlConfig";
            SqlSingleton sqlSingleton_ = __singleton<SqlSingleton>._instance();
            platformSingleton_._loadHeadstream<SqlSingleton>(sqlSingleton_, sqlUrl_);

            AccountService accountService_ = __singleton<AccountService>._instance();
            accountService_._runPreinit();

            DeviceService deviceService_ = __singleton<DeviceService>._instance();
            deviceService_._runPreinit();
        }
    }
}
