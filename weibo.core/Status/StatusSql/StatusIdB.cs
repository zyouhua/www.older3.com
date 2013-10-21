using platform;

namespace weibo.core
{
    public class StatusIdB : ISqlStream
    {
        public void _runSelect(SqlFormat nSqlFormat)
        {
            nSqlFormat._serialize(ref mAccountMgrId, @"accountMgrId");
            nSqlFormat._serialize(ref mTableId, @"tableId");
        }

        public void _runWhen(SqlFormat nSqlFormat)
        {
        }

        public uint _getAccountMgrId()
        {
            return mAccountMgrId;
        }

        public uint _getTableId()
        {
            return mTableId;
        }

        public StatusIdB()
        {
            mAccountMgrId = 0;
            mTableId = 0;
        }

        uint mAccountMgrId;
        uint mTableId;
    }
}
