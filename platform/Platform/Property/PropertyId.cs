namespace platform
{
    public abstract class PropertyId
    {
        public abstract Property _createProperty();

        public void _setId(uint nId)
        {
            mId = nId;
        }

        public uint _getId()
        {
            return mId;
        }

        public PropertyId()
        {
            mId = 0;
        }

        uint mId;
    }
}
