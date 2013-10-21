using System.Collections.Generic;

namespace platform
{
    public class PluginUrls : Headstream
    {
        public override void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mPlugins, @"plugins");
        }

        public override string _streamName()
        {
            return @"pluginUrls";
        }

        public IList<string> _getPlugins()
        {
            return mPlugins;
        }

        public PluginUrls()
        {
            mPlugins = new List<string>();
        }

        List<string> mPlugins;
    }
}