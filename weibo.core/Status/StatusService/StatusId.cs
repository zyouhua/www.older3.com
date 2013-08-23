using platform;

namespace weibo.core
{
    public class StatusId : ISqlStream
    {
        public void _runSelect(SqlFormat nSqlFormat)
        {
            nSqlFormat._serialize(ref mTableId, @"tableId");
            nSqlFormat._serialize(ref mId, @"id");
        }

        public void _runWhen(SqlFormat nSqlFormat)
        {
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
