namespace platform
{
    public class DeviceStatus
    {
        public void _setType(uint nType)
        {
            mType = nType;
        }

        public uint _getType()
        {
            return mType;
        }

        public void _setId(uint nId)
        {
            mId = nId;
        }

        public long _getId()
        {
            return mId;
        }

        public long m_tId
        {
            get { return mId; }
            set { mId = value; }
        }

        public uint m_tType
        {
            get { return mType; }
            set { mType = value; }
        }

        public DeviceStatus(long nId, uint nType)
        {
            mId = nId;
            mType = nType;
        }

        public DeviceStatus()
        {
            mId = 0;
            mType = 0;
        }

        long mId;
        uint mType;
    }
}
