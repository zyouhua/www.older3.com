using platform;
using account.core;

namespace weibo.core
{
    public class Plugin : IPlugin
    {
        public void _runLoad()
        {
            AccountCreator accountCreator_ = __singleton<AccountCreator>._instance();
            accountCreator_._registerCreate(new PropertyId<StatusMgr>());
            
            StatusService statusService_ = __singleton<StatusService>._instance();
            statusService_._runPreinit();

            AccountService accountService_ = __singleton<AccountService>._instance();
            accountService_._registerCreate(statusService_);
        }
    }
}
