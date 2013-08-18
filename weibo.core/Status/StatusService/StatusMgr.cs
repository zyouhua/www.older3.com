using platform;

using weibo.message;
using account.core;

namespace weibo.core
{
    public class StatusMgr : Property
    {
        public StatusCreateC _createStatus(StatusCreateS nStatusCreateS)
        {
            AccountService accountService_ = __singleton<AccountService>._instance();
            Account account_ = this._getPropertyMgr<Account>();
            AccountMgr accountMgr_ = account_._getAccountMgr();

            return null;
        }
    }
}
