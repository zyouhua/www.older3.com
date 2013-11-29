using System.Collections.Generic;

using platform;

namespace package
{
    public class Packages : Headstream
    {
        public override void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mPackages, @"package");
        }

        public override string _streamName()
        {
            return "packages";
        }

        public IList<Package> _getPackages()
        {
            return mPackages;
        }

        public Packages()
        {
            mPackages = new List<Package>();
        }

        List<Package> mPackages;
    }
}
