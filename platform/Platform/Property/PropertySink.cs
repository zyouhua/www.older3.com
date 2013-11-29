using System;
using System.Collections.Generic;

using startup.i;

namespace platform
{
    public class PropertySink
    {
        public void _runCreate(PropertyMgr nPropertyMgr)
        {
            foreach (KeyValuePair<uint, IPropertyId> i in mCreates)
            {
                IPropertyId propertyId_ = i.Value;
                Property property_ = propertyId_._createProperty();
                nPropertyMgr._addProperty(property_, propertyId_);
                property_._runInit();
            }
        }

        public IPropertyId _getPropertyId(uint nPropertyId)
        {
            IPropertyId result_ = null;
            if (mCreates.ContainsKey(nPropertyId))
            {
                result_ = mCreates[nPropertyId];
            }
            return result_;
        }

        public void _registerCreate(IPropertyId nPropertyId)
        {
            uint propertyId_ = nPropertyId._getId();
            if (mCreates.ContainsKey(propertyId_))
            {
                LogSingleton logSingleton_ = __singleton<LogSingleton>._instance();
                logSingleton_._logError(string.Format(@"PropertySink _registerInit ContainsKey:{0}", propertyId_));
                throw new Exception();
            }
            mCreates[propertyId_] = nPropertyId;
        }

        public PropertySink()
        {
            mCreates = new Dictionary<uint, IPropertyId>();
        }

        Dictionary<uint, IPropertyId> mCreates;
    }
}
