using System.Collections.Generic;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace platform
{
    public class MySqlReader : ISqlFormat
    {
        public void _serialize<__t>(ref List<__t> nValue, string nName) where __t : ISqlStream
        {
        }

        public void _serialize<__t>(ref __t nValue, string nName, SqlFieldId_ nSqlFieldId = SqlFieldId_.mNone_)
        {
        }

        public void _serialize(ref bool nValue, string nName, SqlFieldId_ nSqlFieldId = SqlFieldId_.mNone_)
        {
            nValue = mMySqlDataReader.GetBoolean(nName);
        }

        public void _serialize(ref sbyte nValue, string nName, SqlFieldId_ nSqlFieldId = SqlFieldId_.mNone_)
        {
            nValue = mMySqlDataReader.GetSByte(nName);
        }

        public void _serialize(ref byte nValue, string nName, SqlFieldId_ nSqlFieldId = SqlFieldId_.mNone_)
        {
            nValue = mMySqlDataReader.GetByte(nName);
        }

        public void _serialize(ref short nValue, string nName, SqlFieldId_ nSqlFieldId = SqlFieldId_.mNone_)
        {
            nValue = mMySqlDataReader.GetInt16(nName);
        }

        public void _serialize(ref ushort nValue, string nName, SqlFieldId_ nSqlFieldId = SqlFieldId_.mNone_)
        {
            nValue = mMySqlDataReader.GetUInt16(nName);
        }

        public void _serialize(ref int nValue, string nName, SqlFieldId_ nSqlFieldId = SqlFieldId_.mNone_)
        {
            nValue = mMySqlDataReader.GetInt32(nName);
        }

        public void _serialize(ref uint nValue, string nName, SqlFieldId_ nSqlFieldId = SqlFieldId_.mNone_)
        {
            nValue = mMySqlDataReader.GetUInt32(nName);
        }

        public void _serialize(ref long nValue, string nName, SqlFieldId_ nSqlFieldId = SqlFieldId_.mNone_)
        {
            nValue = mMySqlDataReader.GetInt64(nName);
        }

        public void _serialize(ref ulong nValue, string nName, SqlFieldId_ nSqlFieldId = SqlFieldId_.mNone_)
        {
            nValue = mMySqlDataReader.GetUInt64(nName);
        }

        public void _serialize(ref string nValue, string nName, SqlFieldId_ nSqlFieldId = SqlFieldId_.mNone_)
        {
            nValue = mMySqlDataReader.GetString(nName);
        }

        public void _serialize(ref float nValue, string nName, SqlFieldId_ nSqlFieldId = SqlFieldId_.mNone_)
        {
            nValue = mMySqlDataReader.GetFloat(nName);
        }

        public void _serialize(ref double nValue, string nName, SqlFieldId_ nSqlFieldId = SqlFieldId_.mNone_)
        {
            nValue = mMySqlDataReader.GetDouble(nName);
        }

        public void _serialize(string nValue)
        {
        }

        public MySqlReader(MySqlDataReader nMySqlDataReader)
        {
            mMySqlDataReader = nMySqlDataReader;
        }

        MySqlDataReader mMySqlDataReader;
    }
}
