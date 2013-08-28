﻿using System;
using System.Collections.Generic;

namespace platform
{
    public class PropertyMgr
    {
        public __t _getProperty<__t>(PropertyId nPropertyId) where __t : Property
        {
            __t result_ = default(__t);
            uint propertyId_ = nPropertyId._getId();
            if (mPropertys.ContainsKey(propertyId_))
            {
                result_ = (__t)mPropertys[propertyId_];
            }
            return result_;
        }

        public void _addProperty(Property nProperty, PropertyId nPropertyId)
        {
            uint propertyId_ = nPropertyId._getId();
            if (mPropertys.ContainsKey(propertyId_))
            {
                LogSingleton logSingleton_ = __singleton<LogSingleton>._instance();
                logSingleton_._logError(@"PropertyMgr _AddProperty ContainsKey");
                throw new Exception();
            }
            nProperty._setPropertyMgr(this);
            mPropertys[propertyId_] = nProperty;
        }

        public PropertyMgr()
        {
            mPropertys = new Dictionary<uint, Property>();
        }

        Dictionary<uint, Property> mPropertys;
    }
}
