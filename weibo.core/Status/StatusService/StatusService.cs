using platform;
using account.core;
using weibo.message;

namespace weibo.core
{
    public class StatusService
    {
        public StatusCreateC _createStatus(StatusCreateS nStatusCreateS)
        {
            AccountService accountService_ = __singleton<AccountService>._instance();
            Account account_ = accountService_._getAccount(nStatusCreateS.m_tName, 
                nStatusCreateS.m_tDeviceId, nStatusCreateS.m_tDeviceType);
            uint propertyId_ = StatusId._classId();
            StatusMgr statusMgr_ = account_._getProperty<StatusMgr>(propertyId_);
            return statusMgr_._createStatus(nStatusCreateS);
        }

        public void _runStart()
        {
            this._startSink();
        }

        void _startSink()
        {
            StatusSink statusSink_ = __singleton<StatusSink>._instance();
            statusSink_.m_tStatusCreate += _createStatus;
        }
    }
}
