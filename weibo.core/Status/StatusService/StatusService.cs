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
            result_.m_tId = nStatusCreateS.m_tId;
            AccountService accountService_ = __singleton<AccountService>._instance();
            Account account_ = accountService_._getAccount(nStatusCreateS.m_tName, 
                nStatusCreateS.m_tDeviceId, nStatusCreateS.m_tDeviceType);
            if (null != account_)
            {
                uint propertyId_ = PropertyId<StatusMgr>._classId();
                StatusMgr statusMgr_ = account_._getProperty<StatusMgr>(propertyId_);
                statusMgr_._createStatus(account_, nStatusCreateS, result_);
            }
            else
            {
                result_.m_tErrorCode = ErrorCode_.mAccount_;
            }
            return result_;
        }

        public StatusGetC _getStatus(StatusGetS nStatusGetS)
        {
            StatusGetC result_ = new StatusGetC();
            AccountService accountService_ = __singleton<AccountService>._instance();
            Account account_ = accountService_._getAccount(nStatusGetS.m_tName,
                nStatusGetS.m_tDeviceId, nStatusGetS.m_tDeviceType);
            if (null == account_)
            {
                result_.m_tErrorCode = ErrorCode_.mAccount_;
                return result_;
            }
            if ( (nStatusGetS.m_tPlayer == nStatusGetS.m_tName) || (null == nStatusGetS.m_tPlayer) )
            {
                this._getStatus(result_, account_, nStatusGetS.m_tTicks);
            }
            else
            {
                this._getStatus(result_, nStatusGetS.m_tPlayer, nStatusGetS.m_tTicks, nStatusGetS.m_tServer);
            }
            return result_;
        }

        void _getStatus(StatusGetC nStatusGetC, Account nAccount, long nTicks)
        {
            uint propertyId_ = PropertyId<StatusMgr>._classId();
            StatusMgr statusMgr_ = nAccount._getProperty<StatusMgr>(propertyId_);
            if (statusMgr_._getTicks() == nTicks)
            {
                nStatusGetC.m_tErrorCode = ErrorCode_.mSucessTicks_;
                return;
            }
            statusMgr_._getStatus(nStatusGetC, nTicks);
        }

        void _getStatus(StatusGetC nStatusGetC, string nName, long nTicks, uint nServer)
        {
            SettingSingleton settingSingleton_ = __singleton<SettingSingleton>._instance();
            if (settingSingleton_._getServerId() != nServer)
            {
                return;
            }
            AccountService accountService_ = __singleton<AccountService>._instance();
            Account account_ = accountService_._getAccount(nName,
                nStatusGetS.m_tDeviceId, nStatusGetS.m_tDeviceType);
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
            statusSink_.m_tStatusGet += _getStatus;
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
                throw new Exception();
            }
        }
    }
}
