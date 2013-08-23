﻿using System;
using System.Collections.Generic;

using platform;
using account.core;

namespace weibo.core
{
    public class StatusOptionInsertB : ISqlHeadstream
    {
        public void _runSelect(ISqlFormat nSqlFormat)
        {
            nSqlFormat._serialize(ref mStatusOptionBs, @"statusOptionBs");
        }

        public void _runWhere(ISqlFormat nSqlFormat)
        {
        }

        public string _tableName()
        {
            return @"statusOption";
        }

        public SqlType_ _sqlType()
        {
            return SqlType_.mInsertUpdate_;
        }

        public void _initStatusOption()
        {
            StatusService statusService_ = __singleton<StatusService>._instance();
            AccountService accountService_ = __singleton<AccountService>._instance();
            IDictionary<uint, AccountMgr> accountMgrs_ = accountService_._getAccountMgrs();
            foreach (KeyValuePair<uint, AccountMgr> i in accountMgrs_)
            {
                AccountMgr accountMgr_ = i.Value;
                uint accountMgrId_ = i.Key;
                StatusOption statusOption_ = accountMgr_._getProperty<StatusOption>(statusService_._getId());
                StatusOptionB statusOptionB_ = new StatusOptionB(accountMgrId_, statusOption_);
                mStatusOptionBs.Add(statusOptionB_);
            }
        }

        public StatusOptionInsertB()
        {
            mStatusOptionBs = new List<StatusOptionB>();
        }

        List<StatusOptionB> mStatusOptionBs;
    }
}
