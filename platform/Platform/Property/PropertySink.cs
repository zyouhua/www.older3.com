using System;
using System.Collections.Generic;

namespace platform
{
    public class PropertySink
    {
        public void _registerInit(PropertyId nPropertyId)
        {
            uint propertyId_ = nPropertyId._getId();
            if (mInits.ContainsKey(propertyId_))
            {
                LogSingleton logSingleton_ = __singleton<LogSingleton>._instance();
                logSingleton_._logError(@"PropertySink _registerInit ContainsKey");
                throw new Exception();
            }
            mInits[propertyId_] = nPropertyId;
        }

        public PropertySink()
        {
            mInits = new Dictionary<uint, PropertyId>();
        }

        Dictionary<uint, PropertyId> mInits;
    }
}
