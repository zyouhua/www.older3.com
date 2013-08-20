namespace platform
{
    public abstract class Command : ICommand
    {
        public abstract void _runCommand();

        public void _setOwner(object nOwner)
        {
            mOwner = nOwner;
        }

        public object _getOwner()
        {
            return mOwner;
        }

        public Command()
        {
            mOwner = null;
        }

        object mOwner;
    }
}
