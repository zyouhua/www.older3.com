namespace platform
{
    public class Property
    {
        protected __t _getPropertyMgr<__t>() where __t : PropertyMgr
        {
            return mPropertyMgr as __t;
        }

        public void _setPropertyMgr(PropertyMgr nPropertyMgr)
        {
            mPropertyMgr = nPropertyMgr;
        }

        public Property()
        {
            mPropertyMgr = null;
        }

        PropertyMgr mPropertyMgr;
    }
}
