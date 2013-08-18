using System.Collections.Generic;

using platform;
using account.message;

namespace account.core
{
    public class AccountService : PropertySink
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

        public ErrorCode_ _logoutAccount(string nAccountName, long nDeviceId, uint nDeviceType, uint nServerId)
        {
            ErrorCode_ result_ = this._checkServerId(nServerId);
            if (ErrorCode_.mSucess_ == result_)
            {
                uint hashName_ = GenerateId._runTableId(nAccountName);
                AccountConfig accountConfig_ = __singleton<AccountConfig>._instance();
                uint accountMgrCount_ = accountConfig_._getAccountMgrCount();
                uint accountMgrIndex_ = hashName_ % accountMgrCount_;
                AccountMgr accountMgr_ = mAccountMgrs[accountMgrIndex_];
                result_ = accountMgr_._logoutAccount(nAccountName, nDeviceId, nDeviceType);
            }
            return result_;
        }

        public Account _getAccount(string nAccountName, long nDeviceId, uint nDeviceType)
        {
            uint hashName_ = GenerateId._runTableId(nAccountName);
            AccountConfig accountConfig_ = __singleton<AccountConfig>._instance();
            uint accountMgrCount_ = accountConfig_._getAccountMgrCount();
            uint accountMgrIndex_ = hashName_ % accountMgrCount_;
            AccountMgr accountMgr_ = mAccountMgrs[accountMgrIndex_];
            return accountMgr_._getAccount(nAccountName, nDeviceId, nDeviceType);
        }

        public ErrorCode_ _checkServerId(uint nServerId)
        {
            SettingSingleton settingSingleton_ = __singleton<SettingSingleton>._instance();
            uint serverId_ = settingSingleton_._getServerId();
            return (serverId_ == nServerId) ? ErrorCode_.mSucess_ : ErrorCode_.mServerId_;
        }

        public void _runStart()
        {
            this._startAccountMgr();
            this._startSink();
        }

        void _startAccountMgr()
        {
            string accountConfigUrl_ = @"rid://account.core.accountConfig";
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

        void _startSink()
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
