using System;
using System.Collections.Generic;

using platform;
using weibo.message;
using account.core;

namespace weibo.core
{
    public class StatusMgr : Property
    {
        public void _createStatus(Account nAccount, StatusCreateS nStatusCreateS, StatusCreateC nStatusCreateC)
        {
            AccountMgr accountMgr_ = nAccount._getAccountMgr();
            StatusOption statusOption_ = accountMgr_._getProperty<StatusOption>(StatusService._classId());
            uint tableId_ = statusOption_._getTableId();
            uint accountMgrId_ = accountMgr_._getId();
            SqlQuery sqlQuery_ = new SqlQuery();
            if (statusOption_._createTable())
            {
                tableId_ = statusOption_._generateTableId();
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
                nStatusCreateC.m_tErrorCode = this._getErrorCode(sqlErrorCode_);
            }
            else
            {
                nStatusCreateC.m_tErrorCode = ErrorCode_.mSucess_;
            }
        }

        ErrorCode_ _getErrorCode(SqlErrorCode_ nSqlErrorCode)
        {
            ErrorCode_ result_ = ErrorCode_.mSucess_;
            if (SqlErrorCode_.mFail_ == nSqlErrorCode)
            {
                result_ = ErrorCode_.mFail_;
            }
            return result_;
        }

        Dictionary<long, StatusId> mStatusId;
    }
}
