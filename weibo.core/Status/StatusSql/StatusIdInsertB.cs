using System;
using System.Collections.Generic;

using platform;
using account.core;

namespace weibo.core
{
    public class StatusIdInsertB : ISqlHeadstream
    {
        public void _runSelect(ISqlFormat nSqlFormat)
        {
            nSqlFormat._serialize(ref mStatusIdBs, @"statusIdBs");
        }

        public void _runWhere(ISqlFormat nSqlFormat)
        {
        }

        public string _tableName()
        {
            return @"statusId";
        }

        public SqlType_ _sqlType()
        {
            return SqlType_.mInsertUpdate_;
        }

        public StatusIdInsertB()
        {
            mStatusIdBs = new List<StatusIdB>();
        }

        List<StatusIdB> mStatusIdBs;
    }
}
