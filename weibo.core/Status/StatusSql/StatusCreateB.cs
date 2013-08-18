using System;

using platform;

namespace weibo.core
{
    public class StatusCreateB : ISqlHeadstream
    {
        public void _runSelect(ISqlFormat nSqlFormat)
        {
            throw new NotImplementedException();
        }

        public void _runWhere(ISqlFormat nSqlFormat)
        {
            throw new NotImplementedException();
        }

        public string _tableName()
        {
            throw new NotImplementedException();
        }

        public SqlType_ _sqlType()
        {
            return SqlType_.mInsert_;
        }
    }
}
