namespace platform
{
    public interface ISqlHeadstream
    {
        void _runSelect(ISqlFormat nSqlFormat);

        void _runWhere(ISqlFormat nSqlFormat);

        string _tableName();

        SqlType_ _sqlType();
    }
}
