using System.Collections.Generic;

namespace platform
{
    public class AppUrls : Headstream
    {
        public override void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mAppUrls, @"urls");
        }

        public override string _streamName()
        {
            return @"appUrls";
        }

        public IList<string> _getAppUrls()
        {
            return mAppUrls;
        }

        public AppUrls()
        {
            mAppUrls = new List<string>();
        }

        List<string> mAppUrls;
    }
}
