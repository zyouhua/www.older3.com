using System.IO;
using System.Reflection;

namespace platform
{
    public class SettingSingleton : Headstream
    {
        public override void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mUrlDirectory, @"urlDirectory", mUrlDirectory);
            base._headSerialize(nSerialize);
        }

        public override string _streamName()
        {
            return @"setting";
        }

        public void _runInit(string nPath = null)
        {
            if (null == nPath)
            {
                Assembly assembly = typeof(SettingSingleton).Assembly;
                string path_ = Path.GetDirectoryName(assembly.Location);
                mSystemPath = Path.Combine(path_, "..");
            }
            else
            {
                mSystemPath = nPath;
            }
            string rootPath_ = Path.Combine(mSystemPath, "..");
            mUrlDirectory = Path.Combine(rootPath_, "home");
        }

        public string _systemPath()
        {
            return mSystemPath;
        }

        public void _setServerId(uint nServerId)
        {
            mServerId = nServerId;
        }

        public uint _getServerId()
        {
            return mServerId;
        }

        public string _urlDirectory()
        {
            if (null == mUrlDirectory)
            {
                return mDefaultUrlDirectory;
            }
            return mUrlDirectory;
        }

        public SettingSingleton()
        {
            mDefaultUrlDirectory = null;
            mUrlDirectory = null;
            mSystemPath = null;
            mServerId = 0;
        }

        string mDefaultUrlDirectory;
        string mUrlDirectory;
        string mSystemPath;
        uint mServerId;
    }
}
