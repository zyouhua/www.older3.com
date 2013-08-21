using System;
using System.Collections.Generic;

using platform;
using account.message;

namespace account.core
{
    public class AccountMgr
    {
        public ErrorCode_ _createAccount(string nAccountName, string nNickname, string nPassward)
        {
            SqlQuery sqlQuery_ = new SqlQuery();
            sqlQuery_._addHeadstream(new AccountCreateB(nAccountName, nNickname, nPassward, mId));
            SqlSingleton mySqlSingleton_ = __singleton<SqlSingleton>._instance();
            return _getErrorCode(mySqlSingleton_._runSqlQuery(sqlQuery_));
        }

//         public AccountLoginC _loginAccount(string nAccountName, string nPassward, uint nDeviceType)
//         {
//             ErrorCode_ errorCode_ = this._checkDevice(nDeviceType);
//             if (ErrorCode_.mSucess_ != errorCode_)
//             {
//                 __tuple<SqlErrorCode_, AccountLoginB> accountLoginB_ = this._loginAccountLoginB(nAccountName);
//                 errorCode_ = this._getErrorCode(accountLoginB_._get_0());
//                 if (ErrorCode_.mSucess_ == errorCode_)
//                 {
//                     AccountB accountB_ = accountDB_._get_1();
//                     errorCode_ = accountB_._checkPassward(nPassward);
//                 }
//             }
//             Account account_ = null;
//             if (ErrorCode_.mSucess_ == errorCode_)
//             {
//                 uint accountId_ = AccountB._accountId(nAccountName);
//                 account_ = this._getAccount(accountId_);
//                 if (null == account_)
//                 {
//                     account_ = new Account();
//                     account_._setAccountId(accountId_);
//                     account_._addDeviceType(nDeviceType);
//                     mAccounts[accountId_] = account_;
//                 }
//                 account_._setTicks(DateTime.Now.Ticks);
//             }
//             return new __tuple<ErrorCode_, Account>(errorCode_, account_);
/*        }*/

//         __tuple<SqlErrorCode_, AccountLoginB> _loginAccountLoginB(string nAccountName)
//         {
//             AccountLoginB accountLoginB_ = new AccountLoginB(nAccountName, mId);
//             SqlQuery sqlQuery_ = new SqlQuery();
//             sqlQuery_._addHeadstream(accountLoginB_);
//             SqlSingleton mySqlSingleton_ = __singleton<SqlSingleton>._instance();
//             SqlErrorCode_ sqlErrorCode_ = mySqlSingleton_._runSqlQuery(sqlQuery_, accountLoginB_);
//             Account account_ = this._loginAccountLoginB(accountLoginB_);
//         }
// 
//         Account _loginAccountLoginB(AccountLoginB nAccountLoginB)
//         {
//         }
        
        ErrorCode_ _getErrorCode(SqlErrorCode_ nSqlErrorCode)
        {
            ErrorCode_ result_ = ErrorCode_.mSucess_;
            if (SqlErrorCode_.mFail_ == nSqlErrorCode)
            {
                result_ = ErrorCode_.mFail_;
            }
            return result_;
        }

        public AccountMgr(uint nId)
        {
            mAccounts = new Dictionary<uint, Account>();
            mId = 0;
        }

        Dictionary<uint, Account> mAccounts;
        uint mId;
    }
}
