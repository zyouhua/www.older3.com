namespace platform
{
    public class SqlParameter
    {
        public SqlField_ _getSqlField()
        {
            return mSqlField;
        }

        public string _getName()
        {
            return mName;
        }

        public __t _getValue<__t>()
        {
            return (__t)mValue;
        }

        public SqlParameter(string nName, object nValue, SqlField_ nSqlField)
        {
            mSqlField = nSqlField;
            mName = nName;
            mValue = nValue;
        }

        SqlField_ mSqlField;
        string mName;
        object mValue;
    }
}
