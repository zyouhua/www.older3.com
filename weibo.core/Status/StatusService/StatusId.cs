using platform;

namespace weibo.core
{
    public class StatusId : Stream, IKeyI64
    {
        public override void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mTableId, @"tableId");
            nSerialize._serialize(ref mId, @"id");
        }

        public long _keyI64()
        {
            return mId;
        }

        public StatusId(uint nTableId, long nId)
        {
            mTableId = nTableId;
            mId = nId;
        }

        public StatusId()
        {
            mTableId = 0;
            mId = 0;
        }

        uint mTableId;
        long mId;
    }
}
