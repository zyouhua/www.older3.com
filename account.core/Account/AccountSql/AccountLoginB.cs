using System;

using platform;
using account.message;

namespace account.core
{
    public class AccountLoginB : ISqlHeadstream
    {
        public void _runSelect(ISqlFormat nSqlFormat)
        {
            nSqlFormat._serialize(ref mNickName, @"nickName");
            nSqlFormat._serialize(ref mPassward, @"passward");
            nSqlFormat._serialize(ref mTicks, @"createTime");
        }

        public void _runWhere(ISqlFormat nSqlFormat)
        {
            nSqlFormat._serialize(ref mAccountId, @"WHERE accountId = ");
        }

        public ErrorCode_ _checkPassward(string nPassward)
        {
            ErrorCode_ result_ = ErrorCode_.mSucess_;
            if ( (null == nPassward) || (null == mNickName) || (0 == mTicks) )
            {
                result_ = ErrorCode_.mNoAccount_;
            }
            if (ErrorCode_.mSucess_ == result_)
            {
                uint loginPassward_ = GenerateId._runPasswardId(nPassward);
                uint hashPassward_ = GenerateId._runPasswardId(mPassward);
                if (loginPassward_ != hashPassward_)
                {
                    result_ = ErrorCode_.mPassward_;
                }
            }
            return result_;
        }

        public string _tableName()
        {
            return ("account_" + mAccountMgrId);
        }

        public SqlType_ _sqlType()
        {
            return SqlType_.mSelect_;
        }

        public Account _createAccount()
        {
            Account result_ = new Account();
            result_._setAccountId(mAccountId);
            result_._setNick(mNickName);
            result_._setTicks(DateTime.Now.Ticks);
            AccountCreator accountCreator_ = __singleton<AccountCreator>._instance();
            accountCreator_._runCreate(result_);
            return result_;
        }

        public uint _getAccountId()
        {
            return mAccountId;
        }

        public string _getNick()
        {
            return mNickName;
        }

        public long _getTicks()
        {
            return mTicks;
        }

        public AccountLoginB(string nAccountName, uint nAccountMgrId)
        {
            mAccountId = GenerateId._runNameId(nAccountName);
            mAccountName = nAccountName;
            mAccountMgrId = nAccountMgrId;
        }

        uint mAccountId;
        string mAccountName;
        string mNickName;
        string mPassward;
        long mTicks;
        uint mAccountMgrId;
    }
}
