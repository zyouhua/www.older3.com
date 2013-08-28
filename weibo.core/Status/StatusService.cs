using platform;
using account.core;
using weibo.message;

namespace weibo.core
{
    public class StatusService
    {
        public ErrorCode_ _createStatus(StatusCreateS nStatusCreateS)
        {
            AccountService accountService_ = __singleton<AccountService>._instance();
            return ErrorCode_.mSucess_;
        }

        public void _runInit()
        {
            this._initSink();
        }

        void _initSink()
        {
            StatusSink statusSink_ = __singleton<StatusSink>._instance();
            statusSink_.m_tStatusCreate += _createStatus;
        }
    }
}
