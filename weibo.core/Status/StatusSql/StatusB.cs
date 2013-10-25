using System;

using platform;
using account.core;
using weibo.message;

namespace weibo.core
{
    public class StatusB : ISqlStream
    {
        public void _runSelect(ISqlFormat nSqlFormat)
        {
            nSqlFormat._serialize(ref mStatusId, @"statusId");
            nSqlFormat._serialize(ref mText, @"text");
            nSqlFormat._serialize(ref mType, @"type");
            nSqlFormat._serialize(ref mTicks, @"createTime");
            nSqlFormat._serialize(ref mAttachments, @"attachments");
        }

        public void _runWhen(ISqlFormat nSqlFormat)
        {
        }

        public StatusC _getStatusC()
        {
            StatusC result_ = new StatusC();
            result_.m_tAttachments = mAttachments;
            result_.m_tText = mText;
            result_.m_tTicks = mTicks;
            result_.m_tType = mType;
            result_.m_tStatusId = mStatusId;
            return result_;
        }

        public StatusB()
        {
            mStatusId = 0;
            mText = null;
            mType = (uint)StatusType_.mText_;
            mAttachments = null;
            mTicks = default(long);
        }
        string mAttachments;
        long mStatusId;
        long mTicks;
        string mText;
        uint mType;
    }
}
