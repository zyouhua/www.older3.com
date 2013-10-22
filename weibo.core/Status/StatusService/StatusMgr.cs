using System;

using platform;
using weibo.message;
using account.core;

namespace weibo.core
{
    public class StatusMgr : Property
    {
        public StatusCreateC _createStatus(Account nAccount, StatusCreateS nStatusCreateS)
        {
            Account account_ = this._getPropertyMgr<Account>();
            AccountMgr accountMgr_ = account_._getAccountMgr();
            return this._createStatus(nAccount, accountMgr_, nStatusCreateS);
        }

        StatusCreateC _createStatus(Account nAccount, AccountMgr nAccountMgr, StatusCreateS nStatusCreateS)
        {
            StatusService statusService_ = __singleton<StatusService>._instance();
            StatusId statusId_ = nAccountMgr._getProperty<StatusId>(statusService_._getId());
            uint tableId_ = statusId_._getTableId();
            uint accountMgrId_ = nAccountMgr._getId();
            SqlQuery sqlQuery_ = new SqlQuery();
            if (statusId_._createTable())
            {
                tableId_ = statusId_._generateTableId();
                StatusTableCreateB statusTableCreateB_ = new StatusTableCreateB(tableId_, accountMgrId_);
                sqlQuery_._addHeadstream(statusTableCreateB_);
            }
            StatusCreateB statusCreateB_ = new StatusCreateB(nAccount, tableId_, accountMgrId_, nStatusCreateS);
            sqlQuery_._addHeadstream(statusCreateB_);
            SqlSingleton mySqlSingleton_ = __singleton<SqlSingleton>._instance();
            SqlErrorCode_ sqlErrorCode_ = mySqlSingleton_._runSqlQuery(sqlQuery_);
            if (SqlErrorCode_.mSucess_ != sqlErrorCode_)
            {
                LogSingleton logSingleton_ = __singleton<LogSingleton>._instance();
                logSingleton_._logError(string.Format(@"StatusService _createStatus _runSqlQuery:{0}", sqlErrorCode_));
                throw new Exception();
            }
            return null;
        }
    }
}
