namespace startup.i
{
    public interface IStartup
    {
        void _runInit();

        void _runStart();

        void _runQuit();
    }
}
