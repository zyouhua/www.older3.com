using platform;

namespace weibo.core
{
    public class StatusId : Property
    {
        public void _setTableId(uint nTableId)
        {
            mTableId = nTableId;
        }

        public uint _getTableId()
        {
            return mTableId;
        }

        public StatusId()
        {
            mTableId = 0;
        }

        uint mTableId;
    }
}
