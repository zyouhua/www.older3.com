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

        public void _initStatusId()
        {
            StatusService statusService_ = __singleton<StatusService>._instance();
            AccountService accountService_ = __singleton<AccountService>._instance();
            IDictionary<uint, AccountMgr> accountMgrs_ = accountService_._getAccountMgrs();
            foreach (KeyValuePair<uint, AccountMgr> i in accountMgrs_)
            {
                AccountMgr accountMgr_ = i.Value;
                uint accountMgrId_ = i.Key;
                StatusId statusId_ = accountMgr_._getProperty<StatusId>(statusService_._getId());
                StatusIdB statusIdB_ = new StatusIdB(accountMgrId_, statusId_);
                mStatusIdBs.Add(statusIdB_);
            }
        }

        public StatusIdInsertB()
        {
            mStatusIdBs = new List<StatusIdB>();
        }

        List<StatusIdB> mStatusIdBs;
    }
}
