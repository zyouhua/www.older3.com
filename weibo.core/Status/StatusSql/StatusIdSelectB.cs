using System;
using System.Collections.Generic;

using platform;
using account.core;

namespace weibo.core
{
    public class StatusIdSelectB : ISqlHeadstream
    {
        public void _initStatusId()
        {
            StatusService statusService_ = __singleton<StatusService>._instance();
            AccountService accountService_ = __singleton<AccountService>._instance();
            IDictionary<uint, AccountMgr> accountMgrs_ = accountService_._getAccountMgrs();
            foreach (StatusIdB i in mStatusIdBs)
            {
                uint accountMgrId_ = i._getAccountMgrId();
                if (accountMgrs_.ContainsKey(accountMgrId_))
                {
                    AccountMgr accountMgr_ = accountMgrs_[accountMgrId_];
                    StatusId statusId_ = accountMgr_._getProperty<StatusId>(statusService_._getId());
                    statusId_._setTableId(i._getTableId());
                }
                else
                {
                    LogSingleton logSingleton_ = __singleton<LogSingleton>._instance();
                    logSingleton_._logError(string.Format(@"StatusIdSelectB _initStatusId:{0}", accountMgrId_));
                    throw new Exception();
                }
            }
        }

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
            return SqlType_.mSelect_;
        }

        public StatusIdSelectB()
        {
            mStatusIdBs = new List<StatusIdB>();
        }

        List<StatusIdB> mStatusIdBs;
    }
}
