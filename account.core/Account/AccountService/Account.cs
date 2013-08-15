using System;
using System.Collections.Generic;

using platform;

namespace account.core
{
    public class Account
    {
        public void _addDeviceType(uint nDeviceType)
        {
            ulong id_ = GenerateId._runId(@"account");
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

        public Account()
        {
            mDeviceStatus = new Dictionary<uint, DeviceStatus>();
            mNick = null;
            mAccountId = 0;
            mTicks = 0;
        }

        Dictionary<uint, DeviceStatus> mDeviceStatus;
        uint mAccountId;
        string mNick;
        long mTicks;
    }
}
