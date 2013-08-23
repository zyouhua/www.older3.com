using System;
using System.Collections.Generic;

using platform;
using account.core;
using weibo.message;

namespace weibo.core
{
    public class StatusService : PropertyId<StatusOption>
    {
        public StatusCreateC _createStatus(StatusCreateS nStatusCreateS)
        {
            StatusCreateC result_ = new StatusCreateC();
            AccountService accountService_ = __singleton<AccountService>._instance();
            Account account_ = accountService_._getAccount(nStatusCreateS.m_tName, 
                nStatusCreateS.m_tDeviceId, nStatusCreateS.m_tDeviceType);
            if (null != account_)
            {
                StatusMgr statusMgr_ = account_._getProperty<StatusMgr>(PropertyId<StatusMgr>._classId());
                statusMgr_._createStatus(account_, nStatusCreateS, result_);
            }
            else
            {
                result_.m_tErrorCode = ErrorCode_.mAccount_;
            }
            return result_;
        }

        public void _runPreinit()
        {
            this._preinitSink();
            this._preinitInit();
        }

        void _preinitSink()
        {
            StatusSink statusSink_ = __singleton<StatusSink>._instance();
            statusSink_.m_tStatusCreate += _createStatus;
        }

        void _preinitInit()
        {
            InitService initService_ = __singleton<InitService>._instance();
            initService_.m_tRunStart += this._runStart;
            initService_.m_tRunSave += this._saveStatusOption;
        }

        void _runStart()
        {
            this._startStatusOption();
        }

        void _startStatusOption()
        {
            StatusOptionSelectB statusOptionSelectB_ = new StatusOptionSelectB();
            SqlQuery sqlQuery_ = new SqlQuery();
            sqlQuery_._addHeadstream(statusOptionSelectB_);
            SqlSingleton mySqlSingleton_ = __singleton<SqlSingleton>._instance();
            SqlErrorCode_ sqlErrorCode_ = mySqlSingleton_._runSqlQuery(sqlQuery_, statusOptionSelectB_);
            if (SqlErrorCode_.mSucess_ != sqlErrorCode_)
            {
                LogSingleton logSingleton_ = __singleton<LogSingleton>._instance();
                logSingleton_._logError(string.Format(@"StatusService _startStatusOption _runSqlQuery:{0}", sqlErrorCode_));
                throw new Exception();
            }
            statusOptionSelectB_._initStatusOption();
        }

        void _saveStatusOption()
        {
            StatusOptionInsertB statusOptionInsertB_ = new StatusOptionInsertB();
            statusOptionInsertB_._initStatusOption();
            SqlQuery sqlQuery_ = new SqlQuery();
            sqlQuery_._addHeadstream(statusOptionInsertB_);
            SqlSingleton mySqlSingleton_ = __singleton<SqlSingleton>._instance();
            SqlErrorCode_ sqlErrorCode_ = mySqlSingleton_._runSqlQuery(sqlQuery_);
            if (SqlErrorCode_.mSucess_ != sqlErrorCode_)
            {
                LogSingleton logSingleton_ = __singleton<LogSingleton>._instance();
                logSingleton_._logError(string.Format(@"StatusService _saveStatusOption _runSqlQuery:{0}", sqlErrorCode_));
                throw new Exception();
            }
        }
    }
}
