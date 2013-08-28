using platform;

using account.core;

namespace weibo.core
{
    public class Startup : IStartup
    {
        public void _runStart()
        {
            AccountService accountService_ = __singleton<AccountService>._instance();
            accountService_._registerCreate(new StatusId());

            StatusService statusService_ = __singleton<StatusService>._instance();
            statusService_._runInit();
        }
    }
}
