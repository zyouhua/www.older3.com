using System;
using System.Reflection;
using System.Collections.Generic;

namespace platform
{
    public class SqlFormat : ISqlFormat
    {
        static readonly string mCharacter = @"'";

        public void _serialize<__t>(ref List<__t> nValue, string nName) where __t : ISqlStream
        {
            if (SqlDeal_.mSelect_ == mSqlDeal)
            {
                if (nValue.Count > 0)
                {
                    nValue[0]._runSelect(this);
                }
                else
                {
                    __t t_ = Activator.CreateInstance<__t>();
                    t_._runSelect(this);
                }
            }
            else if (SqlDeal_.mInsert_ == mSqlDeal)
            {
                bool temp_ = false;
                foreach (__t i in nValue)
                {
                    if (temp_)
                    {
                        mValue += "),(";
                        mBeg = true;
                    }
                    i._runSelect(this);
                    temp_ = true;
                }
            }
            else if (SqlDeal_.mInsertUpdate_ == mSqlDeal)
            {
                mValue += "ON DUPLICATE KEY UPDATE";
                mBeg = true;
                foreach (__t i in nValue)
                {
                    i._runSelect(this);
                    break;
                }
            }
            else if (SqlDeal_.mUpdate_ == mSqlDeal)
            {
                mUpdate.Clear();
                mSqlDeal = SqlDeal_.mUpdateSelect_;
                foreach (__t i in nValue)
                {
                    i._runSelect(this);
                    break;
                }
                bool temp_ = true;
                foreach (string i in mUpdate)
                {
                    mName = i;
                    if (false == temp_)
                    {
                        mValue += ",";
                    }
                    mValue += mName;
                    mValue += "= CASE ";
                    mSqlDeal = SqlDeal_.mSelect_;
                    mBeg = true;
                    foreach (__t j in nValue)
                    {
                        j._runWhen(this);
                        break;
                    }
                    foreach (__t j in nValue)
                    {
                        mSqlDeal = SqlDeal_.mUpdateWhen_;
                        mValue += " WHEN ";
                        j._runWhen(this);
                        mSqlDeal = SqlDeal_.mUpdateThen_;
                        mValue += "THEN ";
                        j._runSelect(this);
                    }
                    mValue += " END";
                    if (temp_)
                    {
                        temp_ = false;
                    }
                }
                mValue += " WHERE ";
                mSqlDeal = SqlDeal_.mSelect_;
                mBeg = true;
                foreach (__t i in nValue)
                {
                    i._runWhen(this);
                    break;
                }
                mSqlDeal = SqlDeal_.mInsert_;
                mBeg = true;
                mValue += " IN (";
                foreach (__t i in nValue)
                {
                    i._runWhen(this);
                }
                mValue += ")";
            }
            else
            {
            }
        }

        public void _serialize<__t>(ref __t nValue, string nName)
        {
            this._runSerialize(ref nValue, nName);
        }

        void _runSerialize<__t>(ref __t nValue, string nName)
        {
            if (SqlDeal_.mSelect_ == mSqlDeal)
            {
                if (false == mBeg)
                {
                    mValue += ",";
                }
                mValue += nName;
                if (mBeg)
                {
                    mBeg = false;
                }
            }
            else if (SqlDeal_.mInsert_ == mSqlDeal)
            {
                if (false == mBeg)
                {
                    mValue += ",";
                }
                mValue += mCharacter;
                mValue += Convert.ToString(nValue);
                mValue += mCharacter;
                if (mBeg)
                {
                    mBeg = false;
                }
            }
            else if (SqlDeal_.mWhere_ == mSqlDeal)
            {
                mValue += nName;
                mValue += mCharacter;
                mValue += Convert.ToString(nValue);
                mValue += mCharacter;
                mValue += " ";
            }
            else if (SqlDeal_.mUpdate_ == mSqlDeal)
            {
                if (false == mBeg)
                {
                    mValue += ",";
                }
                mValue += nName;
                mValue += "=";
                mValue += mCharacter;
                mValue += Convert.ToString(nValue);
                mValue += mCharacter;
                if (mBeg)
                {
                    mBeg = false;
                }
            }
            else if (SqlDeal_.mUpdateSelect_ == mSqlDeal)
            {
                mUpdate.Add(nName);
            }
            else if (SqlDeal_.mInsertUpdate_ == mSqlDeal)
            {
                if (false == mBeg)
                {
                    mValue += @",";
                }
                mValue += nName;
                mValue += @"=VALUES(";
                mValue += nName;
                mValue += @")";
                if (mBeg)
                {
                    mBeg = false;
                }
            }
            else if (SqlDeal_.mUpdateWhen_ == mSqlDeal)
            {
                mValue += mCharacter;
                mValue += Convert.ToString(nValue);
                mValue += mCharacter;
                mValue += " ";
            }
            else if (SqlDeal_.mUpdateThen_ == mSqlDeal)
            {
                if (mName == nName)
                {
                    mValue += mCharacter;
                    mValue += Convert.ToString(nValue);
                    mValue += mCharacter;
                }
            }
            else
            {
            }
        }

        public void _serialize(ref bool nValue, string nName)
        {
            this._runSerialize(ref nValue, nName);
        }

        public void _serialize(ref sbyte nValue, string nName)
        {
            this._runSerialize(ref nValue, nName);
        }

