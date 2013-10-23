using System;
using System.Text;

using platform;
using account.core;
using weibo.message;

namespace weibo.core
{
    public class StatusMgrSelectB : ISqlHeadstream
    {
        public void _runSelect(ISqlFormat nSqlFormat)
        {
            nSqlFormat._serialize(ref mBytes, @"statusIds");
        }

        public void _runWhere(ISqlFormat nSqlFormat)
        {
            nSqlFormat._serialize(ref mAccountId, @"WHERE accountId=");
        }

        public string _tableName()
        {
            return string.Format(@"statusMgr_{0}", mAccountMgrId);
        }

        public SqlType_ _sqlType()
        {
            return SqlType_.mSelect_;
        }

        public string _getString()
        {
            string result_ = null;
            if (null != mBytes)
            {
                result_ = Encoding.UTF8.GetString(mBytes);
            }
            return result_;
        }

        public StatusMgrSelectB(StatusMgr nStatusMgr)
        {
            Account account_ = nStatusMgr._getPropertyMgr<Account>();
            AccountMgr accountMgr_ = account_._getAccountMgr();
            mAccountMgrId = accountMgr_._getId();
            mAccountId = account_._getAccountId();
            mBytes = null;
        }

        uint mAccountMgrId;
        uint mAccountId;
        byte[] mBytes;
    }
}
