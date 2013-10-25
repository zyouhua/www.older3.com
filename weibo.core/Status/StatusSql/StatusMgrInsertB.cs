using System;
using System.Text;

using platform;
using account.core;
using weibo.message;

namespace weibo.core
{
    public class StatusMgrInsertB : ISqlHeadstream
    {
        public void _runSelect(ISqlFormat nSqlFormat)
        {
            nSqlFormat._serialize(ref mAccountId, @"accountId");
            nSqlFormat._serialize(ref mTicks, @"ticks");
            nSqlFormat._serialize(ref mBytes, @"statusIds");
        }

        public void _runWhere(ISqlFormat nSqlFormat)
        {
        }

        public string _tableName()
        {
            return string.Format(@"statusMgr_{0}", mAccountMgrId);
        }

        public SqlType_ _sqlType()
        {
            return SqlType_.mUpdateInsert_;
        }

        public StatusMgrInsertB(StatusMgr nStatusMgr)
        {
            Account account_ = nStatusMgr._getPropertyMgr<Account>();
            AccountMgr accountMgr_ = account_._getAccountMgr();
            mAccountMgrId = accountMgr_._getAccountMgrId();
            mAccountId = account_._getAccountId();
            mTicks = account_._getTicks();
            mBytes = Encoding.UTF8.GetBytes(nStatusMgr._getStrStatusIds());
        }

        uint mAccountMgrId;
        uint mAccountId;
        long mTicks;
        byte[] mBytes;
    }
}
