using platform;

using weibo.message;
using account.core;

namespace weibo.core
{
    public class StatusMgr : Property
    {
        public StatusCreateC _createStatus(StatusCreateS nStatusCreateS)
        {
            StatusService statusService_ = __singleton<StatusService>._instance();
            Account account_ = this._getPropertyMgr<Account>();
            AccountMgr accountMgr_ = account_._getAccountMgr();
            StatusId statusId_ = accountMgr_._getProperty<StatusId>(statusService_._getId());
            return this._createStatus(statusId_._getTableId(), nStatusCreateS);
        }

        StatusCreateC _createStatus(uint nTableId, StatusCreateS nStatusCreateS)
        {
            return null;
        }
    }
}
