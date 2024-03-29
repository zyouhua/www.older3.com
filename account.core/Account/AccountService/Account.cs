﻿using System;
using System.Collections.Generic;

using platform;
using account.message;

namespace account.core
{
    public class Account : PropertyMgr
    {
        public ErrorCode_ _checkErrorCode(long nDeviceId, uint nDeviceType)
        {
            ErrorCode_ result_ = ErrorCode_.mSucess_;
            DeviceStatus deviceStatus_ = this._getDeviceStatus(nDeviceType);
            if (null == deviceStatus_)
            {
                result_ = ErrorCode_.mDeviceType_;
            }
            if ((null != deviceStatus_) && (deviceStatus_._getId() != nDeviceId))
            {
                result_ = ErrorCode_.mDeviceId_;
            }
            return result_;
        }

        public ErrorCode_ _logout(long nDeviceId, uint nDeviceType)
        {
            ErrorCode_ result_ = ErrorCode_.mSucess_;
            DeviceStatus deviceStatus_ = this._getDeviceStatus(nDeviceType);
            if (null == deviceStatus_)
            {
                result_ = ErrorCode_.mDeviceType_;
            }
            if ((null != deviceStatus_) && (deviceStatus_._getId() != nDeviceId))
            {
                result_ = ErrorCode_.mDeviceId_;
            }
            if (ErrorCode_.mSucess_ == result_)
            {
                mDeviceStatus.Remove(nDeviceType);
            }
            return result_;
        }

        public bool _isOnline()
        {
            return (mDeviceStatus.Count > 0);
        }

        public void _addDeviceType(uint nDeviceType)
        {
            long id_ = GenerateId._runId(@"account");
            DeviceStatus deviceStatus_ = new DeviceStatus(id_, nDeviceType);
            mDeviceStatus[nDeviceType] = deviceStatus_;
        }

        public DeviceStatus _getDeviceStatus(uint nDeviceType)
        {
            DeviceStatus result_ = null;
            if (mDeviceStatus.ContainsKey(nDeviceType))
            {
                result_ = mDeviceStatus[nDeviceType];
            }
            return result_;
        }

        public void _setAccountMgr(AccountMgr nAccountMgr)
        {
            mAccountMgr = nAccountMgr;
        }

        public AccountMgr _getAccountMgr()
        {
            return mAccountMgr;
        }

        public void _setNick(string nNick)
        {
            mNick = nNick;
        }

        public string _getNick()
        {
            return mNick;
        }

        public void _setTicks(long nTicks)
        {
            mTicks = nTicks;
        }

        public long _getTicks()
        {
            return mTicks;
        }

        public void _setAccountId(uint nAccountId)
        {
            mAccountId = nAccountId;
        }

        public uint _getAccountId()
        {
            return mAccountId;
        }

        public _RunSlot m_tRunLogin;
        public _RunSlot m_tRunLogout;

        public Account()
        {
            mDeviceStatus = new Dictionary<uint, DeviceStatus>();
            mAccountMgr = null;
            m_tRunLogin = null;
            m_tRunLogout = null;
            mNick = null;
            mAccountId = 0;
            mTicks = 0;
        }

        Dictionary<uint, DeviceStatus> mDeviceStatus;
        AccountMgr mAccountMgr;
        uint mAccountId;
        string mNick;
        long mTicks;
    }
}
