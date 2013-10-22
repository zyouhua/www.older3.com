using System;

using platform;

namespace weibo.core
{
    public class StatusCreateB : ISqlHeadstream
    {
        public void _runSelect(ISqlFormat nSqlFormat)
        {
        }

        public void _runWhere(ISqlFormat nSqlFormat)
        {
        }

        public string _tableName()
        {
            return null;
        }

        public SqlType_ _sqlType()
        {
            return SqlType_.mInsert_;
        }
    }
}
