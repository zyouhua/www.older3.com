using System.Collections.Generic;

namespace platform
{
    public class AssemblyDescriptor : Headstream
    {
        public override void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mUids, @"uids");
            nSerialize._serialize(ref mAddins, @"addins");
            nSerialize._serialize(ref mRids, @"rids");
            nSerialize._serialize(ref mPlugins, @"plugins");
            nSerialize._serialize(ref mDependences, @"dependences");
        }

        public override string _streamName()
        {
            return @"assemblyDescriptor";
        }

        public IEnumerable<Uid> _getUids()
        {
            return mUids;
        }

        public IEnumerable<Uid> _getAddins()
        {
            return mAddins;
        }

        public IEnumerable<Rid> _getRids()
        {
            return mRids;
        }

        public IEnumerable<string> _getDependences()
        {
            return mDependences;
        }

        public IEnumerable<string> _getPlugins()
        {
            return mPlugins;
        }

        public AssemblyDescriptor()
        {
            mUids = new List<Uid>();
            mAddins = new List<Uid>();
            mRids = new List<Rid>();
            mPlugins = new List<string>();
            mDependences = new List<string>();
        }

        List<Uid> mUids;
        List<Uid> mAddins;
        List<Rid> mRids;
        List<string> mPlugins;
        List<string> mDependences;
    }
}
