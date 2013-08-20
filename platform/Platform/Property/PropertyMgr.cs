using System;
using System.Collections.Generic;

namespace platform
{
    public class PropertyMgr
    {
        public __t _getProperty<__t>(PropertyId nPropertyId) where __t : IProperty
        {
            __t result_ = default(__t);
            uint propertyId_ = nPropertyId._getId();
            if (mPropertys.ContainsKey(propertyId_))
            {
                result_ = (__t)mPropertys[propertyId_];
            }
            return result_;
        }

        public void _addProperty<__t>(__t nT, PropertyId nPropertyId) where __t : IProperty
        {
            uint propertyId_ = nPropertyId._getId();
            if (mPropertys.ContainsKey(propertyId_))
            {
                LogSingleton logSingleton_ = __singleton<LogSingleton>._instance();
                logSingleton_._logError(@"PropertyMgr _AddProperty ContainsKey");
                throw new Exception();
            }
            mPropertys[propertyId_] = nT;
        }

        public PropertyMgr()
        {
            mPropertys = new Dictionary<uint, IProperty>();
        }

        Dictionary<uint, IProperty> mPropertys;
    }
}
