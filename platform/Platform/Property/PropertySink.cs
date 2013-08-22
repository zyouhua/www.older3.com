using System;
using System.Collections.Generic;

namespace platform
{
    public class PropertySink : Headstream
    {
        public override void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mCreateUrls, @"createUrls");
        }

        public override string _streamName()
        {
            return @"propertySink";
        }

        public virtual void _runInit()
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            foreach (string i in mCreateUrls)
            {
                PropertyId propertyId_ = platformSingleton_._findInterface<PropertyId>(i);
                this._registerCreate(propertyId_);
            }
        }

        void _registerCreate(PropertyId nPropertyId)
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
            mCreateUrls = new List<string>();
        }

        Dictionary<uint, PropertyId> mCreates;
        List<string> mCreateUrls;
    }
}
