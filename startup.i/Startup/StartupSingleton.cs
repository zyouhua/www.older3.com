namespace startup.i
{
    public class StartupSingleton
    {
        public void _runInit()
        {
            mStarup._runInit();
        }

        public void _runStart()
        {
            mStarup._runStart();
        }

        public void _runQuit()
        {
            mStarup._runQuit();
        }

        public void _setStartup(IStartup nStartup)
        {
            mStarup = nStartup;
        }

        public StartupSingleton()
        {
            mStarup = null;
        }

        IStartup mStarup;
    }
}
