﻿using platform;

namespace account.message
{
    public class AccountLoginC
    {
        public ErrorCode_ m_tErrorCode { get; set; }
        public uint m_tAccountId { get; set; }
        public uint m_tServerId { get; set; }
        public long m_tTicks { get; set; }
        public ulong m_tDeviceStatusId { get; set; }
        public uint m_tDeviceStatusType { get; set; }
    }
}