        public void _serialize(ref byte nValue, string nName)
        {
            this._runSerialize(ref nValue, nName);
        }

        public void _serialize(ref short nValue, string nName)
        {
            this._runSerialize(ref nValue, nName);
        }

        public void _serialize(ref ushort nValue, string nName)
        {
            this._runSerialize(ref nValue, nName);
        }

        public void _serialize(ref int nValue, string nName)
        {
            this._runSerialize(ref nValue, nName);
        }

        public void _serialize(ref uint nValue, string nName)
        {
            this._runSerialize(ref nValue, nName);
        }

        public void _serialize(ref long nValue, string nName)
        {
            this._runSerialize(ref nValue, nName);
        }

        public void _serialize(ref ulong nValue, string nName)
        {
            this._runSerialize(ref nValue, nName);
        }

        public void _serialize(ref string nValue, string nName)
        {
            this._runSerialize(ref nValue, nName);
        }

        public void _serialize(ref float nValue, string nName)
        {
            this._runSerialize(ref nValue, nName);
        }

        public void _serialize(ref double nValue, string nName)
        {
            this._runSerialize(ref nValue, nName);
        }

        public void _serialize(string nValue)
        {
            mValue += nValue;
        }

        public void _runFormat(ISqlHeadstream nSqlStream)
        {
            SqlType_ sqlType_ = nSqlStream._sqlType();
            if (SqlType_.mDelete_ == sqlType_)
            {
                this._runDelete(nSqlStream);
            }
            else if (SqlType_.mInsert_ == sqlType_)
            {
                this._runInsert(nSqlStream);
            }
            else if (SqlType_.mSelect_ == sqlType_)
            {
                this._runSelect(nSqlStream);
            }
            else if (SqlType_.mUpdate_ == sqlType_)
            {
                this._runUpdate(nSqlStream);
            }
            else if (SqlType_.mInsertUpdate_ == sqlType_)
            {
                this._runInsertUpdate(nSqlStream);
            }
            else
            {
            }
        }

        public void _runDelete(ISqlHeadstream nSqlHeadstream)
        {
            mValue += @"DELETE FROM ";
            mValue += nSqlHeadstream._tableName();
            mValue += @" ";
            mSqlDeal = SqlDeal_.mWhere_;
            nSqlHeadstream._runWhere(this);
            mSqlDeal = SqlDeal_.mNone_;
        }

        public void _runInsert(ISqlHeadstream nSqlHeadstream)
        {
            mValue += @"INSERT INTO ";
            mValue += nSqlHeadstream._tableName();
            mValue += @" (";
            mBeg = true;
            mSqlDeal = SqlDeal_.mSelect_;
            nSqlHeadstream._runSelect(this);
            mValue += @") VALUES (";
            mBeg = true;
            mSqlDeal = SqlDeal_.mInsert_;
            nSqlHeadstream._runSelect(this);
            mValue += @") ";
            mSqlDeal = SqlDeal_.mWhere_;
            nSqlHeadstream._runWhere(this);
            mSqlDeal = SqlDeal_.mNone_;
        }

        public void _runSelect(ISqlHeadstream nSqlHeadstream)
        {
            mValue += @"SELECT ";
            mBeg = true;
            mSqlDeal = SqlDeal_.mSelect_;
            nSqlHeadstream._runSelect(this);
            mValue += @" FROM ";
            mValue += nSqlHeadstream._tableName();
            mValue += @" ";
            mSqlDeal = SqlDeal_.mWhere_;
            nSqlHeadstream._runWhere(this);
            mSqlDeal = SqlDeal_.mNone_;
        }

        public void _runUpdate(ISqlHeadstream nSqlHeadstream)
        {
            mValue += @"UPDATE ";
            mValue += nSqlHeadstream._tableName();
            mValue += @" SET ";
            mBeg = true;
            mSqlDeal = SqlDeal_.mUpdate_;
            nSqlHeadstream._runSelect(this);
            mSqlDeal = SqlDeal_.mWhere_;
            mValue += @" ";
            nSqlHeadstream._runWhere(this);
            mSqlDeal = SqlDeal_.mNone_;
        }

        public void _runInsertUpdate(ISqlHeadstream nSqlHeadstream)
        {
            mValue += @"INSERT INTO ";
            mValue += nSqlHeadstream._tableName();
            mValue += @" (";
            mBeg = true;
            mSqlDeal = SqlDeal_.mSelect_;
            nSqlHeadstream._runSelect(this);
            mValue += @") VALUES (";
            mBeg = true;
            mSqlDeal = SqlDeal_.mInsert_;
            nSqlHeadstream._runSelect(this);
            mValue += @") ";
            mSqlDeal = SqlDeal_.mInsertUpdate_;
            nSqlHeadstream._runSelect(this);
            mSqlDeal = SqlDeal_.mWhere_;
            nSqlHeadstream._runWhere(this);
            mSqlDeal = SqlDeal_.mNone_;
        }

        public string _sqlCommand()
        {
            return mValue;
        }

        public SqlFormat()
        {
            mUpdate = new List<string>();
            mSqlDeal = SqlDeal_.mNone_;
            mValue = null;
            mName = null;
            mBeg = false;
        }

        List<string> mUpdate;
        SqlDeal_ mSqlDeal;
        string mValue;
        string mName;
        bool mBeg;
    }
}
