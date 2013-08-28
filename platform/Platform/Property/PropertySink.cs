using System;
using System.Collections.Generic;

namespace platform
{
    public class PropertySink
    {
        public void _runCreate(PropertyMgr nPropertyMgr)
        {
            foreach (KeyValuePair<uint, PropertyId> i in mCreates)
            {
                PropertyId propertyId_ = i.Value;
                Property property_ = propertyId_._createProperty();
                nPropertyMgr._addProperty(property_, propertyId_);
            }
        }

        public void _registerCreate(PropertyId nPropertyId)
        {
            uint propertyId_ = nPropertyId._getId();
            if (mCreates.ContainsKey(propertyId_))
            {
                LogSingleton logSingleton_ = __singleton<LogSingleton>._instance();
                logSingleton_._logError(@"PropertySink _registerInit ContainsKey");
                throw new Exception();
            }
            mCreates[propertyId_] = nPropertyId;
        }

        public PropertySink()
        {
            mCreates = new Dictionary<uint, PropertyId>();
        }

        Dictionary<uint, PropertyId> mCreates;
    }
}
