using platform;

namespace account.core
{
    public class Startup : IStartup
    {
        public void _runStart()
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();

            string sqlUrl_ = @"rid://account.core.sqlConfig";
            SqlSingleton sqlSingleton_ = __singleton<SqlSingleton>._instance();
            platformSingleton_._loadHeadstream<SqlSingleton>(sqlSingleton_, sqlUrl_);

            string accountServiceUrl_ = @"rid://account.core.accountService";
            AccountService accountService_ = __singleton<AccountService>._instance();
            platformSingleton_._loadHeadstream<AccountService>(accountService_, accountServiceUrl_);
            accountService_._runInit();

            DeviceService deviceService_ = __singleton<DeviceService>._instance();
            deviceService_._runInit();
        }
    }
}
