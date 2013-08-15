﻿using System;
using System.Collections.Generic;

using platform;
using account.message;

namespace account.core
{
    public class AccountMgr
    {
        public ErrorCode_ _createAccount(string nAccountName, string nNickname, string nPassward)
        {
            SqlQuery sqlQuery_ = new SqlQuery();
            sqlQuery_._addHeadstream(new AccountCreateB(nAccountName, nNickname, nPassward, mId));
            SqlSingleton mySqlSingleton_ = __singleton<SqlSingleton>._instance();
            return _getErrorCode(mySqlSingleton_._runSqlQuery(sqlQuery_));
        }

        public AccountLoginC _loginAccount(string nAccountName, string nPassward, uint nDeviceType)
        {
            SettingSingleton settingSingleton_ = __singleton<SettingSingleton>._instance();
            AccountLoginC result_ = new AccountLoginC();
            result_.m_tServerId = settingSingleton_._getServerId();
            result_.m_tErrorCode = this._checkErrorCode(nDeviceType);
            if (ErrorCode_.mSucess_ == result_.m_tErrorCode)
            {
                this._loginAccountLoginB(nAccountName, nPassward, nDeviceType, result_);
            }
            return result_;
        }

        void _loginAccountLoginB(string nAccountName, string nPassward, uint nDeviceType, AccountLoginC nAccountLoginC)
        {
            AccountLoginB accountLoginB_ = new AccountLoginB(nAccountName, mId);
            SqlQuery sqlQuery_ = new SqlQuery();
            sqlQuery_._addHeadstream(accountLoginB_);
            SqlSingleton mySqlSingleton_ = __singleton<SqlSingleton>._instance();
            SqlErrorCode_ sqlErrorCode_ = mySqlSingleton_._runSqlQuery(sqlQuery_, accountLoginB_);
            nAccountLoginC.m_tErrorCode = this._checkErrorCode(sqlErrorCode_, nPassward, accountLoginB_);
            if (ErrorCode_.mSucess_ == nAccountLoginC.m_tErrorCode)
            {
                this._loginAccount(accountLoginB_, nDeviceType, nAccountLoginC);
            }
        }

        void _loginAccount(AccountLoginB nAccountLoginB, uint nDeviceType, AccountLoginC nAccountLoginC)
        {
            Account account_ = this._loginAccount(nAccountLoginB, nDeviceType);
            nAccountLoginC.m_tAccountId = account_._getAccountId();
            nAccountLoginC.m_tTicks = account_._getTicks();
            DeviceStatus deviceStatus_ = account_._getDeviceStatus(nDeviceType);
            nAccountLoginC.m_tDeviceStatusId = deviceStatus_._getId();
            nAccountLoginC.m_tDeviceStatusType = deviceStatus_._getType();
        }

        Account _loginAccount(AccountLoginB nAccountLoginB, uint nDeviceType)
        {
            Account result_ = null;
            uint accountId = nAccountLoginB._getAccountId();
            if (mAccounts.ContainsKey(accountId))
            {
                result_ = mAccounts[accountId];
            }
            if (null == result_)
            {
                result_ = nAccountLoginB._createAccount();
                result_._addDeviceType(nDeviceType);
                mAccounts[accountId] = result_;
            }
            return result_;

        }

        ErrorCode_ _checkErrorCode(SqlErrorCode_ nSqlErrorCode, string nPassward, AccountLoginB nAccountLoginB)
        {
            ErrorCode_ result_ = this._getErrorCode(nSqlErrorCode);
            if (result_ == ErrorCode_.mSucess_)
            {
                result_ = nAccountLoginB._checkPassward(nPassward);
            }
            return result_;
        }

        ErrorCode_ _checkErrorCode(uint nDeviceType)
        {
            return this._checkDevice(nDeviceType);
        }
        
        ErrorCode_ _getErrorCode(SqlErrorCode_ nSqlErrorCode)
        {
            ErrorCode_ result_ = ErrorCode_.mSucess_;
            if (SqlErrorCode_.mFail_ == nSqlErrorCode)
            {
                result_ = ErrorCode_.mFail_;
            }
            return result_;
        }

        ErrorCode_ _checkDevice(uint nDeviceType)
        {
            ErrorCode_ result_ = ErrorCode_.mSucess_;
            DeviceService deviceMgr_ = __singleton<DeviceService>._instance();
            if (!deviceMgr_._contain(nDeviceType))
            {
                result_ = ErrorCode_.mDevice_;
            }
            return result_;
        }

        public AccountMgr(uint nId)
        {
            mAccounts = new Dictionary<uint, Account>();
            mId = 0;
        }

        Dictionary<uint, Account> mAccounts;
        uint mId;
    }
}