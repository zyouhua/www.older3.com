namespace platform
{
    public interface IDirty
    {
        void _runDirty();

        event _GetBoolSlot m_tIsDirty;

        bool _isDirty();
    }
}
