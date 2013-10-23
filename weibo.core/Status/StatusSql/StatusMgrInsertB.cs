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
            mAccountMgrId = accountMgr_._getId();
            mAccountId = account_._getAccountId();
            mBytes = Encoding.UTF8.GetBytes(nStatusMgr._getStrStatusIds());
        }

        uint mAccountMgrId;
        uint mAccountId;
        byte[] mBytes;
    }
}
