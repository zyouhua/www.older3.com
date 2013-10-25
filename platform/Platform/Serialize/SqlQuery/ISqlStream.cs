namespace platform
{
    public interface ISqlStream
    {
        void _runSelect(ISqlFormat nSqlFormat);

        void _runWhen(ISqlFormat nSqlFormat);
    }
}
