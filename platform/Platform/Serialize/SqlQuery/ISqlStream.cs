namespace platform
{
    public interface ISqlStream
    {
        void _runSelect(SqlFormat nSqlFormat);

        void _runWhen(SqlFormat nSqlFormat);
    }
}
