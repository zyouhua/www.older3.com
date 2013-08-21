using platform;

namespace account.core
{
    public class Startup : IStartup
    {
        public void _runStart()
        {
            string sqlUrl_ = @"url://www.wanmei.com/account\account.core/config*sqlConfig.xml";
            SqlSingleton sqlSingleton_ = __singleton<SqlSingleton>._instance();
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            platformSingleton_._loadHeadstream<SqlSingleton>(sqlSingleton_, sqlUrl_);

            AccountService accountService_ = __singleton<AccountService>._instance();
            accountService_._runInit();
        }
    }
}
