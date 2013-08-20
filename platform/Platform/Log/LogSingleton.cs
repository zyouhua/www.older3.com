namespace platform
{
    public class LogSingleton
    {
        public void _logError(string nError)
        {

        }

        public void _logInfo(string nError)
        {

        }

        public void _runInit(ILog nLog)
        {
            mLog = nLog;
        }

        public LogSingleton()
        {
            mLog = null;
        }

        ILog mLog;
    }
}
