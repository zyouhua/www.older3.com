﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

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
                MySqlCommand mySqlCommand_ = new MySqlCommand(sqlCommand_, mySqlConnection_);
                mySqlCommand_.ExecuteNonQuery();
            }
            catch (Exception exception_)
            {
                LogSingleton logSingleton_ = __singleton<LogSingleton>._instance();
                logSingleton_._logError(exception_.ToString());
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
                if (mySqlDataReader_.Read())
                {
                    nSqlHeadstream._runSelect(mySqlReader_);
                }
                mySqlDataReader_.Close();
            }
            catch (Exception exception_)
            {
                LogSingleton logSingleton_ = __singleton<LogSingleton>._instance();
                logSingleton_._logError(exception_.ToString());
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
