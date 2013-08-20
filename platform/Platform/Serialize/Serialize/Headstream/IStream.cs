namespace platform
{
    public interface IStream : IDirty
    {
        void _serialize(ISerialize nSerialize);
    }
}
