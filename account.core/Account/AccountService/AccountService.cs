using System.Collections.Generic;

using platform;
using account.message;

namespace account.core
{
    public class AccountService
    {
        public ErrorCode_ _createAccount(string nAccountName, string nNickname, string nPassward)
        {
            uint hashName_ = GenerateId._runTableId(nAccountName);
            AccountConfig accountConfig_ = __singleton<AccountConfig>._instance();
            uint accountMgrCount_ = accountConfig_._getAccountMgrCount();
            uint accountMgrIndex_ = hashName_ % accountMgrCount_;
            AccountMgr accountMgr_ = mAccountMgrs[accountMgrIndex_];
            return accountMgr_._createAccount(nAccountName, nNickname, nPassward);
        }

        public AccountLoginC _loginAccount(string nAccountName, string nPassward, uint nDeviceType)
        {
            uint hashName_ = GenerateId._runTableId(nAccountName);
            AccountConfig accountConfig_ = __singleton<AccountConfig>._instance();
            uint accountMgrCount_ = accountConfig_._getAccountMgrCount();
            uint accountMgrIndex_ = hashName_ % accountMgrCount_;
            AccountMgr accountMgr_ = mAccountMgrs[accountMgrIndex_];
            return accountMgr_._loginAccount(nAccountName, nPassward, nDeviceType);
        }

        public ErrorCode_ _logoutAccount(string nAccountName, ulong nDeviceId, uint nDeviceType)
        {
            uint hashName_ = GenerateId._runTableId(nAccountName);
            AccountConfig accountConfig_ = __singleton<AccountConfig>._instance();
            uint accountMgrCount_ = accountConfig_._getAccountMgrCount();
            uint accountMgrIndex_ = hashName_ % accountMgrCount_;
            AccountMgr accountMgr_ = mAccountMgrs[accountMgrIndex_];
            return accountMgr_._logoutAccount(nAccountName, nDeviceId, nDeviceType);
        }

        public void _runInit()
        {
            this.initAccountMgr();
            this._initSink();
        }

        void initAccountMgr()
        {
            string accountConfigUrl_ = @"rid://account.core.accoutConfig";
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            AccountConfig accountConfig_ = __singleton<AccountConfig>._instance();
            platformSingleton_._loadHeadstream<AccountConfig>(accountConfig_, accountConfigUrl_);

            uint accountMgrCount_ = accountConfig_._getAccountMgrCount();
            for (uint i = 0; i < accountMgrCount_; ++i)
            {
                AccountMgr accountMgr_ = new AccountMgr(i);
                mAccountMgrs[i] = accountMgr_;
            }
        }

        void _initSink()
        {
            AccountSink accountSink_ = __singleton<AccountSink>._instance();
            accountSink_.m_tAccountCreate += _createAccount;
            accountSink_.m_tAccountLogin += _loginAccount;
            accountSink_.m_tAccountLogout += _logoutAccount;
        }

        public AccountService()
        {
            mAccountMgrs = new Dictionary<uint, AccountMgr>();
        }

        Dictionary<uint, AccountMgr> mAccountMgrs;
    }
}
