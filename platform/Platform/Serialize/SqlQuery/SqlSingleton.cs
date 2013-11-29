using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

using startup.i;

namespace platform
{
    public class SqlSingleton : Headstream
    {
        public SqlErrorCode_ _runSqlQuery(SqlQuery nSqlQuery)
        {
            string sqlCommand_ = nSqlQuery._runFormat();
            SqlErrorCode_ errorCode_ = SqlErrorCode_.mSucess_;
            MySqlConnection mySqlConnection_ = new MySqlConnection(mConnectionString);
            try
            {
                mySqlConnection_.Open();
                MySqlCommand mySqlCommand_ = new MySqlCommand();
                mySqlCommand_.Connection = mySqlConnection_;
                mySqlCommand_.CommandText = sqlCommand_;
                IList<SqlParameter> fields_ = nSqlQuery._getFields();
                foreach (SqlParameter i in fields_)
                {
                    string name_ = i._getName();
                    SqlField_ sqlField_ = i._getSqlField();
                    if (SqlField_.mBool_ == sqlField_)
                    {
                        bool value_ = i._getValue<bool>();
                        mySqlCommand_.Parameters.AddWithValue(name_, value_);
                    }
                    else if (SqlField_.mI32_ == sqlField_)
                    {
                        int value_ = i._getValue<int>();
                        mySqlCommand_.Parameters.AddWithValue(name_, value_);
                    }
                    else if (SqlField_.mU32_ == sqlField_)
                    {
                        uint value_ = i._getValue<uint>();
                        mySqlCommand_.Parameters.AddWithValue(name_, value_);
                    }
                    else if (SqlField_.mI64_ == sqlField_)
                    {
                        long value_ = i._getValue<long>();
                        mySqlCommand_.Parameters.AddWithValue(name_, value_);
                    }
                    else if (SqlField_.mU64_ == sqlField_)
                    {
                        ulong value_ = i._getValue<ulong>();
                        mySqlCommand_.Parameters.AddWithValue(name_, value_);
                    }
                    else if (SqlField_.mString_ == sqlField_)
                    {
                        string value_ = i._getValue<string>();
                        mySqlCommand_.Parameters.AddWithValue(name_, value_);
                    }
                    else if (SqlField_.mFloat_ == sqlField_)
                    {
                        float value_ = i._getValue<float>();
                        mySqlCommand_.Parameters.AddWithValue(name_, value_);
                    }
                    else if (SqlField_.mDouble_ == sqlField_)
                    {
                        double value_ = i._getValue<double>();
                        mySqlCommand_.Parameters.AddWithValue(name_, value_);
                    }
                    else if (SqlField_.mBytes_ == sqlField_)
                    {
                        byte[] value_ = i._getValue<byte[]>();
                        mySqlCommand_.Parameters.AddWithValue(name_, value_);
                    }
                    else
                    {
                    }
                }
                mySqlCommand_.ExecuteNonQuery();
            }
            catch (MySqlException exception_)
            {
                LogSingleton logSingleton_ = __singleton<LogSingleton>._instance();
                logSingleton_._logError(string.Format(@"sqlError:{0},{1}", exception_.Number, exception_.Message));
                errorCode_ = SqlErrorCode_.mFail_;
            }
            mySqlConnection_.Close();
            return errorCode_;
        }

        public SqlErrorCode_ _runSqlQuery(SqlQuery nSqlQuery, ISqlHeadstream nSqlHeadstream)
        {
            string sqlCommand_ = nSqlQuery._runFormat();
            SqlErrorCode_ errorCode_ = SqlErrorCode_.mSucess_;
            MySqlConnection mySqlConnection_ = new MySqlConnection(mConnectionString);
            try
            {
                mySqlConnection_.Open();
                MySqlCommand mySqlCommand_ = new MySqlCommand(sqlCommand_, mySqlConnection_);
                MySqlDataReader mySqlDataReader_ = mySqlCommand_.ExecuteReader();
                MySqlReader mySqlReader_ = new MySqlReader(mySqlDataReader_);
                while (mySqlDataReader_.Read())
                {
                    nSqlHeadstream._runSelect(mySqlReader_);
                }
                mySqlDataReader_.Close();
            }
            catch (MySqlException exception_)
            {
                LogSingleton logSingleton_ = __singleton<LogSingleton>._instance();
                logSingleton_._logError(string.Format(@"sqlError:{0},{1}", exception_.Number, exception_.Message));
                errorCode_ = SqlErrorCode_.mFail_;
            }
            mySqlConnection_.Close();
            return errorCode_;
        }

        public override void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mConnectionString, @"connectionString");
        }

        public override string _streamName()
        {
            return @"sqlSingleton";
        }

        public string _getConnectionString()
        {
            return mConnectionString;
        }

        public SqlSingleton()
        {
            mConnectionString = null;
        }

        string mConnectionString;
    }
}
