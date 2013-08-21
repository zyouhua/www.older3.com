using platform;

namespace account.core
{
    public class AccountConfig : Headstream
    {
        public override void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mAccountMgrCount, @"accountMgrCount");
        }

        public override string _streamName()
        {
            return @"accountConfig";
        }

        public uint _getAccountMgrCount()
        {
            return mAccountMgrCount;
        }

        public AccountConfig()
        {
            mAccountMgrCount = 0;
        }

        uint mAccountMgrCount;
    }
}
