using System;
using System.Text;
using System.Collections.Generic;

using platform;
using startup.i;
using account.core;
using weibo.message;

namespace weibo.core
{
    public class StatusMgr : Property
    {
        public void _createStatus(Account nAccount, StatusCreateS nStatusCreateS, StatusCreateC nStatusCreateC)
        {
            AccountMgr accountMgr_ = nAccount._getAccountMgr();
            StatusOption statusOption_ = accountMgr_._getProperty<StatusOption>(StatusService._classId());
            uint tableId_ = statusOption_._getTableId();
            uint accountMgrId_ = accountMgr_._getAccountMgrId();
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
                nStatusCreateC.m_tErrorCode = this._getErrorCode(sqlErrorCode_);
            }
            else
            {
                long statusId_ = statusCreateB_._statusId();
                nStatusCreateC.m_tErrorCode = ErrorCode_.mSucess_;
                nStatusCreateC.m_tStatusId = statusId_;
                mTicks = statusCreateB_._getTicks();
                nStatusCreateC.m_tTicks = mTicks;
                mStatusIds.Add(new StatusId(tableId_, statusId_, mTicks));
            }
        }

        public void _getStatus(StatusGetC nStatusGetC, long nTicks, uint nAccountMgrId, uint nAccountId)
        {
            StatusSelectB statusSelectB_ = new StatusSelectB();
            SqlQuery sqlQuery_ = new SqlQuery();
            SortedSet<uint> tables_ = new SortedSet<uint>();
            int pos = 0;
            foreach (StatusId i in mStatusIds)
            {
                if (i._getTicks() > nTicks)
                {
                    break;
                }
                tables_.Add(i._getTableId());
                ++pos;
                if (pos > 5)
                {
                    break;
                }
            }
            pos = 0;
            foreach (uint i in tables_)
            {
                StatusSelectB statusSelectBTemp_ = new StatusSelectB(nAccountMgrId, i, nAccountId);
                foreach (StatusId j in mStatusIds)
                {
                    if (j._getTableId() == i)
                    {
                        statusSelectBTemp_._addStatusId(j._getStatusId());
                    }
                    ++pos;
                    if (pos > 5)
                    {
                        break;
                    }
                }
                sqlQuery_._addHeadstream(statusSelectBTemp_);
                if (pos > 5)
                {
                    break;
                }
            }
            SqlSingleton mySqlSingleton_ = __singleton<SqlSingleton>._instance();
            SqlErrorCode_ sqlErrorCode_ = mySqlSingleton_._runSqlQuery(sqlQuery_, statusSelectB_);
            nStatusGetC.m_tErrorCode = this._getErrorCode(sqlErrorCode_);
            nStatusGetC.m_tTicks = mTicks;
            if (ErrorCode_.mSucess_ == nStatusGetC.m_tErrorCode)
            {
                statusSelectB_._initStatusGetC(nStatusGetC);
            }
        }

        public void _runAccountLogin()
        {
            Account account_ = this._getPropertyMgr<Account>();
            AccountMgr accountMgr_ = account_._getAccountMgr();
            uint accountMgrId_ = accountMgr_._getAccountMgrId();
            uint accountId_ = account_._getAccountId();
            this._runAccountLogin(accountMgrId_, accountId_);
        }

        public void _runAccountLogin(uint nAccountMgrId, uint nAccountId)
        {
            StatusMgrSelectB statusMgrSelectB_ = new StatusMgrSelectB(nAccountMgrId, nAccountId);
            SqlQuery sqlQuery_ = new SqlQuery();
            sqlQuery_._addHeadstream(statusMgrSelectB_);
            SqlSingleton mySqlSingleton_ = __singleton<SqlSingleton>._instance();
            SqlErrorCode_ sqlErrorCode_ = mySqlSingleton_._runSqlQuery(sqlQuery_, statusMgrSelectB_);
            if (SqlErrorCode_.mSucess_ == sqlErrorCode_)
            {
                mTicks = statusMgrSelectB_._getTicks();
                string value_ = statusMgrSelectB_._getString();
                if (null != value_)
                {
                    this._initStatusIds(value_);
                }
            }
        }

        public void _runAccountLogout()
        {
            StatusMgrInsertB statusMgrInsertB_ = new StatusMgrInsertB(this);
            SqlQuery sqlQuery_ = new SqlQuery();
            sqlQuery_._addHeadstream(statusMgrInsertB_);
            SqlSingleton mySqlSingleton_ = __singleton<SqlSingleton>._instance();
            mySqlSingleton_._runSqlQuery(sqlQuery_);
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

        void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mStatusIds, @"statusIds");
        }

        string _streamName()
        {
            return "statusMgr";
        }

        public void _initStatusIds(string nValue)
        {
            XmlISerialize xmlISerialize_ = new XmlISerialize();
            xmlISerialize_._openString(nValue);
            xmlISerialize_._selectStream(this._streamName());
            this._headSerialize(xmlISerialize_);
            xmlISerialize_._runClose();
        }

        public string _getStrStatusIds()
        {
            string result_ = null;
            XmlOSerialize xmlOSerialize_ = new XmlOSerialize();
            xmlOSerialize_._openString(null);
            xmlOSerialize_._selectStream(this._streamName());
            this._headSerialize(xmlOSerialize_);
            result_ = xmlOSerialize_._getString();
            xmlOSerialize_._runClose();
            return result_;
        }

        public long _getTicks()
        {
            return mTicks;
        }

        public List<StatusId> _getStatusIds()
        {
            return mStatusIds;
        }

        public override void _runInit()
        {
            Account account_ = this._getPropertyMgr<Account>();
            account_.m_tRunLogin += _runAccountLogin;
            account_.m_tRunLogout += _runAccountLogout;
        }

        public StatusMgr()
        {
            mStatusIds = new List<StatusId>();
            mTicks = 0;
        }

        List<StatusId> mStatusIds;
        long mTicks;
    }
}
