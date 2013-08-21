using System;

using platform;

namespace account.core
{
    public class AccountCreateB : ISqlHeadstream
    {
        public void _runSelect(ISqlFormat nSqlFormat)
        {
            nSqlFormat._serialize(ref mAccountId, @"accountId");
            nSqlFormat._serialize(ref mAccountName, @"accountName");
            nSqlFormat._serialize(ref mNickName, @"nickName");
            nSqlFormat._serialize(ref mPassward, @"passward");
            nSqlFormat._serialize(ref mTicks, @"createTime");
            nSqlFormat._serialize(ref mClusterID, @"clusterID");
            nSqlFormat._serialize(ref mServerID, @"serverID");
            nSqlFormat._serialize(ref mDatabaseId, @"databaseId");
            nSqlFormat._serialize(ref mTableId, @"tableId");
        }

        public void _runWhere(ISqlFormat nSqlFormat)
        {
        }

        public string _tableName()
        {
            return ("account_" + mAccountMgrId);
        }

        public SqlType_ _sqlType()
        {
            return SqlType_.mInsert_;
        }

        public AccountCreateB(string nAccountName, string nNickname, string nPassward, uint nAccountMgrId)
        {
            mAccountId = GenerateId._runNameId(nAccountName);
            mClusterID = GenerateId._runClusterID(nAccountName);
            mServerID = GenerateId._runServerID(nAccountName);
            mDatabaseId = GenerateId._runDatabaseId(nAccountName);
            mTableId = GenerateId._runTableId(nAccountName);
            mAccountName = nAccountName;
            mAccountMgrId = nAccountMgrId;
            mNickName = nNickname;
            mPassward = nPassward;
            mTicks = DateTime.Now.Ticks;
        }

        uint mAccountId;
        string mAccountName;
        string mNickName;
        string mPassward;
        long mTicks;
        uint mClusterID;
        uint mServerID;
        uint mDatabaseId;
        uint mTableId;
        uint mAccountMgrId;
    }
}
