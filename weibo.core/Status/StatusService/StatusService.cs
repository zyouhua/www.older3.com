using System;
using System.Collections.Generic;

using platform;
using account.core;
using weibo.message;

namespace weibo.core
{
    public class StatusService : PropertyId<StatusId>
    {
        public StatusCreateC _createStatus(StatusCreateS nStatusCreateS)
        {
            AccountService accountService_ = __singleton<AccountService>._instance();
            Account account_ = accountService_._getAccount(nStatusCreateS.m_tName, 
                nStatusCreateS.m_tDeviceId, nStatusCreateS.m_tDeviceType);
            StatusMgr statusMgr_ = account_._getProperty<StatusMgr>(PropertyId<StatusMgr>._classId());
            return statusMgr_._createStatus(nStatusCreateS);
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
        }

        void _runStart()
        {
            this._startStatusId();
        }

        void _startStatusId()
        {
            StatusIdSelectB statusIdSelectB_ = new StatusIdSelectB();
            SqlQuery sqlQuery_ = new SqlQuery();
            sqlQuery_._addHeadstream(statusIdSelectB_);
            SqlSingleton mySqlSingleton_ = __singleton<SqlSingleton>._instance();
            SqlErrorCode_ sqlErrorCode_ = mySqlSingleton_._runSqlQuery(sqlQuery_, statusIdSelectB_);
            if (SqlErrorCode_.mSucess_ != sqlErrorCode_)
            {
                LogSingleton logSingleton_ = __singleton<LogSingleton>._instance();
                logSingleton_._logError(string.Format(@"StatusService _startStatusId _runSqlQuery:{0}", sqlErrorCode_));
                throw new Exception();
            }
            statusIdSelectB_._initStatusId();
        }
    }
}
