using platform;
using account.core;

namespace weibo.core
{
    public class Startup : IStartup
    {
        public void _runStart()
        {
            StatusId statusId_ = __singleton<StatusId>._instance();
            statusId_._runStart();

            AccountService accountService_ = __singleton<AccountService>._instance();
            accountService_._registerCreate(statusId_);

            StatusService statusService_ = __singleton<StatusService>._instance();
            statusService_._runStart();
        }
    }
}
